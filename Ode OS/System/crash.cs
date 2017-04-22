using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace Ode_OS.System
{
    class crash
    {
        public static void StopKernel(Exception ex)
        {

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine("THE BLUE SCREEN OF DEATH 0.1");
            Console.WriteLine("ERREUR SYSTEME");
            string ex_message = ex.Message;
            string inner_message = "<aucun>";
            if (ex.InnerException != null)
                inner_message = ex.InnerException.Message;
            Console.WriteLine($@"Erreur : {ex_message}
Message d'exception : {inner_message}");

            Console.WriteLine("Appuyez sur une touche pour redemarrer");
            try
            {
                Console.ReadKey();
            }
            catch
            {

            }
            Sys.Power.Reboot();
        }
    }
}
