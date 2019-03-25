using System.Threading.Tasks;
using AetherX.HelperFiles;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace AetherX.GameCommands {
    public class RockPaperScissors {

        [Command("rps")]
        public async Task RPS(CommandContext ctx, string choice) {
            int computer =
                ThreadLocalRandom.Instance.Next(3); // https://codeblog.jonskeet.uk/2009/11/04/revisiting-randomness/
            int player;
            switch (choice.ToLower()) {
                case "rock":
                    player = 0;
                    break;
                case "paper":
                    player = 1;
                    break;
                case "scissors":
                    player = 2;
                    break;
                default:
                    await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                        .WithColor(DiscordColor.Red)
                        .WithTitle("Invalid Response")
                        .WithDescription($"\"{choice}\" is not a valid Ressponse")
                        .WithAuthor(ctx.User.Username, null, ctx.User.AvatarUrl));
                    return;
            }

            if (player == computer) {
                await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                    .WithColor(DiscordColor.Gold)
                    .WithTitle("It's a Tie!")
                    .AddField("Computer", choice, true)
                    .AddField("Player", choice, true)
                    .WithAuthor(ctx.User.Username, null, ctx.User.AvatarUrl));
                
            } else if (player == 0 && computer == 1) {
                await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                    .WithColor(DiscordColor.Red)
                    .WithTitle("You Lose!")
                    .AddField("Computer", "paper", true)
                    .AddField("Player", choice, true)
                    .WithFooter("Paper covers Rock")
                    .WithAuthor(ctx.User.Username, null, ctx.User.AvatarUrl));

            } else if (player == 0 && computer == 2) {
                await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                    .WithColor(DiscordColor.Green)
                    .WithTitle("You Win!")
                    .AddField("Computer", "scissors", true)
                    .AddField("Player", choice, true)
                    .WithFooter("Rock smashes Scissors")
                    .WithAuthor(ctx.User.Username, null, ctx.User.AvatarUrl));

            } else if (player == 1 && computer == 0) {
                await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                    .WithColor(DiscordColor.Green)
                    .WithTitle("You Win!")
                    .AddField("Computer", "rock", true)
                    .AddField("Player", choice, true)
                    .WithFooter("Paper covers Rock")
                    .WithAuthor(ctx.User.Username, null, ctx.User.AvatarUrl));

            } else if (player == 1 && computer == 2) {
                await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                    .WithColor(DiscordColor.Red)
                    .WithTitle("You Lose!")
                    .AddField("Computer", "scissors", true)
                    .AddField("Player", choice, true)
                    .WithFooter("Scissors cuts Paper")
                    .WithAuthor(ctx.User.Username, null, ctx.User.AvatarUrl));

            } else if (player == 2 && computer == 0) {
                await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                    .WithColor(DiscordColor.Red)
                    .WithTitle("You Lose!")
                    .AddField("Computer", "scissors", true)
                    .AddField("Player", choice, true)
                    .WithFooter("Rock smashes Scissors")
                    .WithAuthor(ctx.User.Username, null, ctx.User.AvatarUrl));

            } else if (player == 2 && computer == 1) {
                await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                    .WithColor(DiscordColor.Green)
                    .WithTitle("You Win!")
                    .AddField("Computer", "paper", true)
                    .AddField("Player", choice, true)
                    .WithFooter("Scissors cuts Paper")
                    .WithAuthor(ctx.User.Username, null, ctx.User.AvatarUrl));

            } else {
                await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                    .WithColor(DiscordColor.Red)
                    .WithTitle("ERROR")
                    .WithDescription("Something went wrong! Sorry :(")
                    .WithAuthor(ctx.User.Username, null, ctx.User.AvatarUrl));
            }
        }
    }
}