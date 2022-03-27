using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;

namespace Masami.Commands
{
    internal class embed
    {
        public static async void Run(DiscordSocketClient client, SocketMessage message, params string[] args)
        {
            try
            {
                EmbedBuilder embed = new EmbedBuilder().WithColor(Color.Purple).WithTitle("test");

                embed.WithDescription("Hello \n this is a embed");

                await message.Channel.SendMessageAsync(null, false, embed.Build());

            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }
    }
}
