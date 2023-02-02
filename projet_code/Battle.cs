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
        Entite p_stats;
        int index1 = 0;
        List<string> choices;

        public Battle(Equipe equipe) 
        {
            Console.Clear();
            _battle = new char[13, 150];
            Random random = new Random();
            int i = random.Next(0, 100);
            if (i < 50)
                enemy = "Loup";
            else if (i < 85)
                enemy = "Gobelin";
            else if (i < 99)
                enemy = "Orc";
            else
                enemy = "Mage_noir";
            monster = new Entite(enemy);
            player = equipe;
            p_stats = player.current_entity();
            Init();
        }

        public int Init()
        {
            Console.Clear();
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
                    Console.WriteLine("                         " + player.Current_p() + "                                                    " + enemy);
                    Console.WriteLine("\n                         HP : " + p_stats._Hp + " / " + p_stats._HpMax + "                                               HP : " + monster._Hp + " / " + monster._HpMax);
                    Console.WriteLine("                         MP : " + p_stats._Mana + " / " + p_stats._ManaMax + "                                                   MP : " + monster._Mana + " / " + monster._ManaMax);
                    Console.WriteLine("\n                         Attack : " + p_stats._Attack + "                                                  Attack : " + monster._Attack);
                    Console.WriteLine("                         Defense : " + p_stats._Defense + "                                                 Defense : " + monster._Defense);
                }
                for (int j = 0; j < _battle.GetLength(1); j++)
                {
                    Console.Write(_battle[i, j]);
                }
                Console.WriteLine();
            }
            ActionMenu();
        }

        public void ActionMenu()
        {
            choices = new List<string>() { "Attack", "Magic", "Inventory", "Flee" };
            ConsoleKeyInfo keyInfo;
            keyInfo= Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                if (index1 + 1 < 4)
                {
                    index1++;
                }
            }
            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (index1 - 1 >= 0)
                {
                    index1--;
                }
            }
            for (int i = 0; i < choices.Count(); i++) 
            {
                Console.Write("                ");
                if (i == index1)
                    Console.Write("  >");
                else
                    Console.Write("   ");
                Console.Write(choices[i]);
            }
        }
    }
}
