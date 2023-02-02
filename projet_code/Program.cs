using StringManipulation;

namespace Projet_C_sharp
{
    internal class Program
    {
        static int Main(string[] args)
        {
            Player player = new Player();
            Map carte = new Map(player);
            Menu_P menu_p = new Menu_P();
            Equipe equipe = new Equipe();
            bool _inBattle = false;
            ClassInventaire inventaire = new ClassInventaire();
            bool statut_game = false;
            bool statut_menu = true;
            bool statut_pause = false;
            bool statut_inventaire = false;
            ConsoleKeyInfo statut;

            
            while (statut_menu == true)        //boucle menu principal jusqu'a que le "jeu" se lance
            {

                switch (menu_p.principal())
                {
                    case "D1":

                        statut_menu = false;
                        statut_game = true;
                        Console.Clear();
                        Console.WriteLine();
                        break;

                    case "D2":
                        statut_menu = false;
                        break;

                    case "D3":
                        statut_menu = false;
                        statut_game = false;
                        break;
                }

            }            
            
            while (statut_game == true)           //Boucle de jeu
            {



                while (statut_inventaire == true)  //boucle d'inventaire jusqu'a que la touche 'tab' soit de nouveau appuyer
                {

                    inventaire.Inventory(equipe);

                    statut = Console.ReadKey();

                    if (statut.Key == ConsoleKey.Tab)   //Ferme l'inventaire
                    {
                        statut_inventaire = false;             
                    }

                }

                while (statut_pause == true)               //boucle de pause si jusqu'a que la touche 'Echap' soit de nouveau appuyer
                {
                    statut = Console.ReadKey();

                    //Code affichage pause

                    if (statut.Key == ConsoleKey.Escape)   //Ferme l'inventaire
                    {
                        statut_pause = false;
                    }
                }

                carte.Update(player);
                carte.Affichage(player);
                statut = Console.ReadKey();

                player.Deplacement(statut);

                if (carte.OnBush(player) == true)
                {
                    Random random = new Random();
                    if (random.Next(0, 100) < 4)
                    {
                        Battle battle = new Battle(equipe);
                        _inBattle = true;
                    }
                }

                while (_inBattle== true)
                {
                    
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
                    statut_game = true;
                }

            }
            return 1;
        }
    }
}