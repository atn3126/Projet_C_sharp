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

        public Battle() 
        {
            Console.Clear();
            _battle = new char[60, 150];
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
