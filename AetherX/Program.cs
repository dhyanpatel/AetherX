using System;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AetherX {
    class Program {
        private static DiscordClient discord;

        static void Main(string[] args) {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args) {

            Config config = new Config("config.json");

            // Instantiates Discord Client
            discord = new DiscordClient(new DiscordConfiguration {
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug,
                Token = config.GetToken(), // Whatever the path to your config file is goes here
                TokenType = TokenType.Bot
            });

            discord.MessageCreated += async e => {
                if (e.Message.Content.ToLower().StartsWith("ping")) {
                    await e.Message.RespondAsync("Pong!");
                }
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);

        }
    }
}