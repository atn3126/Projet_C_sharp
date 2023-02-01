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
        string current_player;
        public Equipe()
        {
            Entite chevalier = new Entite("chevalier");
            list_equipe[0] = "chevalier";
            current_player = "chevalier";


            Entite archer = new Entite("archer");
            list_equipe[1] = "archer";

            Entite mage = new Entite("mage");
            list_equipe[2] = "mage";


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
        public void equipe_switch()
        {
            string a;
            a = Console.ReadLine();

            current_player = a ; 
        }

        public int game_over()
        {
            if (list_equipe[0] == "mort" && list_equipe[1] == "mort" && list_equipe[2] == "mort")
            {
                return 1;
            }
            return 0;
        }

    }
}
