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
        internal static void Windows_info(int vartop, string title, int lines, string textshowed, string button)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.SetCursorPosition(19, vartop);
            Console.WriteLine("|---------------------------------------|");
            Console.SetCursorPosition(x, y);

            Console.SetCursorPosition(19, vartop + 1);
            Console.WriteLine("|" + title + "|");
            Console.SetCursorPosition(x, y);

            Console.SetCursorPosition(19, vartop + 2);
            Console.WriteLine("|                                       |");
            Console.SetCursorPosition(x, y);

            if (lines == 1)
            {

                Console.SetCursorPosition(19, vartop + 3);
                Console.WriteLine("|                                       |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, vartop + 3);
                Console.WriteLine("|" + textshowed);
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, vartop + 4);
                Console.WriteLine("|                                       |");
                Console.SetCursorPosition(x, y);


                Console.SetCursorPosition(19, vartop + 5);
                Console.WriteLine("|" + button + "|");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, vartop + 6);
                Console.WriteLine("|---------------------------------------|");
                Console.SetCursorPosition(x, y);
            }
            if (lines == 2)
            {
                Console.SetCursorPosition(19, vartop + 3);
                Console.WriteLine("|                                       |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, vartop + 4);
                Console.WriteLine("|                                       |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, vartop + 3);
                Console.WriteLine("|" + textshowed);
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, vartop + 5);
                Console.WriteLine("|                                       |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, vartop + 6);
                Console.WriteLine("|" + button + "|");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, vartop + 7);
                Console.WriteLine("|---------------------------------------|");
                Console.SetCursorPosition(x, y);
            }
            if (lines == 3)
            {
                Console.SetCursorPosition(19, vartop + 3);
                Console.WriteLine("|                                       |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, vartop + 4);
                Console.WriteLine("|                                       |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, vartop + 5);
                Console.WriteLine("|                                       |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, vartop + 3);
                Console.WriteLine("|" + textshowed);
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, vartop + 6);
                Console.WriteLine("|                                       |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, vartop + 7);
                Console.WriteLine("|" + button + "|");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, vartop + 8);
                Console.WriteLine("|---------------------------------------|");
                Console.SetCursorPosition(x, y);
            }


        }
        internal static string Result(string result) //Does not work for now.
        {
            return result;
        }
    }
}
