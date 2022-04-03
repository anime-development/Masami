using Discord;
using Discord.WebSocket;
using Masami.Utils;
using Discord.Interactions;

namespace Masami.Events
{
    [PreInitialize]
    public class DiscordReadyEvent
    {
        private readonly DiscordSocketClient masami;
        private readonly InteractionService _commands;

        public DiscordReadyEvent(DiscordSocketClient client, InteractionService commands)
        {
            client.Ready += Client_Ready;

            masami = client;
            _commands = commands;
        }

        public async Task Client_Ready()
        {
            await masami.SetGameAsync($"{Settings.BotConfig.VERSION}");
            await masami.SetStatusAsync(UserStatus.DoNotDisturb);

#if DEBUG
            var cmd = await _commands.RegisterCommandsToGuildAsync(936050113602793483);

#else
            await _commands.RegisterCommandsGloballyAsync();
#endif

            Console.WriteLine("Ready");
        }
    }
}