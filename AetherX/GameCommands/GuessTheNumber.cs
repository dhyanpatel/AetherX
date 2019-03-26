using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AetherX.HelperFiles;
using DSharpPlus.CommandsNext;
using Discord.Addons.Interactive;
using Discord.Commands;
using CommandContext = DSharpPlus.CommandsNext.CommandContext;

namespace AetherX.GameCommands
{   
    public class GuessTheNumber
    {
        [DSharpPlus.CommandsNext.Attributes.Command("gtn")]

        public async Task Gtn(CommandContext ctx, int number)
        {
            int computer = ThreadLocalRandom.Instance.Next(100);
            int guesses = 0;

            await ctx.RespondAsync(computer.ToString());
 
            if (computer == number)
            {
                await ctx.RespondAsync("You guesses it! Nice Job");
            }
            else
            {
                while ((computer != number) || (guesses < 5))
                {
                    if (computer < number)
                    {
                        await ctx.RespondAsync("Go lower. " + (5 - guesses) + " guesses remaining." );
                    }
                    else if (computer > number)
                    {
                        await ctx.RespondAsync("Go higher. " + (5 - guesses) + " guesses remaining.");
                    }

                    string num = Console.ReadLine();
                    number = Int32.Parse(num);
                    
                    guesses++;
                }

                if ((guesses < 5) && (computer == number))
                {
                    
                    await ctx.RespondAsync("You guesses it! Nice Job");
                    
                }
                else if (guesses >= 10)
                {
                    await ctx.RespondAsync("Bad Luck :( Try again later");
                }
            }
            
            await ctx.RespondAsync("The Number was " + computer.ToString());
        }      
}
}