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
    public class lolzinho : ApplicationCommandModule
    {
        [SlashCommand("lolzinho", "será que kauan vai jogar lolzinho hoje?")]
        public async Task kauan_lolzinho(InteractionContext context)
        {
            await context.DeferAsync();
            Random rng = new Random();
            var num = rng.Next(0, 2);
            switch (num)
            {
                case 0:
                    await context.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(new DiscordEmbedBuilder().WithFooter("tente jogar de novo para o final bom").WithImageUrl("https://c.tenor.com/nOce3oDguSMAAAAd/kauan-n%C3%A3o-vai-ter-lol.gif")));
                    break;
                case 2:
                case 1:
                    await context.EditResponseAsync(new DiscordWebhookBuilder().WithContent("https://tenor.com/view/kauan-hora-do-lol-gif-25127671"));
                    break;
            }
        }
    }
}