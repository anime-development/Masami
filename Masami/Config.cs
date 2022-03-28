using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpConfig;

namespace Masami
{
    public class Settings
    {
        public static BotConfig BotConfig;
    }

    public struct BotConfig
    {
        public static string PREFIX = "m.";

        public string TOKEN;
        public string URL;
        public string VERSION;

        public static void Load()
        {
            BotConfig config = new()
            {
                TOKEN = "",
                URL = "",
                VERSION = ""
            };

            var iniFile = Configuration.LoadFromFile("./config.ini");

            try
            {
                var configContent = iniFile["CONFIG"];

                config.TOKEN = configContent["TOKEN"].StringValue;
                config.URL = configContent["URL"].StringValue;
                config.VERSION = configContent["Version"].StringValue;

                Settings.BotConfig = config;

                Console.WriteLine("Bot: Config Loaded\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bot: Config Unable to load! \n{ex}\n");
            }
        }
    }
}
