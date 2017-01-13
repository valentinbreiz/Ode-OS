using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;
using Cosmos.System.FileSystem;

namespace Ode_OS
{
    public class Kernel : Sys.Kernel
    {
        string version = "0.0.1";
        string current_directory = "0:\\";
        protected override void BeforeRun()
        {
            Console.WriteLine("Initialisation clavier FR...");
            Sys.KeyboardManager.SetKeyLayout(new Sys.ScanMaps.FR_Standard());
            Console.WriteLine("Initialisation du systeme de fichier...");
            FS = new Sys.FileSystem.CosmosVFS();
            FS.Initialize();
            Console.WriteLine("Scan du systeme de fichiers...");
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(FS);

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Clear();

            Console.WriteLine(" ");
            Console.WriteLine("|------------------------------------------------------------------------------|");
            Console.WriteLine(" _____   _____   _____        _____   _____");
            Console.WriteLine("/  _    |  _    | ____|      /  _    /  ___/");
            Console.WriteLine("| | | | | | | | | |__        | | | | | |___");
            Console.WriteLine("| | | | | | | | |  __|       | | | |  ___   ");
            Console.WriteLine("| |_| | | |_| | | |___       | |_| |  ___| |   version " + version);
            Console.WriteLine(" _____/ |_____/ |_____|       _____/ /_____/   cree par valentinbreiz");
            Console.WriteLine(" ");
            Console.WriteLine("|------------------------------------------------------------------------------|");
            Console.WriteLine(" ");
            Console.Write("Votre nom : ");
            var name = Console.ReadLine();
            Console.WriteLine("Bienvenue " + name + " !");


        }
        bool running = true;

        public CosmosVFS FS { get; private set; }

        protected override void Run()

        {

            while (running)
            {

                Console.Write(current_directory + "> ");
                string input = Console.ReadLine();
                InterpretCMD(input);

            }
        }

        private void InterpretCMD(string input)
        {
            string[] args = input.Split(' ');
            if (input.StartsWith("shutdown"))
            {
                Console.Clear();
                Console.WriteLine("Le systeme est pret a s'arreter");
                running = false;

            }
            else if (input.StartsWith("reboot"))
            {
                Sys.Power.Reboot();
            }
            else if (input.StartsWith("echo "))
            {
                try
                {
                    Console.WriteLine(input.Remove(0, 5));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("echo: " + ex.Message);
                }
            }
            else if (input.StartsWith("lsvol"))
            {
                var vols = FS.GetVolumes();
                Console.WriteLine("Nom\tTaille\tParent");
                foreach (var vol in vols)
                {
                    Console.WriteLine(vol.mName + "\t" + vol.mSize + "\t" + vol.mParent);
                }
            }
            else if (input.StartsWith("print "))
            {
                string file = input.Remove(0, 6);

                {
                    if (File.Exists("0:\\" + file))
                    {
                        Console.WriteLine(File.ReadAllText("0:\\" + file));
                    }
                    else
                    {
                        Console.WriteLine("print : Ce fichier n'existe pas");
                    }
                }

            }
            else if (input.StartsWith("dir -l"))
            {
                Console.WriteLine("Type\t     Nom");
                foreach (var dir in Directory.GetDirectories(current_directory))
                {
                    Console.WriteLine("<Dossier>\t" + dir);
                }
                foreach (var dir in Directory.GetFiles(current_directory))
                {
                    Console.WriteLine("<Fichier>\t" + dir);
                }
            }
            else if (input.StartsWith("test_write"))
            {
                var file = FS.CreateFile(current_directory + "test.txt");
                //File.WriteAllText(current_directory + "test.txt", "Test!");
                Console.WriteLine("Fichier cree !");
            }
            else if (input.StartsWith("dir -c "))
            {
                string dir = input.Remove(0, 7);
                if (!Directory.Exists(current_directory + dir))
                {
                    FS.CreateDirectory(current_directory + dir);
                    Console.WriteLine("Dossier cree !");
                }
            }
            else if (input.StartsWith("cd "))
            {
                var newdir = input.Remove(0, 3);
                if (FS.GetDirectory(current_directory + newdir) != null)
                {
                    current_directory = current_directory + newdir + "\\";
                }
                else
                {
                    if (newdir == "..")
                    {
                        var dir = FS.GetDirectory(current_directory);
                        string p = dir.mParent.mName;
                        Console.WriteLine(p);
                    }
                }
            }
            else if (input.StartsWith("clear"))
            {
                Console.Clear();
            }
            else if (input.StartsWith("help"))
            {
                Console.WriteLine("Commandes disponibles :");
                Console.WriteLine("shutdown       : permet d'eteindre Ode OS");
                Console.WriteLine("reboot         : permet de redemarrer Ode OS");
                Console.WriteLine("echo           : permet de renvoyer le texte ecrit");
                Console.WriteLine("lsvol          : permet d'afficher les volumes disponibles");
                Console.WriteLine("dir -l         : permet d'afficher les fichiers et dossiers");
                Console.WriteLine("dir -c         : permet de creer un dossier");
                Console.WriteLine("print -fichier : permet d'afficher le contenu d'un fichier");
                Console.WriteLine("test_write     : permet de creer un fichier test");
                Console.WriteLine("cd             : se deplacer de dossier en dossier");
                Console.WriteLine("clear          : permet de nettoyer la console");
            }
            else
            {
                Console.WriteLine("Commande inconnue, essayez la commande help");
            }
        }
    }
}
