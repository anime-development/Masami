using Discord.Commands;
using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Masami;

namespace Masami.Commands
{



    public class help : ModuleBase
    {
        private readonly DiscordSocketClient masami;
        private readonly CommandService commands;

        public help(DiscordSocketClient client, CommandService command)
        {
            this.masami = client;
            this.commands = command;
        }

        [Command("help"), Alias("h")]
        [Summary("Help Command")]
        public Task helpAsync()
        {
            var commandList = commands.Commands.ToList();

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("Help Command");

            foreach (var command in commandList)
            {
                embed.AddField($"{BotConfig.PREFIX}{command.Name}", command.Summary ?? "No Description", true);

            }


            embed.WithColor(Color.Purple);

            return ReplyAsync(embed: embed.Build());

        }
    }
}
