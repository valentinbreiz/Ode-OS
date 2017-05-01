using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode_OS.Apps
{
    class PrgmTest
    {
        public void MainProgram()
        {
            Console.Clear();
            Console.WriteLine("Le premier programme 0.1");
            Console.WriteLine("Entrez du texte :");
            var input = Console.ReadLine();
            Console.WriteLine("Vous avez ecrit '" + input + "'");
            Console.WriteLine("Appuyez sur une touche pour quitter le programme");
            Console.ReadKey(true);
        }
    }
}
