using Discord.Commands;
using Masami.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masami.Events
{
    [PreInitialize]
    public class CommandLogEvent
    {
        private readonly logs logs;
        public CommandLogEvent(CommandService commands, logs logged)
        {
            commands.Log += Commands_Log;
            this.logs = logged;
        }

        private Task Commands_Log(Discord.LogMessage arg)
        {
            Console.WriteLine(arg);

            logs.logtofile(arg.ToString());

            return Task.CompletedTask;
        }
    }
}
