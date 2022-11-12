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
    public class BigBangTheory : ApplicationCommandModule
    {
        [SlashCommand("big_bang_theory", "KRL É O BIG BANGH THEORYU D FURROO!!!!jj")]
        public async Task big_bang(InteractionContext context)
        {
            await context.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().AddEmbed(
                new DiscordEmbedBuilder()
                .WithImageUrl("https://static1.e926.net/data/d4/2c/d42cac12a84db64f76775e05cacb09dc.png")
                .WithTitle("phloggers????????????")
                .WithFooter("e ss antoneo eu sei q vc vai perguntar a source fds: pid:3016707")
                .Build()
                ));
        }
    }
}