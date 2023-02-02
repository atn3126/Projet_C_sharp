using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_sharp
{
    
    internal class Equipe : Entite
    {

        private string[] list_equipe = new string[3];
        private string current_player;
        Entite chevalier = new Entite("chevalier");            
        Entite archer = new Entite("archer");
        Entite mage = new Entite("mage");

        public Equipe()
        {
            list_equipe[0] = "chevalier";
            list_equipe[1] = "archer";
            list_equipe[2] = "mage";
            current_player = "chevalier";
        }
        public void lost_crew()
        {
            int i = 0;
            foreach(string item in list_equipe )
            {

                if (current_player == item)
                {
                    list_equipe[i] = "mort";                
                }
                i++;
            }
        }

        public Entite current_entity()
        {
            switch (current_player)
            {
                case "chevalier":
                    return chevalier;
                case "archer":
                    return archer;
                case "mage":
                    return mage;
            }
            Console.WriteLine("Erreur de chargement du joueur actuelle");
            return chevalier;
        }

        public void equipe_switch(Equipe equipe)
        {
            Console.Clear();
            Console.WriteLine("Vous jouez actuellement avec "+equipe.current_player);
            Console.WriteLine("Choisissez quel caractère vous voulez utiliser :");
            Console.WriteLine("1) Chevalier \n2) Archer \n3) Mage ");
            ConsoleKeyInfo statut;
            string a;
            statut = Console.ReadKey();

            if (statut.Key == ConsoleKey.D1)
            {
                a = "chevalier";
            }
            else if (statut.Key == ConsoleKey.D2)
            {
                a = "archer";
            }
            else
            {
                a = "mage";
            }
            current_player = a ;
        }
        public string return_player()
        {
            return current_player;
        }
        public int game_over()
        {
            if (list_equipe[0] == "mort" && list_equipe[1] == "mort" && list_equipe[2] == "mort")
            {
                return 1;
            }
            return 0;
        }

        public string Current_p()
        {
            return current_player;
        }
    }
}
