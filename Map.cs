using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet_C_sharp
{
    struct Player
    {
        public int x;
        public int y;
    }
    internal class Map
    {
        char[,] _map;
        
        public Map()
        {
            Player player = new Player();
            player.x = 5;
            player.y = 8;
            _map = new char[20, 20];
            
            Init(player);

        }
        public int Init(Player player)
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (player.x == i && player.y == j)
                    {
                        _map[i, j] = '-';
                    }
                    else
                    {
                        _map[i, j] = 'X';
                    }

                }
                
            }
            
            return 0;
        }
        public void Affichage()
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    Console.Write(_map[i,j]);
                }

            }
        }
        public void Deplacement()
        {

            Console.WriteLine("Deplacement fait avec succée");

        }




    }
}
