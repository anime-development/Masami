using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;

namespace Masami.Commands
{
    class hello
    {
        public static async void Run(DiscordSocketClient client, SocketMessage message, params string[] args)
        {
            try
            {
                var text = await Utils.api.Run("hello", "english");

               if(text.Too_many_requests != null)
                {

                    await message.Channel.SendMessageAsync("ratelimit reached");

                    Console.WriteLine(text.Too_many_requests);

                    return;
                }

                message.Channel.SendMessageAsync(text.text);

            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        } //                 await message.Channel.SendMessageAsync("Hello how are you");
    }
}
