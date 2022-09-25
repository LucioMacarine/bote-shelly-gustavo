using DSharpPlus;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using Newtonsoft.Json;
using System.Linq;

/*
        ESSE ARQUIVO FAZ OPERAÇÕES INTERNAS E SIMPLIFICA A OPERAÇÃO DO BOT
        POR FAVOR NÃO TOQUE!!!!
        SE TIVER DÚVIDA ENTRE EM CONTATO
*/

namespace shelly_antoneo.tools
{
    public class Tools
    {
        static string RunningPath { get { return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); } }

        public static DiscordEmbed BuildErrorEmbed(string EmbedDescription)
        {
            DiscordEmbedBuilder builder = new DiscordEmbedBuilder()
            .WithDescription(EmbedDescription)
            .WithTitle("Error")
            .WithColor(DiscordColor.Red);

            return builder.Build();
        }

        public static DiscordMessageBuilder ConvertToMessageBuilder(DiscordWebhookBuilder input)
        {
            var builder = new DiscordMessageBuilder();
            builder.AddEmbeds(input.Embeds);
            builder.AddComponents(input.Components);
            if (input.Content != null) builder.WithContent(input.Content);
            return builder;
        }

        public static readonly Dictionary<string, FileTypeAttributes> FileTypes = new Dictionary<string, FileTypeAttributes>()
        {
            [".jpg"] = new FileTypeAttributes(false, true),
            [".png"] = new FileTypeAttributes(false, true),
            [".webp"] = new FileTypeAttributes(false, true),
            [".webm"] = new FileTypeAttributes(false, false),
            [".mp4"] = new FileTypeAttributes(false, false),
            [".swf"] = new FileTypeAttributes(true, false),
            [".gif"] = new FileTypeAttributes(false, true),
            [".jpeg"] = new FileTypeAttributes(false, true)
        };

        public static List<Favorite> MakeFavorites(string[] urls) 
        {
            var favs = new List<Favorite>();
            foreach (var url in urls)
            {
                favs.Add(new Favorite()
                {
                    FileUrl = url,
                    Id = 0,
                    PostUrl = url,
                    Rating = "Safe",
                    source = url,
                    Tags = new string[] { }
                });
            }
            return favs;
        }

        public class FileTypeAttributes
        {
            ///<summary>
            ///<param><c>isError</c> is used when the "feature not supported" box shall be displayed.</param>
            ///<param><c>isEmbedable</c> is used when the file can be embedded by discord.</param>
            ///if both are false the default behaviour is to use the post url instead (ex: videos)
            ///</summary>
            public FileTypeAttributes(bool isError, bool isEmbedable)
            {
                IsError = isError;
                IsEmbedable = isEmbedable;
            }
            public bool IsEmbedable { get; }
            public bool IsError { get; }
        }
    }

    public struct Favorite
    {
        public string FileUrl;

        public string PostUrl;

        public int Id;

        public string source;

        public string[] Tags;

        public string Rating;
    }
}
