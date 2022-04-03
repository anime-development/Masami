using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masami.Utils
{
    public class logs
    {
        private const string filename = "last_session_logs.txt";
        public logs()
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }

        public void logtofile(string tolog)
        {
            File.AppendAllText(filename, tolog + Environment.NewLine);
        }
    }
}
