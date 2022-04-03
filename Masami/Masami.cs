using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Masami.Database;
using Masami.Events;
using Masami.Utils;
using Discord.Interactions;

namespace Masami
{
    public class Masami
    {
        private DiscordSocketClient masami = null;
        private IServiceProvider _services = null;

        private MongoCRUD _db = null;

        public static void Main(string[] args)
            => new Masami().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            Console.Title = "Masami Bot";
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            BotConfig.Load();

            masami = new DiscordSocketClient(new DiscordSocketConfig()
            {
                GatewayIntents = GatewayIntents.AllUnprivileged,
                DefaultRetryMode = RetryMode.AlwaysRetry,
                LogLevel = LogSeverity.Info,
                AlwaysDownloadUsers = true
            });
            var commands = new InteractionService(masami, new()
            {
                DefaultRunMode = Discord.Interactions.RunMode.Sync,
                LogLevel = LogSeverity.Info,
                UseCompiledLambda = true
            });
            _db = new MongoCRUD("masami");

            var collection = new ServiceCollection()
                .AddSingleton(masami)
                .AddSingleton(commands)
                .AddSingleton(_db)
                .AddSingleton<DiscordSlashCommands>()
                .AddSingleton<CommandLogEvent>()
                .AddSingleton<logs>()
                .AddSingleton<DiscordReadyEvent>();

            _services = collection.BuildServiceProvider();

            // Auto-Load events, etc...
            foreach (ServiceDescriptor service in collection)
            {
                if (service.ServiceType.GetCustomAttributes(typeof(PreInitialize), false) == null)
                    continue;

                if (service.ImplementationType == null)
                    continue;

                _services.GetService(service.ImplementationType);
            }
            // end

            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);


            await masami.LoginAsync(TokenType.Bot, Settings.BotConfig.TOKEN);
            await masami.StartAsync();
            await Task.Delay(Timeout.Infinite);
        }
    }
}