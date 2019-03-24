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

        /// <summary>
        /// Retrieves the Bot Token so we can initialize the Bot.
        /// </summary>
        /// <param name="path">The path to your configuration File</param>
        /// <returns>Bot Token</returns>
        private static string GetToken(string path) {
            JObject jObject = JObject.Parse(File.ReadAllText(path));

            return jObject.GetValue("token").ToString();
        }

        static async Task MainAsync(string[] args) {

            // Instantiates Discord Client
            discord = new DiscordClient(new DiscordConfiguration {
                Token = GetToken("config.json"), // Whatever the path to your config file is goes here
                TokenType = TokenType.Bot
            });

            discord.MessageCreated += async e => {
                if (e.Message.Content.ToLower().StartsWith("ping")) {
                    await e.Message.RespondAsync("Pong!");
                    Console.WriteLine("Ponging");
                }
            };
            await discord.ConnectAsync();
            await Task.Delay(-1);

        }
    }
}