using StringManipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_sharp
{

    [System.Serializable]

    internal class Game
    {
        public void start()
        {

            Console.Title = "Jeu C#";
            RunMainMenu();

        }


        private void RunMainMenu()
        {
            Player player = new Player();
            Map carte = new Map(player);
            Equipe equipe = new Equipe();
            bool _inBattle = false;
            ClassInventaire inventaire = new ClassInventaire();
            bool statut_game = false;
            bool statut_menu = true;
            bool statut_pause = false;
            bool statut_inventaire = false;

            bool _chest1 = false;
            bool _chest2 = false;
            bool _chest3 = false;


            ConsoleKeyInfo statut;

            string prompt = "Menu Principal";
            string[] options =
            {
                "Play",
                "Options",
                "Exit"
            };
            Menu mainMenu = new Menu(prompt, options);
            int Selectedindex = mainMenu.Run();

            switch (Selectedindex)  //boucle menu principal jusqu'a que le "jeu" se lance
            {
                case 0:
                    statut_menu = false;
                    statut_game = true;
                    Console.Clear();
                    Console.WriteLine();
                    break;
                case 1:
                    statut_menu = false;
                    RunMenuOptions();
                    break;
                case 2:
                    statut_menu = false;
                    statut_game = false;

                    Console.Clear();
                    Console.WriteLine("Merci d'avoir jouer !");
                    Environment.Exit(0);
                    Console.WriteLine("The Text after Exit");
                    break;
            }

            while (statut_game == true)           //Boucle de jeu
            {



                while (statut_inventaire == true)  //boucle d'inventaire jusqu'a que la touche 'tab' soit de nouveau appuyer
                {
                    if (inventaire.Inventory(equipe) == 1)
                    {
                        statut_inventaire = false;
                    }

                    /*statut = Console.ReadKey();

                    if (statut.Key == ConsoleKey.Tab)   //Ferme l'inventaire
                    {
                        statut_inventaire = false;             
                    }
                    */

                }

                while (statut_pause == true)               //boucle de pause si jusqu'a que la touche 'Echap' soit de nouveau appuyer
                {
                    statut = Console.ReadKey();

                    RunMenuOptions();

                    if (statut.Key == ConsoleKey.Escape)   //Ferme l'inventaire
                    {
                        statut_pause = false;
                    }
                }

                carte.Update(player);
                carte.Affichage(player);

                statut = Console.ReadKey();
                player.Deplacement(statut, carte.GetMap());

                if (carte.OnBush(player) == true)
                {
                    Random random = new Random();
                    if (random.Next(0, 100) < 6)
                    {
                        Battle battle = new Battle(equipe, inventaire);
                    }
                }

                if (carte.OnChest(player) == true)
                {
                    if (player.x == 11 && player.y == 82)
                    {
                        if (_chest1 == false)
                        {
                            inventaire.random_item();
                            _chest1 = true;
                        }
                        else
                        {
                            Console.WriteLine("Vous avez déjà ouvert ce coffre");
                        }
                    }
                    if (player.x == 20 && player.y == 199)
                    {
                        if (_chest2 == false)
                        {
                            inventaire.random_item();
                            _chest2 = true;
                        }
                        else
                        {
                            Console.WriteLine("Vous avez déjà ouvert ce coffre");
                        }
                    }
                    if (player.x == 55 && player.y == 232)
                    {
                        if (_chest3 == false)
                        {
                            inventaire.random_item();
                            _chest3 = true;
                        }
                        else
                        {
                            Console.WriteLine("Vous avez déjà ouver ce coffre");
                        }
                    }
                }



                if (equipe.game_over() == true)
                {
                    statut_game = false;
                }

                if (statut.Key == ConsoleKey.Escape)       //Ouvre la pause si 'Echap' est appuyé
                {
                    statut_pause = true;
                }
                if (statut.Key == ConsoleKey.Tab)       //Ouvre l'inventaire si 'TAB' est appuyé
                {
                    statut_inventaire = true;
                }
                if (statut.Key == ConsoleKey.Backspace)       //Ferme le jeu si 'backspace' est appuyé
                {
                    statut_game = false;
                }

            }
        }

        private void RunMenuOptions() //Menu Options
        {
            string prompt = "Menu Options";
            string[] options =
            {
                "Save",
                "Load",
                "Return"
            };
            Menu MenuPause = new Menu(prompt, options);
            int Selectedindex = MenuPause.Run();


            switch (Selectedindex)  //boucle menu Options
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("Voulez-vous sauvegardez votre progression ?");

                    Console.ReadKey();
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Vous avez Charger une partie");

                    Console.ReadKey();
                    break;
                case 2:
                    RunMainMenu();
                    break;
            }
        }
    }
}