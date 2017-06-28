/*
* PROJECT:          Ode Operating System Development
* CONTENT:          Ode Studio (Like Visual Studio)
* PROGRAMMERS:      Valentin Charbonnier <valentinbreiz@gmail.com>
*/

using Cosmos.System.FileSystem;
using System;
using System.IO;
using Ode_OS.System;

namespace Ode_OS.Apps
{
    class PrgmOdeStudio
    {
        public static string prgm_version = "0.0.2";

        public void MainProgram()
        {
            Console.Clear();
            var FS = new CosmosVFS();
            FS.Initialize();

            var name = File.ReadAllText("0:\\System\\user");

            FS.CreateDirectory("0:\\Users\\" + name + "\\Documents\\OdeStudio");
            FS.CreateDirectory("0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects");

            Console.Clear();
            Console.WriteLine("Bienvenue dans la premiere version de Ode Studio !");
            Console.WriteLine("Ouvrir un projet ou nouveau projet ? (open, new, delete ou quit)");
            var result = Console.ReadLine();
            if (result == "open")
            {
                Console.Clear();
                Console.WriteLine("Liste des projets:");
                foreach (var dir in Directory.GetDirectories("0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\"))
                {
                    Console.WriteLine(dir);
                }
                Console.WriteLine(" ");
                Console.Write("Nom du projet a ouvrir : ");
                var nomprojet = Console.ReadLine();
                var path = "0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\" + nomprojet;
                if (Directory.Exists(path))
                {
                    if (File.Exists(path + "\\solution"))
                    {

                        string text = File.ReadAllText(path + "\\solution");
                        string realsources = text.Remove(0, 7);
                        Console.Clear();
                        Console.WriteLine(nomprojet);
                        Console.WriteLine("Sources = " + realsources);
                        Console.Write("Sources = ");

                        var source = Console.ReadLine();

                        source = source.Replace("/n", "\n");

                        source = source.Replace("/", "\\");

                        Console.WriteLine("Sauvegarde du projet...");

                        File.Delete("0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\" + nomprojet + "\\solution");

                        FS.CreateDirectory("0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\" + nomprojet);

                        var f = File.Create("0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\" + nomprojet + "\\solution");

                        File.WriteAllText("0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\" + nomprojet + "\\solution", "PATH=0:\\" + "\n" + "SOURCE=" + source);
                        Console.Clear();

                        Console.WriteLine("Programme sauvegarde !");
                        Console.WriteLine("Voulez vous generer et tester le projet ? (o ou n)");
                        var result1 = Console.ReadLine();
                        if (result1 == "o")
                        {
                            corecompiler coredotode = new corecompiler();
                            coredotode.beginbuild("0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\" + nomprojet + "\\solution", nomprojet, true);
                        }
                        else if (result1 == "n")
                        {
                            Console.Clear();
                            MainProgram();
                        }
                        else
                        {
                            Console.Clear();
                            MainProgram();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Le projet ne contient pas de 'solution', impossible de le lancer.");
                        Console.ReadKey();
                        MainProgram();
                    }
                }
                else
                {
                    Console.WriteLine("Le projet n'existe pas.");
                    Console.ReadKey();
                    Console.Clear();
                    MainProgram();
                }
            }
            else if (result == "delete")
            {
                Console.Clear();
                Console.WriteLine("Liste des projets:");
                foreach (var dir in Directory.GetDirectories("0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\"))
                {
                    Console.WriteLine(dir);
                }
                Console.WriteLine(" ");
                Console.Write("Nom du projet a supprimer : ");
                var nomprojet = Console.ReadLine();
                var path = "0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\" + nomprojet;
                if (Directory.Exists(path))
                {
                    File.Delete("0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\" + nomprojet + "\\solution");
                    Directory.Delete("0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\" + nomprojet);
                    Console.WriteLine("Projet supprime !");
                    Console.ReadKey();
                    Console.Clear();
                    MainProgram();
                }
                else
                {
                    Console.WriteLine("Le projet n'existe pas.");
                    Console.ReadKey();
                    Console.Clear();
                    MainProgram();
                }
            }
            else if (result == "new")
            {
                Console.Clear();
                Console.Write("Nom du projet : ");
                var nomprojet = Console.ReadLine();

                if (Directory.Exists("0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\" + nomprojet))
                {
                    Console.Clear();
                    Console.WriteLine("Impossible de sauvegarder le projet, il existe deja !");
                    Console.ReadKey();
                    MainProgram();
                }

                Console.Clear();
                Console.WriteLine(nomprojet);
                Console.Write("Source : ");

                var source = Console.ReadLine();

                source = source.Replace("/n", "\n");

                source = source.Replace("/", "\\");

                Console.WriteLine("Sauvegarde du projet...");


                FS.CreateDirectory("0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\" + nomprojet);

                var f = File.Create("0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\" + nomprojet + "\\solution");
                
                File.WriteAllText("0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\" + nomprojet + "\\solution", "PATH=0:\\" + "\n" + "SOURCE=" + source);
                Console.Clear();

                Console.WriteLine("Programme sauvegarde !");
                Console.WriteLine("Voulez vous generer et tester le projet ? (o ou n)");
                var result1 = Console.ReadLine();
                if (result1 == "o")
                {
                    corecompiler coredotode = new corecompiler();
                    coredotode.beginbuild("0:\\Users\\" + name + "\\Documents\\OdeStudio\\Projects\\" + nomprojet + "\\solution", nomprojet, true);
                }
                else if (result1 == "n")
                {
                    Console.Clear();
                    MainProgram();
                }
                else
                {
                    Console.Clear();
                    MainProgram();
                }
            }
            else if (result == "quit")
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Commande inconnue.");
                Console.ReadKey();
                MainProgram();
            }
        }
    }
}