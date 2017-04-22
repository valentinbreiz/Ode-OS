using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Ode_OS.Apps

{

    class PgrmMicrotxt
    {
        public static string adr = @"0:\File.txt";
        
        public static void init()

        {
            Console.Clear();
            Console.WriteLine("###############################################################################");
            Console.WriteLine("# Quitter : F12   Informations : F2                    Microtxt Version 1.1.1 #");
            Console.WriteLine("# Nouveau : F11   Sauvegarder  : F1                                           #");
            Console.WriteLine("###############################################################################");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("*                                                                             *");
            Console.WriteLine("###############################################################################");
            Console.CursorTop = 4;
            Console.CursorLeft = 1;
            main();
        }

        public static void main()
        {

            string current_directory = "0:\\";

            ConsoleKeyInfo pressed_key = Console.ReadKey(); // read keystroke

            switch (pressed_key.Key)

            {
                case ConsoleKey.UpArrow: //Move cursor up
                    if (Console.CursorTop > 4)
                    {
                        Console.CursorTop = Console.CursorTop - 1;
                    }
                    break;

                case ConsoleKey.DownArrow: //Move cursor down
                    if (Console.CursorTop < 22)
                    {
                        Console.CursorTop = Console.CursorTop + 1;
                    }
                    break;

                case ConsoleKey.LeftArrow: //Move cursor left
                    if (Console.CursorLeft > 1)
                    {
                        Console.CursorLeft = Console.CursorLeft - 1;
                    }
                    break;

                case ConsoleKey.RightArrow: //Move cursor right
                    if (Console.CursorLeft < 77)
                    {
                        Console.CursorLeft = Console.CursorLeft + 1;
                    }
                    break;

                case ConsoleKey.Enter: //Start at the beggining of a new line
                    if (Console.CursorTop < 22)
                    {
                        Console.CursorTop = Console.CursorTop + 1;
                        Console.CursorLeft = 1;
                    }
                    break;
                case ConsoleKey.Backspace: //Remove characters
                    if (Console.CursorLeft > 1)
                    {
                        Console.CursorLeft = Console.CursorLeft - 1;
                        Console.Write(" ");
                        Console.CursorLeft = Console.CursorLeft - 1;
                    }
                    break;

                case ConsoleKey.F11: //Create a new document
                    Console.Clear();
                    init();
                    break;

                case ConsoleKey.F12: //Closes out of tdit
                    Console.Clear();
                    Console.WriteLine("Appuyez sur F12 a nouveau si vous voyez ceci."); // Kinda fixes it, bot not all the way.
                    return;

                case ConsoleKey.F1:
                    string testo = pressed_key.KeyChar.ToString();

                    var f = File.Create(current_directory + "test.txt");
                    f.Close();
                    File.WriteAllText(current_directory + "test.txt", testo);

                    Console.Clear();
                    return;


            }
            main();
        }
    }
}