namespace Projet_C_sharp
{
    internal class Program
    {
        static int Main(string[] args)
        {
            Map carte = new Map();
            bool game = false;
            bool menu = false;
            bool pause = false;
            bool inventaire = false;
            ConsoleKeyInfo statut;

            while (game == false)            //Boucle de jeu
            {

                while (menu == true)        //boucle menu principal jusqu'a que le "jeu" se lance
                {

                //code affichage menu

                }

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


                carte.Affichage();
                statut = Console.ReadKey();


                if (statut.Key == ConsoleKey.Escape)       //Ouvre la pause si 'Echap' est appuyer
                {
                    pause = true;
                }
                if (statut.Key == ConsoleKey.Tab)       //Ouvre l'inventaire si 'TAB' est appuyer
                {
                    inventaire = true;
                }

            }
            return 1;
        }
    }
}