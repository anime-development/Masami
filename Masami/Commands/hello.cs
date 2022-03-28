using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using MongoDB.Bson.Serialization.Attributes;
using static Masami.Masami;
using MongoDB.Driver;
using Masami.Database;
using Masami.Utils;
using Discord;

namespace Masami.Commands
{
    [Group("hello")]
    public class hello : ModuleBase
    {
        private readonly DiscordSocketClient masami;

        public hello(DiscordSocketClient client)
        {
            this.masami = client;

        }

        [Command]
        public async Task helloAsync()
        {
            var data = await RambotAPI.Run("hello", "english");

            if (data.Too_many_requests != null)
            {
                await Context.Message.ReplyAsync("Ram api ratelimit reached");
                return;
            }

            ReplyAsync(data.text);

            return;
        }
    }
}
