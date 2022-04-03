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


namespace Masami.Commands_New
{

    public class ping : ModuleBase
    {
        private readonly DiscordSocketClient masami;
        private readonly MongoCRUD database;

        public ping(DiscordSocketClient client, MongoCRUD db)
        {
            this.masami = client;
            this.database = db;
        }

        [Command("ping")]
        [Summary("Ping Command")]
        public async Task pingAsync()
        {




            var output = new StringBuilder();

            output.AppendFormat($"{masami.Latency}ms");


            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("PONG!");
            embed.WithDescription($"Api Ping: {masami.Latency}ms");
            embed.WithColor(Color.Gold);





            await ReplyAsync(embed: embed.Build());

            return;
        }
    }
}
