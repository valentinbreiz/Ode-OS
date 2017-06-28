/*
* PROJECT:          Ode Operating System Development
* CONTENT:          The beginning of an interpreter ?
* PROGRAMMERS:      Valentin Charbonnier <valentinbreiz@gmail.com>
*/

using System;
using System.IO;

namespace Ode_OS.System
{
    class corecompiler
    {
        public void beginbuild(string apppath, string appname, bool debug)
        {
            Console.Clear();
            string filetext = File.ReadAllText(apppath);

            if (filetext.StartsWith("PATH="))
            {

                string searchForThis = "SOURCE=";
                int firstCharactersourceegual = filetext.IndexOf(searchForThis);

                string sources1 = filetext.Remove(0, firstCharactersourceegual);
                int sourcelenght = sources1.Length;
                string source = sources1.Remove(0, 7);

                string path1 = filetext.Remove(firstCharactersourceegual, sourcelenght);
                string path = path1.Remove(0, 5);


                buildapp(source, path, appname, debug);
            }
            else
            {

                Console.WriteLine("Programme corrompu ou invalide.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void buildapp(string source, string path, string appname, bool debug)
        {
            if (source.StartsWith("echo "))
            {
                string echo = source.Remove(0, 5);
                Console.WriteLine(echo);
                Console.ReadKey();

                if (debug == true)
                {
                    endbuild(appname);
                }
                else if (debug == false)
                {
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public void endbuild(string appname)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine(appname + " genere !");
            Console.WriteLine("Appuyez sur une touche pour quitter !");
            Console.WriteLine("-------------------------");
            Console.ReadKey();
            Console.Clear();
        }
    }
}