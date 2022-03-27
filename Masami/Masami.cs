using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;

namespace Masami
{
   class Masami
    {
        public static void Main(string[] args) => new Masami().MainAsync().GetAwaiter().GetResult();

        public static DiscordSocketClient? masami;

        public static string prefix = "m.";


        


        public async Task MainAsync()
        {
           
            LoadENV();
            
            masami = new DiscordSocketClient();
            masami.Ready += async () =>
            {
                await masami.SetGameAsync($"m.help");
                await masami.SetStatusAsync(UserStatus.DoNotDisturb);
                Console.WriteLine("test");
                Console.WriteLine("Ready");
            };

            masami.MessageReceived += async (message) =>
            {
                if (message.Author.IsBot) return;
                if (!message.Content.StartsWith(prefix)) return;

                string[] args = message.Content.Replace(prefix, "").Trim().Split(" ");

                string command = args[0];

                if(command != "bye") await message.Channel.TriggerTypingAsync();

                await Task.Delay(5000);

                switch (command)
                {
                    case "hello":
                        Commands.hello.Run(masami, message, args);

                        break;
                    case "embed":

                       Commands.embed.Run(masami, message, args);

                        break;
                    case "bye":
                        Commands.bye.Run(masami, message, args);
                        

                        break;
                };
            };

            await masami.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("TOKEN"));
            await masami.StartAsync();
            
            await Task.Delay(Timeout.Infinite);
        }  
        public static void LoadENV()
        {
            if (!File.Exists("./.env")) return;

            foreach (var line in File.ReadAllLines("./.env"))
            {
                var parts = line.Split('=', (char)StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2) continue;

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }
    }

   
}

