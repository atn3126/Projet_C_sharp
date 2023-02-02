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
            bool game = false;
            bool menu = true;
            bool pause = false;
            bool inventaire = false;
            bool _inBattle = false;
            ConsoleKeyInfo statut;

            
            while (menu == true)        //boucle menu principal jusqu'a que le "jeu" se lance
            {

                switch (menu_p.principal())
                {
                    case "D1":

                        menu = false;      
                        game = true;
                        Console.Clear();
                        Console.WriteLine();
                        break;

                    case "D2":
                        menu = false;
                        break;

                    case "D3":
                        menu = false;
                        game = false;
                        break;
                }

            }            
            
            while (game == true)           //Boucle de jeu
            {



                while (inventaire == true)  //boucle d'inventaire jusqu'a que la touche 'tab' soit de nouveau appuyer
                {
                    statut = Console.ReadKey();

                    //Code affichage inventaire


                    if (statut.Key == ConsoleKey.Tab)   //Ferme l'inventaire
                    {
                        inventaire = false;             
                    }

                }

                while (pause == true)               //boucle de pause si jusqu'a que la touche 'Echap' soit de nouveau appuyer
                {
                    statut = Console.ReadKey();

                    //Code affichage pause

                    if (statut.Key == ConsoleKey.Escape)   //Ferme l'inventaire
                    {
                        pause = false;
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
                    pause = true;
                }
                if (statut.Key == ConsoleKey.Tab)       //Ouvre l'inventaire si 'TAB' est appuyé
                {
                    inventaire = true;
                }
                if (statut.Key == ConsoleKey.Backspace)       //Ferme le jeu si 'backspace' est appuyé
                {
                    game = true;
                }

            }
            return 1;
        }
    }
}