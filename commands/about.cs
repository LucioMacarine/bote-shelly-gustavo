using DSharpPlus;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using DSharpPlus.Entities;

namespace shelly_antoneo.commands
{
    public class AboutMozilla : ApplicationCommandModule
    {
        public DiscordClient client { private get; set; }

        [SlashCommand("about", "sobre esse bot bizarro")]
        public async Task About(InteractionContext Context)
        {
            await Context.DeferAsync();
            var embed = new DiscordEmbedBuilder()
            .WithAuthor("Lucyuwusysyssy", iconUrl: "https://cdn.discordapp.com/avatars/911388263967752223/ab069340c6e0a0f8c95b6b577f3a00e3.png")
            .WithTitle("1 aninho de namoro entre o shellio e o antoneo wuwuuuw")
            .WithDescription("descrição do embed")
            .AddField("About", "Feito por lucywiwueuwqeiqwui para comemorar o aniversário de namoro do antoneo e do shelly")
            .AddField("Qual diabos é o propósito desse bagui?", "O status do shelly me deixou hypado por 8 dias pra esse dia damn you")
            .AddField("O Sennheiser vai participar no evento?", "o nosso time de relações internacionais nn consegui fazer ele compareçer 😔😔😔")
            .AddField("Quantos fields pode ter um embed?", "Vamo vê carambakkkkk")
            .WithFooter("muitas felicidades para o antoneo gustavo e o outro cara lá q o apelido é shellykkkkkkkkkk")
            .Build();
            var message = new DiscordWebhookBuilder().AddEmbed(embed);
            await Context.EditResponseAsync(message);
        }
    }
}