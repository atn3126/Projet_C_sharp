using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;

namespace Projet_C_sharp
{
    
    public class Map
    {
        char[,] _map;
        
        public Map(Player player)
        {
            Console.Clear();
            _map = new char[60, 242];


            Init();

        }
        public int Init()
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\map3.txt");
/*
            FileStream fileStream = File.Open("map3.text", FileMode.Open);
            fileStream.Dispose();
            using (FileStream fileStream2 = File.Open("map3.txt", FileMode.Open))
            {

            }*/



            int x = 0;
            foreach (string line in lines)
            {
                int y = 0;
                foreach (char c in line)
                {
                    _map[x, y] = c;
                    y++;
                }
                x++;
            }
            Affichage();
            return 0;
        }

        public int Update(Player player)
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\map3.txt");
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

        public void Affichage(Player player)
        {
            Console.Clear();
            int view = 10;
            int x1 = player.x - view;
            int x2 = player.x + view;
            int y1 = player.y - view * 3;
            int y2 = player.y + view * 3;
            if (x1 < 0) { x1 = 0; }
            if (x2 > _map.GetLength(0)) { x2 = _map.GetLength(0); }
            if (y1 < 0) { y1 = 0; }
            if (y2 > _map.GetLength(1)) { y2 = _map.GetLength(1); }
            for (int i = x1; i < x2; i++)
            {
                for (int j = y1; j < y2; j++)
                {

                    if (_map[i, j] == '#')
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
                    Console.Write(_map[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void Affichage()
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {

                    if (_map[i, j] == '#')
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
                    Console.Write(_map[i, j]);
                }
                Console.WriteLine();
            }
        }

        public bool OnBush(Player player)
        {
            return _map[player.x, player.y] == '*';
        }

       /* public void AffichePlayer(Player player)
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (player.x == i && player.y == j)
                    {
                        Console.Write('0');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }*/


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
