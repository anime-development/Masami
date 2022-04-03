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
using Discord.Interactions;

namespace Masami.Commands
{

    public class hello : InteractionModuleBase
    {
        private readonly DiscordSocketClient masami;

        public hello(DiscordSocketClient client)
        {
            this.masami = client;

        }


        [SlashCommand("hello", "Gets a hello")]

        public async Task helloAsync()
        {
            var data = await RambotAPI.Run("hello", "english");

            if (data.Too_many_requests != null)
            {
                await RespondAsync("Ram api ratelimit reached", ephemeral: true);
                return;
            }

            RespondAsync(data.text);

            return;
        }
    }
}
