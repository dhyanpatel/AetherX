﻿using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;

namespace AetherX {
    class Program {
        private static DiscordClient discord;
        private static CommandsNextModule commands;

        static void Main(string[] args) {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args) {

            Config config = new Config("config.json");
            

            // Instantiates Discord Client
            discord = new DiscordClient(new DiscordConfiguration {
                Token = config.GetToken(), // Whatever the path to your config file is goes here
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });
            

            discord.MessageCreated += async e => {
                if (e.Message.Content.ToLower().StartsWith("ping")) {
                    await e.Message.RespondAsync("Pong!");
                }
            };
            
            commands = discord.UseCommandsNext(new CommandsNextConfiguration {
                StringPrefix = "!"
            });
            
            commands.RegisterCommands<BaseCommands>();
            
            
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}