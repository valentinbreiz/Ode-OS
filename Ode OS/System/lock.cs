using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ode_OS.System.assets;

namespace Ode_OS.System
{
    class @lock
    {
        public static void lockpass(string passcode, string version)
        {
            bool unlocked = false;
            while (!unlocked)
            {
                Console.Clear();
                logo.OdeOSlogo(version);
                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                Console.SetCursorPosition(19, 13);
                Console.WriteLine("|---------------------------------------|");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 14);
                Console.WriteLine("|   -Systeme actuellement verouille-    |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 15);
                Console.WriteLine("|                                       |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 16);
                Console.WriteLine("|Mot de passe :                         |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 17);
                Console.WriteLine("|                                       |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 18);
                Console.WriteLine("|              -Confirmer-              |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 19);
                Console.WriteLine("|---------------------------------------|");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 16);
                Console.Write("|Mot de passe : ");
                string pass = Console.ReadLine();
                Console.SetCursorPosition(x, y);

                if (pass == passcode)
                {
                    unlocked = true;
                    Console.Clear();
                }
            }
        }
    }
}
