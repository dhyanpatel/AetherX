using System;
using System.Threading.Tasks;
using DSharpPlus;

namespace AetherX {
    class Program {
        private static DiscordClient discord;

        static void Main(string[] args) {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args) {

            // Instantiates Discord Client
            discord = new DiscordClient(new DiscordConfiguration {
                Token = "NTU5MTQ1NjA0MTMxODQ4MjAy.D3hKzg.y4YDKboazuT9JusmrUMk1w4Nams",
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