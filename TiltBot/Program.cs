using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiltBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var twitchBot = new TwitchBot();
            twitchBot.Connect();
            Console.ReadKey();
        }
    }
}
