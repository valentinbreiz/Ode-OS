/*
* PROJECT:          Ode Operating System Development
* CONTENT:          List of apps available.
* PROGRAMMERS:      Valentin Charbonnier <valentinbreiz@gmail.com>
*/

using System;

namespace Ode_OS.Apps
{
    class AppList
    {
        public void MainProgram()
        {
            Console.WriteLine("Programmes disponibles :");
            Console.WriteLine("- Parametres v" + PrgmParametres.prgm_version);
            Console.WriteLine("- Liquid v" + PrgmNano.prgm_version);
            Console.WriteLine("- Snake v" + PrgmSnake.prgm_version);
            Console.WriteLine("- Ode Studio v" + PrgmOdeStudio.prgm_version);
            Console.WriteLine("- Test");
        }
    }
}
