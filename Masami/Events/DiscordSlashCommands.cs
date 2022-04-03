using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Masami.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masami.Events
{
    [PreInitialize]
    public class DiscordSlashCommands
    {
        private readonly DiscordSocketClient masami;
        private readonly InteractionService _commands;
        private readonly IServiceProvider _services;

        public DiscordSlashCommands(DiscordSocketClient client, InteractionService commands, IServiceProvider service)
        {
            _commands = commands;
            _services = service;
            masami = client;

            masami.InteractionCreated += Client_InteractionCreadted;
            _commands.SlashCommandExecuted += Client_SlashCommandExecuted;
        }


        private async Task Client_InteractionCreadted(SocketInteraction interaction)
        {
            try
            {
                using var scope = _services.CreateScope();

                var ctx = new SocketInteractionContext(masami, interaction);

                await _commands.ExecuteCommandAsync(ctx, scope.ServiceProvider);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                // if (interaction.Type == InteractionType.ApplicationCommand)
                // await interaction.GetOriginalResponseAsync().ContinueWith(async (msg) => await msg.Result.DeleteAsync());
            }
        }

        private async Task Client_SlashCommandExecuted(SlashCommandInfo cmd, IInteractionContext ctx, IResult result)
        {
            if (result.IsSuccess) return;

            var output = new StringBuilder();

            switch (result.Error)
            {
                default:
                    Console.WriteLine(result.Error);
                    break;

            }

            await ctx.Interaction.RespondAsync(output.ToString(), ephemeral: true);
        }
    }
}
