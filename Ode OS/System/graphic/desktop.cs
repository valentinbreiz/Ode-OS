using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System;

namespace Ode_OS.System.graphic
{

    class desktop
    {
        Canvas canvas;
        

        public void Init()
        {
            Console.WriteLine("Initialisation du driver video...");

            canvas = FullScreenCanvas.GetFullScreenCanvas();

            Console.WriteLine("Driver charge !");

            canvas.Clear(Color.Blue);

            try
            {
                /* A red Point */
                Pen pen = new Pen(Color.Red);
                canvas.DrawPoint(pen, 69, 69);

                /* A GreenYellow horizontal line */
                pen.Color = Color.GreenYellow;
                canvas.DrawLine(pen, 250, 100, 400, 100);

                /* An IndianRed vertical line */
                pen.Color = Color.IndianRed;
                canvas.DrawLine(pen, 350, 150, 350, 250);

                /* A MintCream diagonal line */
                pen.Color = Color.MintCream;
                canvas.DrawLine(pen, 250, 150, 400, 250);

                /* A PaleVioletRed rectangle */
                pen.Color = Color.PaleVioletRed;

               //DrawFilledRectangle(pen, 350, 350, 80, 60); Does not work for now.

                Console.ReadKey();

                /* Let's try to change mode...*/
                canvas.Mode = new Mode(800, 600, ColorDepth.ColorDepth32);

                /* A LimeGreen rectangle */
                pen.Color = Color.LimeGreen;
                canvas.DrawRectangle(pen, 450, 450, 80, 60);

                Console.ReadKey();

                Console.Clear();
            }
            catch (Exception e)
            {
                canvas.Clear();
                Console.Clear();

                Console.WriteLine("Error lors de l'ecriture des formes!");
                Console.WriteLine(e);
            }
        }

        public void DrawFilledRectangle(Pen pen, int x_start, int y_start, int width, int height)
         {
             for (int i = 0; i < width; i++)
             {
                canvas.DrawLine(pen, x_start, y_start, x_start + width, y_start + height);
                i++;
            }
         }
    }
}
