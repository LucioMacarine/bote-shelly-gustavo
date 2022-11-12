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
    public class Ari : ApplicationCommandModule
    {
        [SlashCommand("meu_nome_e_ari", "Meu nome é ari e eu...")]
        public async Task ari(InteractionContext context)
        {
            var embed = new DiscordEmbedBuilder();
            Random rng = new Random();
            switch (rng.Next(6))
            {
                case 0:
                    embed.WithTitle("Bad endinging (0/5)");
                    embed.WithColor(DiscordColor.Violet);
                    embed.WithDescription("Meu nome é ari e eu nn tô nem aí");
                    embed.WithFooter("...eu só quero jogar o meu videogame...");
                    break;
                case 1:
                    embed.WithTitle("Good enging (1/5)");
                    embed.WithColor(DiscordColor.Green);
                    embed.WithDescription("Meu nome é ari e eu estou aí");
                    break;
                case 2:
                    embed.WithTitle("Furro endn (2/5)");
                    embed.WithColor(DiscordColor.HotPink);
                    embed.WithDescription("Ari foi sequestrado por hexerade e não pode terminar de jogar o seu videogame");
                    embed.WithImageUrl("https://i.imgur.com/Drf0Sej.png");
                    break;
                case 3:
                    embed.WithTitle("Maccas ending (3/5)");
                    embed.WithColor(DiscordColor.Red);
                    embed.WithDescription("Ari foi ao maccas passar um tempo com a sua família");
                    embed.WithImageUrl("https://cdn.theculturetrip.com/wp-content/uploads/2017/08/768px-maccas.jpg");
                    break;
                case 4:
                    embed.WithTitle("Copypasta endin (4/5)");
                    embed.WithColor(DiscordColor.Purple);
                    embed.WithDescription("Que porra você acabou de me dizer, seu merdinha? Para que você saiba, me formei no topo dos alunos do Japão e sou responsável por ataques cardíacos de criminosos em todo o mundo, e tenho 124.925 mortes confirmadas. Eu me treinei para ser o melhor em uma batalha de inteligência e sou o Deus deste novo mundo. Você não é nada para mim, apenas outro nome. Vou acabar com você de um jeito que você nem consegue compreender, marque minhas malditas palavras. Você acha que pode se safar dizendo essa merda para mim na internet? Pense de novo, filho da puta. Enquanto conversamos, estou entrando em contato com todos os meus seguidores e seu arquivo pessoal está sendo trazido para minha localização agora, então é melhor você se preparar para a tempestade, verme. A tempestade que apaga essa coisinha patética que você chama de vida. Você está morto, garoto. Posso estar em qualquer lugar, a qualquer hora e matá-lo de mais de 2 milhões de maneiras diferentes, e fazer isso apenas com meu simples caderno. Não só fui amplamente treinado para descobrir seu nome, mas também tenho acesso a todo o arsenal de mais de 30 mil seguidores selvagens mundiais e vou usá-los em toda a sua extensão para limpar seu traseiro miserável da face deste continente, seu pequeno merda. Se você pudesse saber que retribuição sagrada sua pequena declaração “inteligente” estava prestes a trazer sobre você, talvez você tivesse segurado sua maldita língua. Mas você não podia, não queria, e agora você está pagando o preço, seu idiota maldito. Vou cagar fúria em cima de você e você vai se afogar nela. Você está morto, garoto.");
                    break;
                case 5:
                    embed.WithTitle("Macarini enging (5/5)");
                    embed.WithColor(DiscordColor.White);
                    embed.WithDescription("O famoso Macarini entrou em uma relação de amizade com Ari e depois de muita briga por causa do sennheiser eles resolveram superar suas diferenças e realmente contribuir para a sociedade");
                    embed.WithFooter("Toda e qualquer semelhança com a realidade é pura coencidência");
                    break;
            }
            await context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AddEmbed(embed.Build()));
        }
    }
}