/*
* PROJECT:          Ode Operating System Development
* CONTENT:          Logo of Ode operating system.
* PROGRAMMERS:      Valentin Charbonnier <valentinbreiz@gmail.com>
*/

using System;

namespace Ode_OS.System.assets
{
    class logo
    {
        internal static void OdeOSlogo(string version)
        {
            Console.WriteLine(" ");
            Console.WriteLine("|------------------------------------------------------------------------------|");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"   ____  _____  ______");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"  / __ \|  __ \|  ____|");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@" | |  | | |  | | |__   ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@" | |  | | |  | |  __|  ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@" | |__| | |__| | |____                                  version " + version);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"  \____/|_____/|______|  operating system               cree par valentinbreiz");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.WriteLine("|------------------------------------------------------------------------------|");
            Console.WriteLine(" ");
        }
    }
}
