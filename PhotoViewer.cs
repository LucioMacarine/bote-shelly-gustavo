using DSharpPlus;
using System;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using DSharpPlus.EventArgs;
using System.Linq;
using System.Collections.Generic;
using shelly_antoneo.tools;

namespace shelly_antoneo
{
    public class PhotoViewer
    {
        private DiscordClient Client;
        private InteractionContext Context;
        private Favorite CurrentPost;
        private List<Favorite> Content;
        private int SelectedIndex = 1;
        private int MaxIndex;

        public PhotoViewer(InteractionContext context, DiscordClient client)
        /*inicia a classe copiando o cliente e o contexto da mensagem, é ativado por Hentai(); ali em cima
        isso é necessário para que cada instância da "thread" de imagens seja iniciada separadamente
        assim impedindo os campos TagsArray, Engine e CurrentPost de se misturarem com outras intâncias dessa classe*/
        {
            Context = context;
            Client = client;
        }

        public async Task<DiscordWebhookBuilder> PhotoViewerInit(List<Favorite> content, bool useNavBar = true)
        {
            Client.ComponentInteractionCreated -= NavHandle;

            Tools Tools = new Tools();

            var contentWithShift = content[SelectedIndex - 1];

            MaxIndex = content.ToArray().Length;

            //componentes de navegação (ex: -->, <--, >>>, <<<)
            var navComponents = new List<DiscordComponent> { };
            if (SelectedIndex > 1)
            {
                navComponents.Add(new DiscordButtonComponent(ButtonStyle.Secondary, $"{Context.InteractionId.ToString()}PictNav,BackToStart", "", emoji: new DiscordComponentEmoji("⏪")));
                navComponents.Add(new DiscordButtonComponent(ButtonStyle.Secondary, $"{Context.InteractionId.ToString()}PictNav,Back1", "", emoji: new DiscordComponentEmoji("◀️")));
            }
            else
            {
                navComponents.Add(new DiscordButtonComponent(ButtonStyle.Secondary, $"{Context.InteractionId.ToString()}PictNav,BackToStart", "", true, new DiscordComponentEmoji("⏪")));
                navComponents.Add(new DiscordButtonComponent(ButtonStyle.Secondary, $"{Context.InteractionId.ToString()}PictNav,Back1", "", true, new DiscordComponentEmoji("◀️")));
            }
            if (SelectedIndex < MaxIndex)
            {
                navComponents.Add(new DiscordButtonComponent(ButtonStyle.Secondary, $"{Context.InteractionId.ToString()}PictNav,Forward1", "", emoji: new DiscordComponentEmoji("▶️")));
                navComponents.Add(new DiscordButtonComponent(ButtonStyle.Secondary, $"{Context.InteractionId.ToString()}PictNav,ForwardToEnd", "", emoji: new DiscordComponentEmoji("⏩")));
            }
            else
            {
                navComponents.Add(new DiscordButtonComponent(ButtonStyle.Secondary, $"{Context.InteractionId.ToString()}PictNav,Forward1", "", true, new DiscordComponentEmoji("▶️")));
                navComponents.Add(new DiscordButtonComponent(ButtonStyle.Secondary, $"{Context.InteractionId.ToString()}PictNav,ForwardToEnd", "", true, new DiscordComponentEmoji("⏩")));
            }

            var builder = new DiscordWebhookBuilder();
            if (useNavBar == true) { builder.AddComponents(navComponents); }

            //To register a type visit the Tools.FileTypes dictionary and add it there along with it's attributes
            string fileType = contentWithShift.FileUrl.Substring(contentWithShift.FileUrl.LastIndexOf("."));
            if (Tools.FileTypes.ContainsKey(fileType))
            {
                if (Tools.FileTypes[fileType].IsError)
                {
                    builder.AddEmbed(new DiscordEmbedBuilder().WithTitle(@$"({SelectedIndex.ToString()}\{MaxIndex.ToString()})").WithColor(DiscordColor.HotPink).WithFooter("This post uses features not supported by Booru.net and it cannot be displayed" + "\n" + $"({fileType})").Build()).WithContent("");
                }
                else if (Tools.FileTypes[fileType].IsEmbedable)
                {
                    builder.AddEmbed(new DiscordEmbedBuilder().WithTitle(@$"({SelectedIndex.ToString()}\{MaxIndex.ToString()})").WithImageUrl(contentWithShift.FileUrl).WithColor(DiscordColor.HotPink)).WithContent("");
                }
                else
                {
                    builder.WithContent(@$"**({SelectedIndex.ToString()}\{MaxIndex.ToString()})**" + "\n" + contentWithShift.FileUrl);
                }
            }
            else
            {
                builder.AddEmbed(new DiscordEmbedBuilder().WithTitle(@$"({SelectedIndex.ToString()}\{MaxIndex.ToString()})").WithColor(DiscordColor.Red).WithFooter("This file type is not registered. therefore it cannot be displayed" + "\n" + $"({fileType})").Build()).WithContent("");
            }


            Content = content;

            CurrentPost = contentWithShift;

            Client.ComponentInteractionCreated += NavHandle;

            //NSFW FILTRO
            if (contentWithShift.Rating == "Explicit" && !Context.Channel.IsNSFW) { return new DiscordWebhookBuilder().AddEmbed(Tools.BuildErrorEmbed("This post cannot be displayed on a sfw channel")).AddComponents(navComponents).WithContent(@$"**({SelectedIndex.ToString()}\{MaxIndex.ToString()})**"); }

            return builder;
        }

        private async Task NavHandle(DiscordClient s, ComponentInteractionCreateEventArgs e)
        {
            Tools Tools = new Tools();

            if (e.Id == $"{Context.InteractionId.ToString()}PictNav,BackToStart")
            {
                SelectedIndex = 1;
            }
            else if (e.Id == $"{Context.InteractionId.ToString()}PictNav,Back1")
            {
                SelectedIndex--;
            }
            else if (e.Id == $"{Context.InteractionId.ToString()}PictNav,Forward1")
            {
                SelectedIndex++;
            }
            else if (e.Id == $"{Context.InteractionId.ToString()}PictNav,ForwardToEnd")
            {
                SelectedIndex = MaxIndex;
            }
            if (e.Id.StartsWith($"{Context.InteractionId.ToString()}PictNav"))
            {
                var message = await PhotoViewerInit(Content);
                var convertskkkk = Tools.ConvertToMessageBuilder(message);
                await e.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, new DiscordInteractionResponseBuilder(convertskkkk));
            }
        }
    }
}