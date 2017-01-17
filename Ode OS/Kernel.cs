using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;
using Cosmos.System.FileSystem;
using System.Drawing;
using Ode_OS_SystemRing;
using static Ode_OS_SystemRing.SystemHelpers;
using Cosmos.Core.IOGroup.Network;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network;

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

            Console.ForegroundColor = ConsoleColor.White;

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



        }
        bool running = true;


        public CosmosVFS FS { get; private set; }
        public Sys.Network.UdpClient sckt { get; private set; }

        protected override void Run()

        {
            goto name;
            name:
            {
                Console.WriteLine("Entrez votre pseudo et mot de passe :");
                Console.Write("Votre nom : ");
                string name = Console.ReadLine();
                Console.Write("Votre mot de passe : ");
                string pass = Console.ReadLine();
            //    var fileexist = File.Exists("0:\\System1\\install.txt");

               // if (fileexist ==true)
                //{
                    Console.WriteLine("OdeOS est deja installe !");
                    //var userfile = File.ReadAllText("0:\\System\\user.txt");
                    

               // }
             //   else
              //  {
                    Console.Write("Voulez vous installer OdeOS ? ( o ou n ) ");
                    string installinput = Console.ReadLine();
                    if (installinput == "o")
                    {
                        Console.WriteLine("Installation en cours...");

                        Console.WriteLine("Creation des dossiers...");
                        FS.CreateDirectory("0:\\System1");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("[OK]");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("Creation des fichiers...");
                        var f = File.Create("0:\\System1\\user.txt");
                        f.Close();
                        var g = File.Create("0:\\System1\\install.txt");
                        g.Close();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("[OK]");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("Ecriture des fichiers...");
                        File.WriteAllText("0:\\System1\\user.txt", name + "\n" + pass);
                        File.WriteAllText("0:\\System1\\install.txt", "1");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("[OK]");
                        Console.WriteLine("L'installation s'est deroulee avec succes !");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto main;

                    }
                    else if (installinput == "n")
                    {
                        goto main;

                    }
           //     }




                //Console.WriteLine("Bienvenue " + name + " !");
                //goto main;
            }
            main:
            {
                while (running)
                {

                    Console.ForegroundColor = ConsoleColor.White;


                    Console.Write("@odeos:" + current_directory + "> ");
                    //valen@odeos>
                    string input = Console.ReadLine();
                    input = input.Replace("/", "\\");
                    InterpretCMD(input);


                }
            }



        }

        public const string sad_monitor = @"
 ____________
|            |      ______________________________________________
|  ()    ()  |     /                                              \
|   ______   | ---|  Looks like an error occurred... Now I'm sad.  |
| /        \ |     \______________________________________________/
|____________|"; //Memphis is sad because it encountered an error. It's gonna go hide in a corner. ):

        public void StopKernel(Exception ex)
        {
            //PlayErrorSound(); Dang. This doesn't seem to work...
            running = false;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine(sad_monitor);
            string ex_message = ex.Message;
            string inner_message = "<none>";
            if (ex.InnerException != null)
                inner_message = ex.InnerException.Message;
            Console.WriteLine($@"Error message: {ex_message}
Inner exception message: {inner_message}");
            Console.WriteLine("Press any key to reboot.");
            try
            {
                Console.ReadKey();
            }
            catch
            {

            }
            Sys.Power.Reboot();
        }

        public void PlayErrorSound()
        {
            for (int i = 500; i > 450; i--)
            {
                Beep(i, 100);
            }
            Beep(440, 10);
        }


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
                    this.Stop();

                }
                else if (shutinput == "n")
                {
                    running = true;
                }
                else
                {
                    running = true;
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
                }
                else
                {
                    running = true;
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
- La date actuelle est : {SystemInfo.Time.ToString()}");
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
            //else if (input.StartsWith("dir -r System1"))
           // {
            //    Console.WriteLine("Impossible de supprimer les fichiers systeme");
          //  }
            else if (input.StartsWith("dir -r "))
            {
                string dirr = input.Remove(0, 7);


                if (Directory.Exists(current_directory + dirr))
                {
                    Directory.Delete(current_directory + dirr);
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


            else if (input =="clear")
            {
                Directory.SetCurrentDirectory(current_directory);
                Console.Clear();
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
            }

            else if (input == "test_prgm")
            {

                Console.Clear();
                Console.WriteLine("Le premier programme 0.1");
                Console.WriteLine("Entrez du texte :");
                input = Console.ReadLine();
                Console.WriteLine("Vous avez ecrit '" + input + "'");
                Console.WriteLine("Appuyez sur une touche pour quitter le programme");
                Console.ReadKey(true);
            }
            else if (input == "test_crash")
            {
                throw new Exception("Crash test.");
            }
            else if (input == "test_win")
            {
                var w = new TUI.BlankWindow("Valentin Charbonnier", 22, 10, 2, 2);
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                Console.BackgroundColor = ConsoleColor.Black;
                var b1 = new TUI.Button("Impressionant", 2, 2, 10, 1, w);
                var b2 = new TUI.Button("Super", 2, 4, 10, 1, w);
                var w2 = new TUI.BlankWindow("Une autre fenetre", 32, 20, w.X + w.Width + 3, w.Y);

            }
            else if (input == "test_mouse")
            {
                var m = new Mouse();

    }

            else if (input == "test_socket")
            {
                sckt = new UdpClient();
                //Console.Write("Adresse : ");
                //string adress = Console.ReadLine();
                //IPAddress localAddress = IPAddress.Parse(adress);
                //IPEndPoint ipEndpoint = new IPEndPoint(localAddress, 5842);
                sckt.Connect(new Address (192, 168, 1, 25), 5842);
                sckt.Send(new byte[] { 1 });

                sckt.Close();
            }


            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Commande inconnue, essayez la commande help");
            }
        }
    }
}
