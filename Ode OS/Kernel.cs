#region using;
using System;
using Sys = Cosmos.System;
using System.IO;
using Cosmos.System.FileSystem;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network;
using Ode_OS.Apps;

#endregion

namespace CosmosKernel2
{
    public class Kernel : Sys.Kernel
    {
        #region OdeOSlogo 

        private void OdeOSlogo()
        {
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
        }

        #endregion

        #region Global variables

        string version = "0.0.2";
        string current_directory = "0:\\";

        #endregion

        #region BeforeRun & Run
        protected override void BeforeRun()
        {
            try
            {

                try
                {
                    Console.WriteLine("Initialisation clavier FR...");
                    Sys.KeyboardManager.SetKeyLayout(new Sys.ScanMaps.FR_Standard());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[OK]");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("[Erreur]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }
                try
                {
                    Console.WriteLine("Initialisation du systeme de fichier...");
                    FS = new CosmosVFS();
                    FS.Initialize();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[OK]");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("[Erreur]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }
                try
                {
                    Console.WriteLine("Scan du systeme de fichiers...");
                    Sys.FileSystem.VFS.VFSManager.RegisterVFS(FS);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[OK]");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("[Erreur]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }
                try
                {
                    Console.WriteLine("Le Kernel a correctement demarre !");
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("[Erreur]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }
                Console.Clear();
                OdeOSlogo();
            }
            catch (Exception ex)
            {
                StopKernel(ex);
            }

        }



        bool running = true;


        public CosmosVFS FS { get; private set; }

        protected override void Run()

        {
            goto name;
        name:
            {
                Console.WriteLine("Entrez votre pseudo et mot de passe");
                Console.Write("Votre nom : ");
                string name = Console.ReadLine();
                Console.Write("Votre mot de passe : ");
                string pass = Console.ReadLine();
                bool systemexist = Directory.Exists("0:\\System");

                if (systemexist == true)
                {
                    var userfile = File.ReadAllText("0:\\System\\user.txt");
                    var passfile = File.ReadAllText("0:\\System\\pass.txt");
                    if (name == userfile && pass == passfile)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Bienvenue " + userfile + " !");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto main;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Mot de passe ou nom d'utilisateur incorrect !");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto name;

                    }

                }
                else
                {
                    Console.Write("Installer OdeOS avec '" + name + "' et '" + pass + "' ? ( o ou n ) ");
                    string installinput = Console.ReadLine();
                    if (installinput == "o")
                    {
                        running = false;
                        Console.WriteLine("Installation en cours...");

                        Console.WriteLine("Creation des dossiers...");
                        FS.CreateDirectory("0:\\System");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("[OK]");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("Creation des fichiers...");
                        var f = File.Create("0:\\System\\user.txt");
                        var g = File.Create("0:\\System\\pass.txt");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("[OK]");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("Ecriture des fichiers...");
                        File.WriteAllText("0:\\System\\user.txt", name);
                        File.WriteAllText("0:\\System\\pass.txt", pass);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("[OK]");

                        Console.WriteLine("L'installation s'est deroulee avec succes !");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Appuyez sur une touche pour acceder a OdeOS");
                        Console.ReadKey();
                        Console.Clear();
                        running = true;
                        goto main;


                    }
                    else if (installinput == "n")
                    {

                        Console.Clear();
                        goto main;

                    }
                }


            }
        main:
            {
                while (running)
                {

                    try
                    {
                        Console.WriteLine(" ");
                        int x = Console.CursorLeft;
                        int y = Console.CursorTop;
                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine("valentinbreiz.github.io                                            OdeOS v" + version);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(" ");
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.White;

                        bool username = File.Exists("0:\\System\\user.txt");

                        if (username == false)
                        {
                            Console.Write("invit@odeos:" + current_directory + "> ");
                            string input = Console.ReadLine();
                            input = input.Replace("/", "\\");
                            InterpretCMD(input);

                        }
                        else
                        {

                            var name = File.ReadAllText("0:\\System\\user.txt");
                            Console.Write(name + "@odeos:" + current_directory + "> ");
                            string input = Console.ReadLine();
                            input = input.Replace("/", "\\");
                            InterpretCMD(input);
                        }


                    }
                    catch (Exception ex)
                    {
                        StopKernel(ex);
                    }

                }

            }


        }
        #endregion

        #region Exception

        public void StopKernel(Exception ex)
        {

            running = false;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine("THE BLUE SCREEN OF DEATH 0.1");
            Console.WriteLine("ERREUR SYSTEME");
            string ex_message = ex.Message;
            string inner_message = "<aucun>";
            if (ex.InnerException != null)
                inner_message = ex.InnerException.Message;
            Console.WriteLine($@"Erreur : {ex_message}
Message d'exception : {inner_message}");

            Console.WriteLine("Appuyez sur une touche pour redemarrer");
            try
            {
                Console.ReadKey();
            }
            catch
            {

            }
            Sys.Power.Reboot();
        }

        #endregion

        #region InterpetCMD

        private void InterpretCMD(string input)
        {
            string[] args = input.Split(' ');

            if (input == "shutdown")
            {
                Console.Clear();
                Console.WriteLine("Le systeme est pret a s'arreter");
                running = false;
                Console.Write("Confirmez vous la mise hors tension du systeme ? (o ou n) ");
                string shutinput = Console.ReadLine();
                if (shutinput == "o")
                {
                    Stop();

                }
                else if (shutinput == "n")
                {
                    running = true;
                    Console.Clear();
                }
                else
                {
                    running = true;
                    Console.Clear();
                }

            }

            else if (input == "reboot")
            {

                Console.Clear();
                Console.WriteLine("Le systeme est pret a redemarrer");
                running = false;
                Console.Write("Confirmez vous le redemarrage du systeme ? (o ou n) ");
                string shutinput = Console.ReadLine();
                if (shutinput == "o")
                {
                    Sys.Power.Reboot();

                }
                else if (shutinput == "n")
                {
                    running = true;
                    Console.Clear();
                }
                else
                {
                    running = true;
                    Console.Clear();
                }
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
            else if (input == "infos")
            {
                Console.WriteLine($@"Informations systemes :
- Nombre de partitions : {Sys.FileSystem.VFS.VFSManager.GetVolumes().Count}
- La date actuelle est : Test");
                Console.WriteLine("- Propulse par CosmosOS et ecrit en C#");
                Console.WriteLine("- Ode OS v" + version + " - fait par valentinbreiz");
            }
            else if (input == "vol -l")
            {
                var vols = FS.GetVolumes();
                Console.WriteLine("Nom\tTaille\tParent");
                foreach (var vol in vols)
                {
                    Console.WriteLine(vol.mName + "\t" + vol.mSize + "\t" + vol.mParent);
                }
            }
            else if (input.StartsWith("fil -p "))
            {
                string file = input.Remove(0, 7);

                {
                    Directory.SetCurrentDirectory(current_directory);
                    if (File.Exists(current_directory + file))
                    {
                        Console.WriteLine(File.ReadAllText(current_directory + file));
                    }
                    else
                    {
                        Console.WriteLine("Le fichier '" + file + "' n'existe pas !");
                    }
                }

            }
            else if (input == "dir -l")
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
            else if (input == "tree")
            {
                Console.WriteLine("Type\t     Nom");
                foreach (var dir in Directory.GetDirectories(current_directory))
                {
                    var indir = Directory.GetDirectories(dir);
                    Console.WriteLine("<Dossier>\t" + dir);
                    Console.WriteLine("<Dossier>\t" + indir);
                }

                foreach (var dir in Directory.GetFiles(current_directory))
                {
                    Console.WriteLine("<Fichier>\t" + dir);
                }

            }



            //else if (input.StartsWith("dir -r System1"))
            // {
            //    Console.WriteLine("Impossible de supprimer les fichiers systeme");
            //  }
            else if (input.StartsWith("dir -r "))
            {
                string dirr = input.Remove(0, 7);


                if (Directory.Exists(current_directory + dirr))
                {
                    Directory.Delete(current_directory + dirr, true);
                    Console.WriteLine("Le dossier '" + dirr + "' a ete supprime !");
                }
                else
                {
                    Console.WriteLine("Le dossier '" + dirr + "' n'existe pas !");
                }

            }
            else if (input.StartsWith("fil -c "))
            {
                string filec = input.Remove(0, 7);
                var f = File.Create(current_directory + filec);
                f.Close();
                Console.WriteLine("Editeur de texte 0.1 ('entrer' pour enregistrer et '/n' pour retour a la ligne) :");
                string fileccontenu = Console.ReadLine();
                fileccontenu = fileccontenu.Replace("/n", "\n");
                File.WriteAllText(current_directory + filec, fileccontenu);
                Console.WriteLine("'" + filec + "'a ete cree !");
            }
            else if (input.StartsWith("fil -r "))
            {
                string filer = input.Remove(0, 7);
                if (File.Exists(current_directory + filer))
                {
                    File.Delete(current_directory + filer);
                    Console.WriteLine("'" + filer + "' a ete supprime !");
                }
                else
                {
                    Console.WriteLine("Le fichier '" + filer + "' n'existe pas !");
                }


            }
            else if (input == "dir -c System")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Impossible de creer un dossier 'System'");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (input == "dir -c system")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Impossible de creer un dossier 'System'");
                Console.ForegroundColor = ConsoleColor.White;
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

            else if (input == "cd ..")
            {

                Directory.SetCurrentDirectory(current_directory);
                var dir = FS.GetDirectory(current_directory);
                if (current_directory == "0:\\")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Impossible d'entrer dans la matrice !");

                }
                else
                {
                    current_directory = dir.mParent.mFullPath;
                }


            }

            else if (input.StartsWith("cd "))
            {
                var newdir = input.Remove(0, 3);

                if (Directory.Exists(current_directory + newdir))
                {
                    Directory.SetCurrentDirectory(current_directory);
                    current_directory = current_directory + newdir + "\\";
                }
                else
                {
                    Console.WriteLine("Ce dossier n'existe pas !");
                }
            }


            else if (input == "clear")
            {
                Directory.SetCurrentDirectory(current_directory);
                Console.Clear();
                Console.WriteLine("");
            }
            else if (input == "test_ram")
            {

            }
            else if (input == "help")
            {
                Console.WriteLine("Commandes disponibles :");
                Console.WriteLine("shutdown       : permet d'eteindre Ode OS");
                Console.WriteLine("reboot         : permet de redemarrer Ode OS");
                Console.WriteLine("echo           : permet de renvoyer le texte ecrit");
                Console.WriteLine("vol -l         : permet d'afficher les volumes disponibles");
                Console.WriteLine("dir -l         : permet d'afficher les fichiers et dossiers");
                Console.WriteLine("dir -c         : permet de creer un dossier");
                Console.WriteLine("dir -r         : permet de supprimer un dossier");
                Console.WriteLine("fil -c         : permet de creer un fichier");
                Console.WriteLine("fil -r         : permet de supprimer un fichier");
                Console.WriteLine("fil -p         : permet d'afficher le contenu d'un fichier");
                Console.WriteLine("cd             : se deplacer de dossier en dossier");
                Console.WriteLine("clear          : permet de nettoyer la console");
                Console.WriteLine("infos          : permet d'afficher des informations systeme");
                Console.WriteLine("prgm -l        : permet d'afficher une liste de tous les programmes");
                Console.WriteLine("prgm -s        : permet de lancer un programme");
            }

            else if (input == "test_crash")
            {
                throw new Exception("Crash test.");
            }
            else if (input.StartsWith("prgm -s "))
            {
                string prgm = input.Remove(0, 8);

                if (prgm == "Test")
                {
                    PrgmTest app = new PrgmTest();
                    app.MainProgram();
                }
                if (prgm == "Parametres")
                {
                    PgrmParametres app = new PgrmParametres();
                    app.MainProgram();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ce programme n'existe pas !");
                    Console.WriteLine("Essayez prgm -l pour voir la liste des programmes.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            else if (input == "prgm -l")
            {
                Console.WriteLine("Programmes disponibles :");
                Console.WriteLine("- Parametres");
                Console.WriteLine("- Test");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Commande inconnue, essayez la commande help");
            }

            #endregion

        }
    }
}
