using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode_OS.System.assets
{
    class windows
    {
        internal static void Windows_password(string title, string textboxshowed, string textboxedited, string button)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.SetCursorPosition(19, 13);
            Console.WriteLine("|---------------------------------------|");
            Console.SetCursorPosition(x, y);

            Console.SetCursorPosition(19, 14);
            Console.WriteLine("|" + title + "|");
            Console.SetCursorPosition(x, y);

            Console.SetCursorPosition(19, 15);
            Console.WriteLine("|                                       |");
            Console.SetCursorPosition(x, y);

            Console.SetCursorPosition(19, 16);
            Console.WriteLine("|" + textboxshowed + "|");
            Console.SetCursorPosition(x, y);

            Console.SetCursorPosition(19, 17);
            Console.WriteLine("|                                       |");
            Console.SetCursorPosition(x, y);

            Console.SetCursorPosition(19, 18);
            Console.WriteLine("|" + button + "|");
            Console.SetCursorPosition(x, y);

            Console.SetCursorPosition(19, 19);
            Console.WriteLine("|---------------------------------------|");
            Console.SetCursorPosition(x, y);

            Console.SetCursorPosition(19, 16);
            Console.Write("|" + textboxedited);
            string text = Console.ReadLine();
            Console.SetCursorPosition(x, y);
            Result(text);
        }
        internal static string Result(string result) //use string instead of void
        {
            return result;
        }
    }
}
