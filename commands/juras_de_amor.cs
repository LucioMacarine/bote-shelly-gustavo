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
    public class juras : ApplicationCommandModule
    {
        [SlashCommand("juras_de_amor", "faça juras de amor para uma pessoa")]
        public async Task juras_de_amor(InteractionContext context, [Option("usuario", "o mlk(a) q vc vai fzr juras de amor para")] DiscordUser user)
        {
            await context.DeferAsync();
            Random rng = new Random();
            var num = rng.Next(0, 6);
            var message = new DiscordWebhookBuilder().WithContent(context.User.Mention + " te fizeram uma jura de amor ó: ");
            var embed = new DiscordEmbedBuilder();
            switch (num)
            {
                case 0:
                    embed.WithAuthor(context.User.Username, iconUrl: context.User.AvatarUrl).WithTitle($"te amo para todo e todo && todo e o todo eo  se=mpre te amoo para vida e todo o sempre");
                    break;
                case 1:
                    embed.WithAuthor(context.User.Username, iconUrl: context.User.AvatarUrl).WithTitle($"eu irei te amar para sempre e nos vamos nos casar e ter 3 filhinos nossa qq eu tô fazendo da minha vida programando esse bot mds");
                    break;
                case 2:
                    embed.WithAuthor(context.User.Username, iconUrl: context.User.AvatarUrl).WithTitle($"queria ser um pescador, mas um pescador não posso ser, pois um pescador pesca peixes, e a piranha que eu quero é você");
                    break;
                case 3:
                    embed.WithAuthor(context.User.Username, iconUrl: context.User.AvatarUrl).WithTitle($"isso não é uma jura de amor vamos cantar tropicália")
                    .AddField("1", "Sobre a cabeça os aviões Sob os meus pés os caminhões Aponta contra os chapadões Meu nariz")
                    .AddField("2", "Eu organizo o movimento Eu oriento o carnaval Eu inauguro o monumento No planalto central do país")
                    .AddField("2", "Viva a Bossa, sa, sa Viva a Palhoça, ça, ça, ça, ça Viva a Bossa, sa, sa Viva a Palhoça, ça, ça, ça, ça")
                    .AddField("3", "O monumento É de papel crepom e prata Os olhos verdes da mulata A cabeleira esconde Atrás da verde mata O luar do sertão").Build();
                    break;
                case 4:
                    embed.WithAuthor(context.User.Username, iconUrl: context.User.AvatarUrl).WithTitle($"ti amo ❤️");
                    break;
                case 6:
                case 5:
                    embed.WithAuthor(context.User.Username, iconUrl: context.User.AvatarUrl).WithTitle($"️você ilumina o meu dia todo dia porque se você não iluminasse não haveria o dia que você ilumina porque não haveria dia para iterar no bagui");
                    break;
            }
            await context.EditResponseAsync(message.AddEmbed(embed));
        }
    }
}