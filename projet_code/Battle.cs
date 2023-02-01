using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_sharp
{
    internal class Battle
    {
        char[,] _battle;
        string enemy;

        public Battle() 
        {
            Console.Clear();
            _battle = new char[27, 150];
            Random random = new Random();
            int i = random.Next(0, 100);
            if (random.Next(0, 100) < 50)
                enemy = "Loup";
            else if (random.Next(0, 100) < 85)
                enemy = "Gobelin";
            else if (random.Next(0, 100) < 99)
                enemy = "Orc";
            else
                enemy = "Mage_noir";
            Entite monster = new Entite(enemy);
            Init();
        }

        public int Init()
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\battle.txt");
            int x = 0;
            foreach (string line in lines)
            {
                int y = 0;
                foreach (char c in line)
                {
                    _battle[x, y] = c;
                    y++;
                }
                x++;
            }
            Console.WriteLine("\n      You encounter " + enemy + ".");
            Affichage();

            return 0;
        }

        public void Affichage()
        {
            for (int i = 0; i < _battle.GetLength(0); i++)
            {
                for (int j = 0; j < _battle.GetLength(1); j++)
                {
                    Console.Write(_battle[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
