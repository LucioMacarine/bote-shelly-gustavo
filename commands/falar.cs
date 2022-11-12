using DSharpPlus;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using DSharpPlus.Entities;
using shelly_antoneo.tools;
using System.Linq;

namespace shelly_antoneo.commands
{
    public class speak_group : ApplicationCommandModule 
    {
        public DiscordClient client { private get; set; }

        [SlashCommand("Falar", "manda alguém falar alguma coisa estúpida")]
        public async Task speak_shelly(InteractionContext context, [Option("pessoa", "o doidinho q vai falar essa doidisse aí")] DiscordUser user, [Option("mensagem", "a mensagem que a pessoa vai falar")] string message)
        {
            Tools tools = new Tools();
            await context.DeferAsync(true);
            var amessage = new DiscordWebhookBuilder().WithAvatarUrl(user.AvatarUrl).WithUsername(user.Username).WithContent(message);
            var webhooks = await context.Channel.GetWebhooksAsync();
            if (webhooks.Where(x => x.User == client.CurrentUser).Count() > 0)
            {
                var hook = webhooks.First(x => x.User == client.CurrentUser);
                await hook.ExecuteAsync(amessage);
            }
            else
            {
                var hook = await context.Channel.CreateWebhookAsync("bote shelly & antoneo bagulho");
                await hook.ExecuteAsync(amessage);
            }
            await context.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(new DiscordEmbedBuilder().WithTitle("bagulho feito com sucesso").Build()));
        }
    }
}