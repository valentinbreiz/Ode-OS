﻿using System;
using Sys = Cosmos.System;
using System.IO;
using Cosmos.System.FileSystem;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network;
using Ode_OS.Apps;

namespace Ode_OS.Apps
{
    class PgrmParametres
    {
        string current_directory = "0:\\";
        bool running = true;

        public void MainProgram()
        {
            Console.Clear();
            Console.WriteLine("Parametres 0.1");
            Console.WriteLine("1 pour Modifier compte utilisateur");
            Console.WriteLine("2 pour Reinitialisation systeme");
            Console.WriteLine("0 pour quitter les parametres");
            Console.Write("Votre choix : ");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("Arrive prochainement...");
            }
            else if (input == "2")
            {
                Console.Write("Voulez vous vraiment supprimer les fichiers systemes ? ( o ou n ) ");
                string resetinput = Console.ReadLine();
                if (resetinput == "o")
                {
                    Console.Clear();
                    bool system = Directory.Exists("0:\\System");

                    if (system == true)
                    {
                        running = false;
                        Console.WriteLine("Suppression en cours...");

                        try
                        {
                            Console.WriteLine("Suppression des fichiers et dossiers ...");
                            File.Delete(current_directory + "System\\user.txt");
                            File.Delete(current_directory + "System\\pass.txt");
                            Directory.Delete("0:\\System");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[OK]");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("La suppression s'est deroulee avec succes !");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Appuyez sur une touche pour redemarrer Ode OS");
                            Console.ReadKey();
                            Cosmos.System.Power.Reboot();
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("[Erreur]");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            running = true;
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Le systeme n'est pas installe !");
                        Console.ForegroundColor = ConsoleColor.White;
                    }



                }
            }
            else if (input == "0")
            {
                Console.Clear();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Cette commande n'existe pas");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
