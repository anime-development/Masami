using Discord;
using Discord.WebSocket;
using Masami.Utils;

namespace Masami.Events
{
    [PreInitialize]
    public class DiscordReadyEvent
    {
        private readonly DiscordSocketClient masami;

        public DiscordReadyEvent(DiscordSocketClient client)
        {
            client.Ready += Client_Ready;

            masami = client;
        }

        public async Task Client_Ready()
        {
            await masami.SetGameAsync($"m.help | {Settings.BotConfig.VERSION}");
            await masami.SetStatusAsync(UserStatus.DoNotDisturb);

            Console.WriteLine("Ready");
        }
    }
}