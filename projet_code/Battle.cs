using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
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
        Entite chevalier;
        Entite archer;
        Entite mage;
        int index1 = 0;
        bool _inBattle = true;
        List<string> choices;
        int damage;
        int damageEnemy;

        public Battle(Equipe equipe)
        {
            choices = new List<string>() { "Attack", "Magic", "Inventory", "Switch hero", "Escape" };
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
            chevalier = player.chevalier_entity();
            archer = player.archer_entity();
            mage = player.mage_entity();
            Init();
        }

        public void Init()
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
            BattleLoop();
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
        }

        public void ActionMenu()
        {
            for (int i = 0; i < choices.Count(); i++)
            {
                Console.Write("         ");
                if (i == index1)
                    Console.Write("  > ");
                else
                    Console.Write("   ");
                Console.Write(choices[i]);
            }


            ConsoleKeyInfo keyInfo;
            keyInfo= Console.ReadKey();
            Console.Clear();
            if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                if (index1 + 1 < choices.Count())
                {
                    index1++;
                }
                Console.WriteLine("\n");
            }


            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (index1 - 1 >= 0)
                {
                    index1--;
                }
                Console.WriteLine("\n");
            }

            
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                switch (choices[index1])
                {
                    case "Attack":
                        Random random1 = new Random();
                        damage = p_stats._Attack - random1.Next(0, monster._Defense);
                        if (monster.dodge_test() == false)
                        {
                            monster._Hp -= damage;
                            Console.WriteLine("\n      You dealt " + damage + " damage.");
                        }
                        else
                        {
                            Console.WriteLine("\n      " + monster._Tag + " dodged the attack.");
                        }
                        Enemy_Attack();
                        index1 = 0;
                        break;

                    case "Magic":
                        if (player.Current_p() == "chevalier")
                        {
                            Console.WriteLine("\n      The knight doesn't have any spell.");
                        }

                        if (player.Current_p() == "archer")
                        {
                            if (p_stats._Mana > 0)
                            {
                                choices = new List<string>() { "Pierce shot - 3 MP", "Back" };
                                Console.WriteLine("\n");
                            }
                            else
                            {
                                Console.WriteLine("\n      You don't have any MP left.");
                            }
                            
                        }
                            
                        if (player.Current_p() == "mage")
                        {
                            if (p_stats._Mana > 0)
                            {
                                choices = new List<string>() { "Heal - 5 MP", "Attack decrease - 5 MP", "Back" };
                                Console.WriteLine("\n");
                            }
                            else
                            {
                                Console.WriteLine("\n      You don't have any MP left.");
                            }
                        }
                            
                        index1 = 0;
                        break;

                    case "Pierce shot - 3 MP":
                        choices = new List<string>() { "Attack", "Magic", "Inventory", "Switch hero", "Escape" };
                        Random random2 = new Random();
                        if (monster.dodge_test() == false)
                        {
                            damage = p_stats._Attack;
                            monster._Hp -= damage;
                            p_stats._Mana -= 3;
                            Console.WriteLine("\n      Your arrow pierce through the armor and deal " + damage + " damage.");
                        }
                        else
                        {
                            p_stats._Mana -= 3;
                            Console.WriteLine("\n      " + monster._Tag + " dodged the attack.");
                        }
                        Enemy_Attack();
                        index1 = 0;
                        break;

                    case "Heal - 5 MP":
                        choices = new List<string>() { "Attack", "Magic", "Inventory", "Switch hero", "Escape" };

                        if (chevalier._Hp + 15 > chevalier._HpMax)
                            chevalier._Hp = chevalier._HpMax;
                        else
                            chevalier._Hp += 15;

                        if (archer._Hp + 15 > archer._HpMax)
                            archer._Hp = archer._HpMax;
                        else
                            archer._Hp += 15;

                        if (mage._Hp + 15 > mage._HpMax)
                            mage._Hp = mage._HpMax;
                        else
                            mage._Hp += 15;

                        p_stats._Mana -= 5;
                        Console.WriteLine("\n      Everybody were healed 15HP.");

                        Enemy_Attack();
                        index1 = 0;
                        break;

                    case "Attack decrease - 5 MP": //Don't work, don't know why
                        choices = new List<string>() { "Attack", "Magic", "Inventory", "Switch hero", "Escape" };

                        monster._Attack -= 2;

                        p_stats._Mana -= 5;
                        Console.WriteLine("\n      " + monster._Tag + " attack decreased by 2.");

                        Enemy_Attack();
                        index1 = 0;
                        break;

                    case "Switch hero":
                        choices = new List<string>() { player.GetListEquipe(0), player.GetListEquipe(1), player.GetListEquipe(2), "Back" };
                        index1 = 0;
                        Console.WriteLine("\n");
                        break;

                    case "chevalier":
                        choices = new List<string>() { "Attack", "Magic", "Inventory", "Switch hero", "Escape" };
                        player.SwitchToChevalier();
                        p_stats = player.current_entity();
                        Console.WriteLine("\n      You switched to chevalier.");
                        Enemy_Attack();
                        index1 = 0;
                        break;

                    case "archer":
                        choices = new List<string>() { "Attack", "Magic", "Inventory", "Switch hero", "Escape" };
                        player.SwitchToArcher();
                        p_stats = player.current_entity();
                        Console.WriteLine("\n      You switched to archer.");
                        Enemy_Attack();
                        index1 = 0;
                        break;

                    case "mage":
                        choices = new List<string>() { "Attack", "Magic", "Inventory", "Switch hero", "Escape" };
                        player.SwitchToMage();
                        p_stats = player.current_entity();
                        Console.WriteLine("\n      You switched to mage.");
                        Enemy_Attack();
                        index1 = 0;
                        break;

                    case "mort":
                        Console.WriteLine("\n      This hero is already dead.");
                        break;

                    case "Escape":
                        _inBattle = false;
                        break;

                    case "Back":
                        choices = new List<string>() { "Attack", "Magic", "Inventory", "Switch hero", "Escape" };
                        index1 = 0;
                        Console.WriteLine("\n");
                        break;

                    default:
                        break;
                }
            }
        }

        public void Enemy_Attack()
        {
            Random randomEnemy = new Random();
            damageEnemy = monster._Attack - randomEnemy.Next(0, p_stats._Defense);
            if (p_stats.dodge_test() == false)
            {
                if (damageEnemy < 0)
                {
                    damageEnemy = 0;
                }
                p_stats._Hp -= damageEnemy;
                Console.WriteLine("     " + monster._Tag + " dealt " + damageEnemy + " damage.");
            }
            else
            {
                Console.WriteLine("      You dodged the attack.");
            }
        }

        public void BattleLoop()
        {
            while (_inBattle == true) 
            {
                Affichage();
                ActionMenu();
                if (p_stats.death_test() == true) 
                {
                    Console.WriteLine("\n      " + p_stats._Tag + " died.");
                    player.lost_crew();
                    choices = new List<string>() { player.GetListEquipe(0), player.GetListEquipe(1), player.GetListEquipe(2)};
                }
                if (monster._Hp <= 0)
                {
                    _inBattle = false;
                    Console.WriteLine("\n      You've won!");
                    Affichage();
                    Thread.Sleep(2000);
                }
                if (player.game_over() == true)
                {
                    _inBattle = false;
                    Console.WriteLine("\n      You lose!");
                    Affichage();
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
