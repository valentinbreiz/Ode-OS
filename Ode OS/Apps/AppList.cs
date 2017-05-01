using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ode_OS.Apps
{
    class AppList
    {
        public void MainProgram()
        {
            Console.WriteLine("Programmes disponibles :");
            Console.WriteLine("- Parametres v" + PrgmParametres.prgm_version);
            Console.WriteLine("- Liquid v" + PrgmNano.prgm_version);
            Console.WriteLine("- Snake v" + PrgmSnake.prgm_version + " (ne fonctionne pas)");
            Console.WriteLine("- Ode Studio v" + PrgmOdeStudio.prgm_version);
            Console.WriteLine("- Test");
        }
    }
}
