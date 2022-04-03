using Discord.Interactions;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Masami.Utils;

namespace Masami.Commands
{
    public class slap : InteractionModuleBase
    {
        private readonly DiscordSocketClient masami;

        public slap(DiscordSocketClient client)
        {
            this.masami = client;

        }


        [SlashCommand("slap", "Slap a user")]

        public async Task slapAsync(IGuildUser user)
        {
            var data = await RambotAPI.Run("slap");

            if (data == null)
            {
                await RespondAsync("Error!", ephemeral: true);
                return;
            }

            EmbedBuilder embed = new EmbedBuilder();
            embed.WithColor(Color.Purple);
            embed.WithDescription($"{Context.User.Mention} slapped {user.Mention}");
            embed.WithImageUrl(data.url);

            await RespondAsync(embed: embed.Build());
            return;


        }
    }
}
