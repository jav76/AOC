using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOCHelper
{
    internal class AOCRepo
    {
        private const string SESSION_FILE_PATH = "Resources/Session.txt";
        public static string GetSessionToken()
        {
            using(StreamReader sessionFile = new StreamReader(SESSION_FILE_PATH))
            {
                return sessionFile.ReadToEnd();
            }
        }
    }
}
