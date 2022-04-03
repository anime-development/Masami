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
using Discord;
using Discord.Interactions;

namespace Masami.Commands_New
{

    public class ping : InteractionModuleBase
    {
        private readonly DiscordSocketClient masami;
        private readonly MongoCRUD database;

        public ping(DiscordSocketClient client, MongoCRUD db)
        {
            this.masami = client;
            this.database = db;
        }


        [SlashCommand("ping", "Gets the bots ping")]
        public async Task pingAsync()
        {




            var output = new StringBuilder();

            output.AppendFormat($"{masami.Latency}ms");


            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("PONG!");
            embed.WithDescription($"Api Ping: {masami.Latency}ms");
            embed.WithColor(Color.Gold);





            await RespondAsync(embed: embed.Build());

            return;
        }
    }
}
