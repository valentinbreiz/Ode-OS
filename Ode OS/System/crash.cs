/*
* PROJECT:          Ode Operating System Development
* CONTENT:          The Blue Screen of Death
* PROGRAMMERS:      Valentin Charbonnier <valentinbreiz@gmail.com>
*/

using System;
using Sys = Cosmos.System;

namespace Ode_OS.System
{
    class crash
    {
        public static void StopKernel(Exception ex)
        {
            
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine("ERREUR SYSTEME                                     THE BLUE SCREEN OF DEATH 0.2");
            Console.WriteLine("");
            string ex_message = ex.Message;
            string inner_message = "<aucune>";
            if (ex.InnerException != null)
                inner_message = ex.InnerException.Message;
            Console.WriteLine($@"Message d'exception : {ex_message}
Erreur : {inner_message}");
            Console.WriteLine("Appuyez sur une touche pour redemarrer");
            Console.ReadKey();
            Sys.Power.Reboot();
        }
    }
}
