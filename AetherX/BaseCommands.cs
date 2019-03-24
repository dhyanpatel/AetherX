using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AetherX.GameCommands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace AetherX {
    public class BaseCommands {
        private Random rnd = new Random();

        [Command("rps")]
        public async Task RPS(CommandContext ctx, string choice) {
            //await ctx.RespondAsync("Testing");
            await RockPaperScissors.RPS(ctx, choice, rnd);
        }
    }
}