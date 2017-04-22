using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode_OS.System.assets
{
    class logo
    {
        internal static void OdeOSlogo(string version)
        {
            Console.WriteLine(" ");
            Console.WriteLine("|------------------------------------------------------------------------------|");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" _____   _____   _____        _____   _____");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("/  _    |  _    | ____|      /  _    /  ___/");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("| | | | | | | | | |__        | | | | | |___");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("| | | | | | | | |  __|       | | | |  ___   ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("| |_| | | |_| | | |___       | |_| |  ___| |   version " + version);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(" _____/ |_____/ |_____|       _____/ /_____/   cree par valentinbreiz");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.WriteLine("|------------------------------------------------------------------------------|");
            Console.WriteLine(" ");
        }
    }
}
