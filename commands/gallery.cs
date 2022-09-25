using DSharpPlus;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using DSharpPlus.Entities;
using shelly_antoneo.tools;

namespace shelly_antoneo.commands
{
    public class galleries : ApplicationCommandModule 
    {
        public DiscordClient client { private get; set; }

        [SlashCommand("galeria", "imagens do lindo casalzinho")]
        public async Task gifgallery(InteractionContext context) 
        {
            await context.DeferAsync();
            var viewer = new PhotoViewer(context, client);
            var pics = Tools.MakeFavorites(new string[]
            {
                "https://i.imgur.com/lFVUTf2.gif",
                "https://i.imgur.com/6n2fLYF.gif",
                "https://i.imgur.com/ScJAIRC.gif",
                "https://i.imgur.com/aYCgUcI.gif",
                "https://i.imgur.com/wfA8MUK.gif",
            });
            var message = await viewer.PhotoViewerInit(pics.ToList<Favorite>(), true);
            await context.EditResponseAsync(message);
        }
    }
}