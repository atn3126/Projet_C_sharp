using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_sharp
{


    internal class Menu_P
    {
        public Menu_P()
        {

        }

        public string principal()
        {
            ConsoleKeyInfo statut;
            
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Play");
            Console.WriteLine("2) Options");
            Console.WriteLine("3) Quitter");
            Console.Write("\r\nSelect an option (1,2,3): ");
            statut = Console.ReadKey();
            string cki = statut.Key.ToString();
            

            return cki;   

        }



    }
}
