using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Projet_C_sharp
{
    
    public class Map
    {
        char[,] _map;
        
        public Map()
        {
            Console.Clear();
            Player player = new Player();
            player.x = 5;
            player.y = 8;
            _map = new char[60, 242];


            Init(player);

        }
        public int Init(Player player)
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\map3.txt");

            /*FileStream fileStream = File.Open("map3.text", FileMode.Open);
            fileStream.Dispose();
            using (FileStream fileStream2 = File.Open("map3.txt", FileMode.Open))
            {

            }
            */


            int x = 0;
            foreach (string line in lines)
            {
                int y = 0;
                foreach (char c in line)
                {
                    if (player.x == x && player.y == y)
                    {
                        _map[x, y] = '0';
                    }
                    else
                    {
                        _map[x, y] = c;
                    }
                    y++;
                }
                x++;
            }

            return 0;
        }
        public void Affichage()
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (_map[i,j] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (_map[i, j] == '$')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(_map[i,j]);
                }

            }
        }
        

        //Input pour afficher le Menu pause et l'invenataire ! NE PAS TOUCHER !

       /* public void Input()
        {
            ConsoleKeyInfo cki;

            cki = Console.ReadKey();
            if(cki.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("test");
            }
        }*/


    }
}
