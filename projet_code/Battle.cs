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
        Entite monster;
        Equipe player;

        public Battle(Equipe equipe) 
        {
            Console.Clear();
            _battle = new char[21, 150];
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
            monster = new Entite(enemy);
            player = equipe;
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
                if (i == 7)
                {
                    Console.WriteLine("                           YOU                                                        ENEMY\n\n");
                    Console.WriteLine("                         " + player.Current_p() + "                                                     " + enemy);
                    Console.WriteLine("\n                         HP : " + equipe.chevalier._Hp + "                                                     HP : " + monster._Hp);
                }
                for (int j = 0; j < _battle.GetLength(1); j++)
                {
                    Console.Write(_battle[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
