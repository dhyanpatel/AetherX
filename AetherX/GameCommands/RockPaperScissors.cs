using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;

namespace AetherX.GameCommands {
    public class RockPaperScissors {

        public static async Task RPS(CommandContext ctx, string choice, Random rnd) {
            int computer = rnd.Next(2);
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
                    await ctx.RespondAsync($"Invalid Response {choice}!");
                    return;
            }

            if (player == computer) {
                await ctx.RespondAsync($"It's a Tie! You both chose {choice}!");
                return;
            }

            if (player == 0 && computer == 1) {
                await ctx.RespondAsync("You Chose Rock. Computer Chose Paper.\n" +
                                       "You Lose!");
            } else if (player == 0 && computer == 2) {
                await ctx.RespondAsync("You Chose Rock. Computer Chose Scissors.\n" +
                                       "You Win!");
            } else if (player == 1 && computer == 0) {
                await ctx.RespondAsync("You Chose Paper. Computer Chose Rock.\n" +
                                       "You Win!");
            } else if (player == 1 && computer == 2) {
                await ctx.RespondAsync("You Chose Paper. Computer Chose Scissors.\n" +
                                       "You Lose!");
            } else if (player == 2 && computer == 0) {
                await ctx.RespondAsync("You Chose Scissors. Computer Chose Rock.\n" +
                                       "You Lose!");
            } else if (player == 2 && computer == 1) {
                await ctx.RespondAsync("You Chose Scissors. Computer Chose Paper.\n" +
                                       "You Win!");
            } else {
                await ctx.RespondAsync("Something went wrong! Sorry :(");
            }
        }
    }
}