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
            Console.WriteLine("*------------------------------------------------------------------------------*");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"  .88888.        dP");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@" d8'   `8b       88");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@" 88     88 .d888b88 .d8888b.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@" 88     88 88'  `88 88ooood8");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@" Y8.   .8P 88.  .88 88.                                  version " + version);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"  `8888P'  `88888P8 `88888P' operating system           cree par valentinbreiz");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.WriteLine("*------------------------------------------------------------------------------*");
            Console.WriteLine(" ");
        }
    }
}
