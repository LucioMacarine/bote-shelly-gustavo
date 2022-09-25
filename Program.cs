using System;
using System.Threading.Tasks;
using DSharpPlus;
using System.IO;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.SlashCommands;
using Newtonsoft.Json;

namespace shelly_antoneo
{
    class Program
    {
        static string RunningPath { get { return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); } }

        public static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        public static async Task MainAsync()
        {
            if (!File.Exists(Path.Combine(RunningPath, "token.txt"))) Console.WriteLine("amigo faz o seguinte ó: no mesmo diretório onde tá o executavel do bot cria um arquivo chamado \"token.txt\" (sem aspas) e bota o token do bote lá ta ligado?");

            var client = new DiscordClient(new DiscordConfiguration()
            {
                Token = File.ReadAllText(Path.Combine(RunningPath, "token.txt")),
                TokenType = TokenType.Bot,
            });

            client.UseInteractivity(new InteractivityConfiguration()
            {
                Timeout = TimeSpan.FromSeconds(30)
            });

            var services = new ServiceCollection()
            .AddSingleton(client)
            .BuildServiceProvider();

            var slashies = client.UseSlashCommands(new SlashCommandsConfiguration()
            {
                Services = services
            });

            slashies.RegisterCommands<shelly_antoneo.commands.AboutMozilla>();
            slashies.RegisterCommands<shelly_antoneo.commands.galleries>();
            slashies.RegisterCommands<shelly_antoneo.commands.speak_group>();
            slashies.RegisterCommands<shelly_antoneo.commands.lolzinho>();
            slashies.RegisterCommands<shelly_antoneo.commands.juras>();

            await client.ConnectAsync();

            await Task.Delay(-1);
        }
    }
}