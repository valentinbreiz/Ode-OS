#region using;
using System;
using Sys = Cosmos.System;
using System.IO;
using Cosmos.System.FileSystem;
using Ode_OS.Apps;
using Ode_OS.System;
using Ode_OS.System.assets;
using Ode_OS.System.graphic;

#endregion

namespace CosmosKernel2
{
    public class Kernel : Sys.Kernel
    {

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
                    if (File.Exists("0:\\root"))
                    {
                        File.Delete("0:\\root");
                    }
                    Console.WriteLine("Le Kernel a correctement demarre !");
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("[Erreur]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }
                Console.Clear()
            }
            catch (Exception ex)
            {
                running = false;
                crash.StopKernel(ex);
            }
        }

        bool running = true;

        public CosmosVFS FS { get; private set; }

        protected override void Run()
        { 
            try
            {
                goto name;

        name:
            {
                logo.OdeOSlogo(version);

                int x = Console.CursorLeft;
                int y = Console.CursorTop;
                Console.SetCursorPosition(19, 13);
                Console.WriteLine("|---------------------------------------|");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 14);
                Console.WriteLine("|              -Connexion-              |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 15);
                Console.WriteLine("|                                       |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 16);
                Console.WriteLine("|Votre nom :                            |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 17);
                Console.WriteLine("|Votre mot de passe :                   |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 18);
                Console.WriteLine("|                                       |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 19);
                Console.WriteLine("|              -Confirmer-              |");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 20);
                Console.WriteLine("|---------------------------------------|");
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 16);
                Console.Write("|Votre nom : ");
                string name = Console.ReadLine();
                Console.SetCursorPosition(x, y);

                Console.SetCursorPosition(19, 17);
                Console.Write("|Votre mot de passe : ");
                string pass = Console.ReadLine();
                Console.SetCursorPosition(x, y);

                Console.Clear();

                if (name == "root" && pass == "")
                {
                        var f = File.Create("0:\\root");
                        f.Close();
                        goto main;
                    }

                bool systemexist = Directory.Exists("0:\\System");
                        
                if (systemexist == true)
                {
                    var userfile = File.ReadAllText("0:\\System\\user");
                    var passfile = File.ReadAllText("0:\\System\\pass");

                    if (name == userfile && pass == passfile)
                    {
                            
                        Console.Clear();
                        logo.OdeOSlogo(version);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Bienvenue " + userfile + " !");
                        Console.ForegroundColor = ConsoleColor.White;
                        goto main;
                    }
                    else
                    {
                        Console.Clear();
                        logo.OdeOSlogo(version);

                        Console.SetCursorPosition(19, 13);
                        Console.WriteLine("|---------------------------------------|");
                        Console.SetCursorPosition(x, y);

                        Console.SetCursorPosition(19, 14);
                        Console.WriteLine("|              -Connexion-              |");
                        Console.SetCursorPosition(x, y);

                        Console.SetCursorPosition(19, 15);
                        Console.WriteLine("|                                       |");
                        Console.SetCursorPosition(x, y);

                        Console.SetCursorPosition(19, 16);
                        Console.WriteLine("|Votre nom :                            |");
                        Console.SetCursorPosition(x, y);

                        Console.SetCursorPosition(19, 17);
                        Console.WriteLine("|Votre mot de passe :                   |");
                        Console.SetCursorPosition(x, y);

                        Console.SetCursorPosition(19, 18);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("|         Mdp ou nom incorrect !        |");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(x, y);

                        Console.SetCursorPosition(19, 19);
                        Console.WriteLine("|         -Reset-          -Ok-         |");
                        Console.SetCursorPosition(x, y);

                        Console.SetCursorPosition(19, 20);
                        Console.WriteLine("|---------------------------------------|");
                        Console.SetCursorPosition(x, y);


                        goto test;
                    test:
                        {
                            ConsoleKeyInfo info = Console.ReadKey();
                            if (info.Key == ConsoleKey.LeftArrow)
                            {
                                Console.SetCursorPosition(19, 19);
                                Console.WriteLine("|        ||Reset||         -Ok-         |");
                                Console.SetCursorPosition(x, y);
                                ConsoleKeyInfo info1 = Console.ReadKey();
                                if (info1.Key == ConsoleKey.Enter)
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
                                            File.Delete(current_directory + "System\\user");
                                            File.Delete(current_directory + "System\\pass");
                                            Directory.Delete("0:\\System");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("[OK]");
                                            Console.ForegroundColor = ConsoleColor.White;

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("La suppression s'est deroulee avec succes !");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Appuyez sur une touche pour redemarrer Ode.");
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
                                else if (info1.Key == ConsoleKey.RightArrow)
                                {
                                    goto test;
                                }
                                else
                                {
                                    goto test;
                                }

                            }

                            else if (info.Key == ConsoleKey.RightArrow)
                            {
                                Console.SetCursorPosition(19, 19);
                                Console.WriteLine("|         -Reset-         ||Ok||        |");
                                Console.SetCursorPosition(x, y);
                                ConsoleKeyInfo info1 = Console.ReadKey();
                                if (info1.Key == ConsoleKey.Enter)
                                {
                                    Console.Clear();
                                    goto name;
                                }
                                if (info1.Key == ConsoleKey.LeftArrow)
                                {
                                    goto test;
                                }
                                else
                                {
                                    goto test;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.Write("Installer Ode avec '" + name + "' et '" + pass + "' ? ( o ou n ) ");
                    string installinput = Console.ReadLine();
                    if (installinput == "o")
                    {
                        try
                        {
                        running = false;
                        Console.WriteLine("Installation en cours...");

                        int xx = Console.CursorLeft;
                        int yy = Console.CursorTop;

                        Console.SetCursorPosition(0, 12);
                        Console.WriteLine("*------------------------------------------------------------------------------*");
                        Console.SetCursorPosition(xx, yy);

                        Console.SetCursorPosition(0, 14);
                        Console.WriteLine("*------------------------------------------------------------------------------*");
                        Console.SetCursorPosition(xx, yy);

                        FS.CreateDirectory("0:\\System");

                        Console.SetCursorPosition(0, 13);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("#####");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xx, yy);

                        FS.CreateDirectory("0:\\Users");

                        Console.SetCursorPosition(0, 13);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("###########");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xx, yy);

                        FS.CreateDirectory("0:\\Users\\"+name);
                        FS.CreateDirectory("0:\\Users\\" + name +"\\Documents");
                        FS.CreateDirectory("0:\\Users\\" + name + "\\Telechargements");
                        FS.CreateDirectory("0:\\Users\\" + name + "\\Images");
                        Console.SetCursorPosition(0, 13);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("################");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xx, yy);

                        var f = File.Create("0:\\System\\user");
                        f.Close();
                        Console.SetCursorPosition(0, 13);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("########################################");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xx, yy);

                        var g = File.Create("0:\\System\\pass");
                        g.Close();
                        Console.SetCursorPosition(0, 13);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("######################################################");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xx, yy);

                        File.WriteAllText("0:\\System\\user", name);
                        File.WriteAllText("0:\\System\\pass", pass);
                        Console.SetCursorPosition(0, 13);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("################################################################################");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xx, yy);

                        Console.SetCursorPosition(0, 10);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("                  L'installation s'est deroulee avec succes !                   ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(xx, yy);

                        Console.SetCursorPosition(0, 11);
                        Console.WriteLine("                   Appuyez sur une touche pour acceder a Ode                    ");
                        Console.SetCursorPosition(xx, yy);

                        Console.ReadKey();
                        Console.Clear();
                        running = true;
                        goto main;
                        }
                        catch (Exception ex)
                        {
                            crash.StopKernel(ex);
                        }
                    }
                    else if (installinput == "n")
                    {
                        Console.Clear();
                        goto name;
                    }
                    else
                        {
                            Console.Clear();
                            goto name;
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
                        Console.WriteLine("valentinbreiz.github.io                                              Ode v" + version);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(" ");
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.White;

                        bool system = Directory.Exists("0:\\System");
                        
                        if (!File.Exists("0:\\root"))
                            {
                                if (system == false)
                                {
                                    Console.Write("invit@ode:" + current_directory + "> ");
                                    string input = Console.ReadLine();
                                    input = input.Replace("/", "\\");
                                    InterpretCMD(input);
                                }
                                else
                                {
                                    var name = File.ReadAllText("0:\\System\\user");
                                    Console.Write(name + "@ode:" + current_directory + "> ");
                                    string input = Console.ReadLine();
                                    input = input.Replace("/", "\\");
                                    InterpretCMD(input);
                                }
                            }
                        else
                            {
                                Console.Write("root@ode:" + current_directory + "> ");
                                string input = Console.ReadLine();
                                input = input.Replace("/", "\\");
                                InterpretCMD(input);
                            } 

                    }
                    catch (Exception ex)
                    {
                        running = false;
                        crash.StopKernel(ex);
                    }
                }
            }
            }
                catch (Exception ex)
            {
                crash.StopKernel(ex);
            }
        }

        #endregion

        #region InterpetCMD

        private void InterpretCMD(string input)
        {
            string[] args = input.Split(' ');

            if (input == "shutdown")
            {
                Console.Clear();
                Console.WriteLine("Le systeme est pret a s'arreter.");
                running = false;
                Console.Write("Confirmez vous la mise hors tension du systeme ? (o ou n) ");
                string shutinput = Console.ReadLine();
                if (shutinput == "o")
                {
                    running = false;
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
                Console.WriteLine("Le systeme est pret a redemarrer.");
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
- Capacite du systeme : {Sys.FileSystem.VFS.VFSManager.GetVolumes().Capacity}
- La date actuelle est : Test");
                Console.WriteLine("- Propulse par CosmosOS et ecrit en C#");
                Console.WriteLine("- Ode v" + version + " - fait par valentinbreiz");
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
                        Console.WriteLine("--"+file+"--");
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
                    Console.WriteLine("<Dossier>\t" + dir);

                    foreach (var indir in Directory.GetDirectories(current_directory + dir))
                    {
                        Console.WriteLine("<Dossier>\t" + indir);
                    }
                }
                foreach (var dir in Directory.GetFiles(current_directory))
                {
                    Console.WriteLine("<Fichier>\t" + dir);
                    foreach (var indir in Directory.GetFiles(current_directory + dir))
                    {
                        Console.WriteLine("<Fichier>\t" + indir);
                    }
                }

            }
            else if (input == "dir -r System")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Impossible de supprimer les fichiers systeme");
                Console.ForegroundColor = ConsoleColor.White;
            }
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
            else if (input == "fil -c root")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Impossible de creer un fichier 'root'");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (input.StartsWith("fil -c "))
            {
                string filec = input.Remove(0, 7);

                PrgmNano app = new PrgmNano();
                app.initNano(filec, current_directory);
            }
            else if (input == "fil -r root")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Impossible de suuprimer le fichier 'root'");
                Console.ForegroundColor = ConsoleColor.White;
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
            else if (input == "dir -c System")
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
                else if (Directory.Exists(current_directory + dir))
                {
                    Console.WriteLine("Le dossier existe deja !");
                    Console.WriteLine("Dossier cree !");
                    FS.CreateDirectory(current_directory + dir + "-1");
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

            else if (input == "cd System")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Impossible d'acceder au dossier 'System'");
                Console.ForegroundColor = ConsoleColor.White;
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

            else if (input == "help")
            {
                Console.WriteLine("Commandes disponibles :");
                Console.WriteLine("shutdown       : permet d'eteindre Ode");
                Console.WriteLine("reboot         : permet de redemarrer Ode");
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
                Console.WriteLine("prgm -s        : permet de lancer un programme systeme");
                Console.WriteLine("prgm -s -ode   : permet de lancer un programme fichier");
                Console.WriteLine("lock           : permet de verouiller Ode avec un mot de passe");
            }

            else if (input == "test_crash")
            {
                throw new Exception("Crash test.");
            }
            else if (input == "test_window")
            {
                Console.Clear();
                windows.Windows_password("            -Fenetre test-             ", "Texte :                                ", "Texte : ", "         ||Fermer la fenetre||         ");

            }
            else if (input == "test_graphic")
            {
                desktop desktop = new desktop();
                desktop.Init();
                
            }

            else if (input.StartsWith("prgm -s -ode "))
            {
                string prgm = input.Remove(0, 13);

                if (File.Exists(current_directory + prgm))
                {
                    corecompiler compiler = new corecompiler();
                    compiler.beginbuild(current_directory + prgm, "", false);
                }
                else
                {
                    Console.WriteLine("Le programme '" + prgm + "' n'existe pas !");
                }
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
                    PrgmParametres app = new PrgmParametres();
                    app.MainProgram();
                }
                if (prgm == "Microtxt")
                {
                    PrgmMicrotxt.init();
                }
                if (prgm == "Snake")
                {
                    PrgmSnake app = new PrgmSnake();
                    app.Run();
                }
                if (prgm == "Ode Studio")
                {
                    PrgmOdeStudio app = new PrgmOdeStudio();
                    app.MainProgram();
                }
                if (prgm == "Liquid")
                {
                    PrgmNano app = new PrgmNano();
                    app.filepath(current_directory);
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
                AppList app = new AppList();
                app.MainProgram();
            }
            else if (input == "lock")
            {
                Console.Write("Definissez un code: ");
                string pass = Console.ReadLine();
                @lock.lockpass(pass, version);
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
