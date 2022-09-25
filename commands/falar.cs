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
    [SlashCommandGroup("falar", "imita uma pessoa falar sla descrição lixo")]
    public class speak_group : ApplicationCommandModule 
    {
        public DiscordClient client { private get; set; }

        [SlashCommand("Shelly", "manda o shellio falar alguma coisa estúpida")]
        public async Task speak_shelly(InteractionContext context, [Option("mensagem", "a mensagem que o shellio vai falar")] string message) 
        {
            Tools tools = new Tools();
            await context.DeferAsync(true);
            var amessage = new DiscordWebhookBuilder().WithContent(message).WithAvatarUrl("https://cdn.discordapp.com/avatars/798687278263304254/0e2718f6b863d740b46736a1fe3dd7dc.png").WithUsername("! Shelly");
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

        [SlashCommand("Antoneo", "manda o antoneo falar alguma coisa estúpida")]
        public async Task speak_antoneo(InteractionContext context, [Option("mensagem", "a mensagem que o antoneo vai falar")] string message)
        {
            Tools tools = new Tools();
            await context.DeferAsync(true);
            var amessage = new DiscordWebhookBuilder().WithContent(message).WithAvatarUrl("https://cdn.discordapp.com/avatars/563448056125587457/9e09f7e7f8b07ac859858a5352955224.png").WithUsername("guzavoo");
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

        [SlashCommand("Lucyuwu", "manda o Lucywuuw falar alguma coisa muito inteligente e compreensível")]
        public async Task speak_lucyuwu(InteractionContext context, [Option("mensagem", "a mensagem que o lindo lucyuwu vai falar")] string message)
        {
            Tools tools = new Tools();
            await context.DeferAsync(true);
            var amessage = new DiscordWebhookBuilder().WithContent(message).WithAvatarUrl("https://cdn.discordapp.com/avatars/911388263967752223/ab069340c6e0a0f8c95b6b577f3a00e3.png").WithUsername("Lucyuwu");
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