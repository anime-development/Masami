using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

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
                await masami.SetStatusAsync(UserStatus.AFK);
                Console.WriteLine("test");
                Console.WriteLine("Ready");
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

