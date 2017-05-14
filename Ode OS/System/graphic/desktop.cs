/*
* PROJECT:          Ode Operating System Development
* CONTENT:          Test with canvas.
* PROGRAMMERS:      Valentin Charbonnier <valentinbreiz@gmail.com>
*/

using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
//using Ode_OS_System;

namespace Ode_OS.System.graphic
{

    class desktop
    {
        Canvas canvas;
        //MouseDriver m;
        Sys.VBEScreen VBE;
        bool startmenu = false;

        public void Init()
        {
            Console.WriteLine("Initialisation du driver video...");
            Console.WriteLine("Si vous voyez ce texte c'est qu'il y a une erreur !");

            canvas = FullScreenCanvas.GetFullScreenCanvas();
            canvas.Mode = new Mode(1280, 720, ColorDepth.ColorDepth32);
            canvas.Clear(Color.White);

            Pen pen = new Pen(Color.Blue);

            Console.WriteLine("Driver charge !");

            try
            {

                pen.Color = Color.DarkCyan;

                DrawStringA("A", "NONE", Color.Blue, 100, 100);
                DrawStringB("A", "NONE", Color.Red, 106, 100);
                DrawStringC("A", "NONE", Color.Magenta, 112, 100);
                DrawStringD("A", "NONE", Color.Violet, 118, 100);
                DrawStringE("A", "NONE", Color.Green, 124, 100);
                DrawStringF("A", "NONE", Color.Gray, 130, 100);
                DrawStringG("A", "NONE", Color.DarkBlue, 136, 100);
                DrawStringH("A", "NONE", Color.Brown, 142, 100);
                DrawStringI("A", "NONE", Color.Black, 148, 100);
                DrawStringJ("A", "NONE", Color.Green, 154, 100);
                DrawStringK("A", "NONE", Color.Violet, 160, 100);
                DrawStringL("A", "NONE", Color.Pink, 166, 100);
                DrawStringM("A", "NONE", Color.Blue, 172, 100);
                DrawStringN("A", "NONE", Color.Green, 178, 100);
                DrawStringO("A", "NONE", Color.Violet, 184, 100);
                DrawStringP("A", "NONE", Color.DarkBlue, 190, 100);
                DrawStringQ("A", "NONE", Color.Brown, 196, 100);


                canvas.DrawFilledRectangle(pen, 0, 690, 30, 1279);
                pen.Color = Color.LightGray;
                canvas.DrawFilledRectangle(pen, 4, 694, 22, 22);
                DrawStringO("A", "NONE", Color.Black, 6, 702);
                DrawStringD("A", "NONE", Color.Black, 12, 702);
                DrawStringE("A", "NONE", Color.Black, 18, 702);

                int lastX = 1, lastY = 1;
                //m = new MouseDriver();
                //m.init(1280, 720);

                
                while (true)
                {
                    pen.Color = Color.Black;

                    //canvas.DrawPoint(pen, lastX, lastY);
                    //lastX = m.getX(); lastY = m.getY();
                    //canvas.DrawPoint(pen, m.getX(), m.getY());

                    //canvas.DrawLine(pen, m.getX(), m.getY(), m.getX() + 6, m.getY());
                    //canvas.DrawLine(pen, m.getX(), m.getY(), m.getX(), m.getY() + 6);
                    //canvas.DrawLine(pen, m.getX(), m.getY(), m.getX() + 6, m.getY() + 6);

                    StartMenu();
                }
            }
            catch (Exception e)
            {
                canvas.Clear();
                Console.Clear();

                Console.WriteLine("Error lors de l'ecriture des formes!");
                Console.WriteLine(e);
            }
        }

        public void StartMenu(){

            Pen pen = new Pen(Color.DarkCyan);

            ConsoleKeyInfo pressed_key = Console.ReadKey();

                    switch (pressed_key.Key)
                    {
                case ConsoleKey.X:
                    Sys.Power.Shutdown();
                    break;

                case ConsoleKey.C:
                    Sys.Power.Reboot();
                    break;

                case ConsoleKey.LeftWindows:
                            if (startmenu == false)
                            {
                                pen.Color = Color.DarkCyan;
                                canvas.DrawFilledRectangle(pen, 0, 300, 390, 250);
                                startmenu = true;
                            }
                            else if (startmenu == true)
                            {
                                pen.Color = Color.White;
                                canvas.DrawFilledRectangle(pen, 0, 300, 390, 250);
                                startmenu = false;
                            }
                            break; 
                    }
            StartMenu();
        }

        public void DrawStringA(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x, y + 1, x, y + 7);
            canvas.DrawLine(pen, x + 4, y + 1, x + 4, y + 7);

            canvas.DrawLine(pen, x + 1, y, x + 4, y);
            canvas.DrawLine(pen, x + 1, y + 4, x + 4, y + 4);
        }
        public void DrawStringB(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x, y, x, y + 7);
            canvas.DrawLine(pen, x, y, x + 4, y);
            canvas.DrawLine(pen, x, y + 3, x + 4, y + 3);
            canvas.DrawLine(pen, x, y + 6, x + 4, y + 6); //E

            canvas.DrawLine(pen, x + 4, y + 1, x + 4, y + 3);
            canvas.DrawLine(pen, x + 4, y + 4, x + 4, y + 6);
        }
        public void DrawStringC(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x, y + 1, x, y + 6);
            canvas.DrawLine(pen, x + 1, y, x + 4, y);
            canvas.DrawLine(pen, x + 1, y + 6, x + 4, y + 6);
            canvas.DrawPoint(pen, x + 4, y + 1);
            canvas.DrawPoint(pen, x + 4, y + 5);
        }
        public void DrawStringD(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x, y, x, y + 7);
            canvas.DrawLine(pen, x, y, x + 3, y);
            canvas.DrawLine(pen, x, y + 6, x + 3, y + 6);
            canvas.DrawPoint(pen, x + 3, y + 1);
            canvas.DrawPoint(pen, x + 3, y + 5);
            canvas.DrawLine(pen, x + 4, y + 2, x + 4, y + 5);
        }
        public void DrawStringE(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x, y, x, y + 7);
            canvas.DrawLine(pen, x, y, x + 5, y);
            canvas.DrawLine(pen, x, y + 3, x + 3, y + 3);
            canvas.DrawLine(pen, x, y + 6, x + 5, y + 6); //E
        }
        public void DrawStringF(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x, y, x, y + 7);
            canvas.DrawLine(pen, x, y, x + 5, y);
            canvas.DrawLine(pen, x, y + 3, x + 3, y + 3);
        }
        public void DrawStringG(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x, y + 1, x, y + 6);
            canvas.DrawLine(pen, x + 1, y, x + 4, y);
            canvas.DrawLine(pen, x + 1, y + 6, x + 4, y + 6);
            canvas.DrawPoint(pen, x + 4, y + 1);
            canvas.DrawLine(pen, x + 4, y + 3, x + 4, y + 6);
            canvas.DrawLine(pen, x + 2, y + 3, x + 4, y + 3);
            canvas.DrawPoint(pen, x + 2, y + 4);
        }
        public void DrawStringH(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x, y, x, y + 7);
            canvas.DrawLine(pen, x + 4, y, x + 4, y + 7);

            canvas.DrawLine(pen, x + 1, y + 3, x + 4, y + 3);
        }
        public void DrawStringI(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x + 2, y, x + 2, y + 7);
            canvas.DrawLine(pen, x + 1, y, x + 4, y);
            canvas.DrawLine(pen, x + 1, y + 6, x + 4, y + 6);
        }
        public void DrawStringJ(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x + 2, y, x + 2, y + 6);
            canvas.DrawLine(pen, x + 1, y, x + 4, y);
            canvas.DrawPoint(pen, x + 1, y + 6);
            canvas.DrawPoint(pen, x, y + 5);
        }
        public void DrawStringK(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x, y, x, y + 7);
            canvas.DrawLine(pen, x, y + 3, x + 3, y + 3);
            canvas.DrawPoint(pen, x + 3, y + 2);
            canvas.DrawPoint(pen, x + 3, y + 4);
            canvas.DrawLine(pen, x + 4, y, x + 4, y + 2);
            canvas.DrawLine(pen, x + 4, y + 5, x + 4, y + 7);
        }
        public void DrawStringL(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x, y, x, y + 7);
            canvas.DrawLine(pen, x, y + 6, x + 5, y + 6); //E
        }
        public void DrawStringM(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x, y, x, y + 7);
            canvas.DrawLine(pen, x + 4, y, x + 4, y + 7);
            canvas.DrawPoint(pen, x + 1, y + 1);
            canvas.DrawPoint(pen, x + 2, y + 2);
            canvas.DrawPoint(pen, x + 3, y + 1);
        }
        public void DrawStringN(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x, y, x, y + 7);
            canvas.DrawLine(pen, x + 4, y, x + 4, y + 7);
            canvas.DrawLine(pen, x, y + 2, x + 4, y + 6);
        }
        public void DrawStringO(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x, y + 1, x, y + 6);
            canvas.DrawLine(pen, x + 1, y, x + 4, y);
            canvas.DrawLine(pen, x + 1, y + 6, x + 4, y + 6);
            canvas.DrawLine(pen, x + 4, y + 1, x + 4, y + 6);
        }
        public void DrawStringP(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x, y, x, y + 7);
            canvas.DrawLine(pen, x + 1, y, x + 4, y);
            canvas.DrawLine(pen, x + 1, y + 3, x + 4, y + 3);
            canvas.DrawLine(pen, x + 4, y + 1, x + 4, y + 3);
        }
        public void DrawStringQ(String str, String aFont, Color brush, int x, int y)
        {
            Pen pen = new Pen(brush);
            canvas.DrawLine(pen, x, y + 1, x, y + 6);
            canvas.DrawLine(pen, x + 1, y, x + 4, y);
            canvas.DrawLine(pen, x + 1, y + 6, x + 5, y + 6);
            canvas.DrawLine(pen, x + 4, y + 1, x + 4, y + 7);
            canvas.DrawPoint(pen, x + 2, y + 4);
            canvas.DrawPoint(pen, x + 3, y + 5);
        }
    }
}
