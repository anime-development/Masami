using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;

namespace Masami.Commands
{
    internal class bye
    {
        public static async void Run(DiscordSocketClient masami, SocketMessage message, params string[] args)
        {
            try
            {
                
                if (message.Author.Id != 171373018285735936)
                {
                    
                    await message.Author.SendMessageAsync("I'm not gonna go for you");
                    await message.AddReactionAsync(new Emoji("❌"));
                    return;
                }

                await message.Channel.SendMessageAsync("Bye");
                Console.WriteLine("loging out");
                await masami.LogoutAsync();
                await masami.StopAsync();

            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }
    }
}
