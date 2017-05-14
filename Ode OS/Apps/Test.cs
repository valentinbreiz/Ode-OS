/*
* PROJECT:          Ode Operating System Development
* CONTENT:          I don't know.
* PROGRAMMERS:      Valentin Charbonnier <valentinbreiz@gmail.com>
*/

using System;

namespace Ode_OS.Apps
{
    class PrgmTest
    {
        public void MainProgram()
        {
            Console.Clear();
            const string s = "BBFFCCXX";
            foreach (char c in s)
            {
                SwitchChar(c);
            }
            Console.ReadKey(true);
        }
        static void SwitchChar(char input)
        {
            switch (input)
            {
                case 'A':
                    {
                        Console.WriteLine("A");
                        return;
                    }
                case 'B':
                    {
                        Console.WriteLine("B");
                        return;
                    }
                case 'C':
                    {
                        Console.WriteLine("C");
                        return;
                    }
                case 'D':
                    {
                        Console.WriteLine("D");
                        return;
                    }
                case 'E':
                    {
                        Console.WriteLine("E");
                        return;
                    }
                case 'F':
                    {
                        Console.WriteLine("F");
                        return;
                    }
                case 'G':
                    {
                        Console.WriteLine("G");
                        return;
                    }
                case 'H':
                    {
                        Console.WriteLine("H");
                        return;
                    }
                case 'I':
                    {
                        Console.WriteLine("I");
                        return;
                    }
                case 'J':
                    {
                        Console.WriteLine("J");
                        return;
                    }
                case 'K':
                    {
                        Console.WriteLine("K");
                        return;
                    }
                case 'L':
                    {
                        Console.WriteLine("L");
                        return;
                    }
                default:
                    {
                        Console.WriteLine("UNKNOWN");
                        return;
                    }
            }
        }
    }
}
