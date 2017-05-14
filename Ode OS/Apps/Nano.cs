/*
* PROJECT:          Ode Operating System Development
* CONTENT:          Liquid Text Editor
* PROGRAMMERS:      Valentin Charbonnier <valentinbreiz@gmail.com>
*                   TheCool1James        <kevindai02@outlook.com>
*/

using System;
using System.Collections.Generic;
using System.IO;

namespace Ode_OS.Apps
{
    class PrgmNano
    {
        public static string prgm_version = "0.02";
        char[] line = new char[80]; int pointer = 0;
        List<string> lines = new List<string>();
        string[] final;

        internal void filepath(string currentdirectory)
        {
            Console.Clear();
            
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Liquid Editor v"+ prgm_version+" par TheCool1James                                           ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Nom du fichier : ");
            string filename = Console.ReadLine();
            initNano(filename, currentdirectory);
        }
        internal void initNano(string filename, string currentdirectory)
        {
            Console.Clear();
            drawTopBar();
            Console.SetCursorPosition(0, 1);
            ConsoleKeyInfo c; cleanArray(line);
            while ((c = Console.ReadKey(true)) != null)
            {
                drawTopBar();
                char ch = c.KeyChar;
                if (c.Key == ConsoleKey.Escape)
                    break;
                else if (c.Key == ConsoleKey.F1) 
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Liquid Editor v" + prgm_version + " par TheCool1James                                           ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                    lines.Add(new string(line).TrimEnd()); //Add any unadded lines
                        //listCheck();
                    final = lines.ToArray(); //Store vars
                    string foo = concatString(final); //Get the final text
                        //Console.WriteLine("Here comes the concated text: \n" + foo);
                    File.WriteAllText(currentdirectory + filename, foo); //Write to file
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Le fichier '" + filename + "' a ete sauvegarde dans '" + currentdirectory + "' !");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.ReadKey();
                    break;
                    
                    /*else if(c.Key == ConsoleKey.End)
                    {
                        displayHelp(path);
                    }*/
                }
                else if (c.Key == ConsoleKey.F2)
                {
                    lines.Add(new string(line).TrimEnd()); //Add any unadded lines
                                                           //listCheck();
                    final = lines.ToArray();
                    displayHelp(filename, currentdirectory);
                }

                switch (c.Key)
                {
                    case ConsoleKey.Home: break;
                    case ConsoleKey.PageUp: break;
                    case ConsoleKey.PageDown: break;
                    case ConsoleKey.End: break;
                    //case ConsoleKey.Tab: break;
                    case ConsoleKey.UpArrow: //Move cursor up
                        if (Console.CursorTop > 1)
                        {
                            Console.CursorTop = Console.CursorTop - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow: //Move cursor down
                        if (Console.CursorTop < 23)
                        {
                            Console.CursorTop = Console.CursorTop + 1;
                        }
                        break;
                    case ConsoleKey.LeftArrow: if (pointer > 0) { pointer--; Console.CursorLeft--; } break;
                    case ConsoleKey.RightArrow: if (pointer < 80) { pointer++; Console.CursorLeft++; if (line[pointer] == 0) line[pointer] = ' '; } break;
                    case ConsoleKey.Backspace: deleteChar(); break;
                    case ConsoleKey.Delete: deleteChar(); break;
                    //case ConsoleKey.Tab: deleteChar(); break;
                    case ConsoleKey.Enter:
                        lines.Add(new string(line).TrimEnd()); cleanArray(line); Console.CursorLeft = 0; Console.CursorTop++; pointer = 0;
                        break;
                    default: line[pointer] = ch; pointer++; Console.Write(ch); break; //HERE
                }
            }
            Console.Clear();
        }

        private string concatString(string[] s)
        {
            string t = "";
            if (s.Length >= 1)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    //Console.WriteLine("Lines: " + s.Length);
                    if (!string.IsNullOrWhiteSpace(s[i]))
                        t = string.Concat(t, s[i].TrimEnd(), Environment.NewLine);
                }
            }
            else
                t = s[0];
            t = string.Concat(t, '\0');
            //Console.WriteLine("Concat:\n" + t);
            return t;
        }

        private void cleanArray(char[] c)
        {
            for (int i = 0; i < c.Length; i++)
                c[i] = ' ';
        }

        private void drawTopBar()
        {
            int x = Console.CursorLeft, y = Console.CursorTop;
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Liquid Editor v"+ prgm_version+"              ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[F1]Sauvegarder  [F2]Informations  [ESC]Quitter\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(x, y);
        }

        //Decrease the pointer, decrease the cusor pos by 1, write whitespace, decrease
        //cursor pos by 1 again, replace char in buffer with whitespace
        private void deleteChar()
        {
            if ((Console.CursorLeft >= 1) && (pointer >= 1))
            {
                pointer--; Console.CursorLeft--;
                Console.Write(" "); Console.CursorLeft--;
                line[pointer] = ' ';
            }
        }

        private void listCheck()
        {
            foreach (var s in lines)
                Console.WriteLine(" List: " + s + "\n"); //Works!
        }

        private string[] arrayCheck(string[] s)
        {
            foreach (var ss in s)
            {
                Console.WriteLine(" Line: " + ss + "\n"); //Works!
            }
            return s; //Just return the input...
        }

        public void displayHelp(string filename , string currentdirectory)
        {
            Console.Clear(); cleanArray(line);
            Console.WriteLine("Appuyez sur F1 pour sauvegarder. Appuyez sur Echap pour quitter sans sauvegarder.");
            Console.WriteLine("Files will be overwritten if they exist. If no file exists, one will be");
            Console.WriteLine("created. Right now, nano will not display the contents of the files, so you");
            Console.WriteLine("start with a clean slate every time. Each line is 80 characters long. You");
            Console.WriteLine("cannot edit a line above. You can only edit the current line.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(); initNano(filename, currentdirectory);
        }
    }
}
