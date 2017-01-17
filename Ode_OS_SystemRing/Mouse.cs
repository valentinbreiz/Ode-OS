using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode_OS_SystemRing
{
    public class Mouse
    {
        public Cosmos.HAL.Mouse _mouse;
        int x = 0;
        int y = 0;


        public Mouse()
        {
            _mouse = new Cosmos.HAL.Mouse();
            _mouse.Initialize((uint)Console.WindowWidth, (uint)Console.WindowHeight);
            while (true)
            {
                if (_mouse.X != x || _mouse.Y != y)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write(" ");
                    x = _mouse.X;
                    y = _mouse.Y;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    Console.Write(" ");
                    Console.CursorVisible = false;
                }
            }
        }
    }
}
