
using Projet_C_sharp;
using System;
using System.Reflection.Metadata;

namespace StringManipulation
{
    class ClassInventaire
    {
        public class item
        {
            public string tag;
            public int count;
        }
        List<item> list_item = new List<item>();

        public ClassInventaire()
        {
            item potion_soin = new item();
            potion_soin.tag = "p_soin";
            potion_soin.count = 0;
            ajout_item_list(potion_soin);

            item potion_attaque = new item();
            potion_attaque.tag = "p_attaque";
            potion_attaque.count = 0;
            ajout_item_list(potion_attaque);

            item argent = new item();
            argent.tag = "argent";
            argent.count = 0;
            ajout_item_list(argent);

        }

        public void ajout_item_list(item objet)
        {
            list_item.Add(objet);
        }

        public void ajout_n(int objet)
        {
            switch (objet)
            {
                case 0:         //potion de soin
                    list_item[0].count += objet;
                    break;
                case 1:         //potion d'attaque
                    list_item[1].count += objet;
                    break;
                case 2:         //argent
                    list_item[3].count += objet;
                    break;

                default: break;
            }
        }

        public void remove(int i)
        {
            list_item[i].count--;
        }

        public int Inventory(Equipe equipe)
        {
            while (true)
            {
                ConsoleKeyInfo statut;
                Console.Clear();
                Console.WriteLine("Argent actuelle : "+ list_item[2].count + " ; Potion de soin: "+ list_item[0].count + " ; Potion d'attaque : "+ list_item[1].count+"\n");
                Console.WriteLine("Choisissez une action:");
                Console.WriteLine("1) Utiliser une potion");
                Console.WriteLine("2) Changer de personage");
                Console.WriteLine("3) Retour");


                //Console.Write("\r\nSelect an option: ");
                statut = Console.ReadKey();
                switch (statut.Key.ToString())
                {
                    case "D1":
                        Console.Clear();
                        use_object(equipe);
                        return 0;
                    case "D2":
                        equipe.equipe_switch(equipe);
                        return 0;
                    case "D3":
                        return 1;

                }           
            }
        }

        public void random_item()
        {
            ConsoleKeyInfo statut;
            Random potion = new Random();
            Random argent = new Random();
            int a = potion.Next(0,3);
            int b = argent.Next(5,20);

            Console.Clear() ;
            Console.WriteLine("Vous trouvez un coffre ! Vous l'ouvrez et récupérez...");

            if (a <= 1)
            {
                Console.WriteLine("Une potion de Vie !\n");
                list_item[0].count ++;
            }
            else 
            {
                Console.WriteLine("Une potion d'attaque !\n");
                list_item[1].count++;
            }

            Console.WriteLine("Ainsi que " + b + " pièce d'or !");
            list_item[2].count += b;        
            statut = Console.ReadKey();


        }

        public int GetItemNumber(int i)
        {
            return list_item[i].count;
        }

        public int use_object(Equipe equipe)
        {
            while (true)
            {
                ConsoleKeyInfo statut;
                int choix = -1;
                Console.WriteLine("Potion de soin: " + list_item[0].count + " ; Potion d'attaque : " + list_item[1].count + "\n");
                Console.WriteLine("HP actuelle : " + equipe.current_entity().getHp() + " ; Attaque actuelle : " + equipe.current_entity().getAttack() + "\n");
                Console.WriteLine("Quel potion voulez-vous utiliser ?");
                Console.WriteLine("1) Potion de vie \n2) Potion d'attaque \n3) Retour");

                statut = Console.ReadKey();
                if (statut.Key == ConsoleKey.D1)
                {
                    choix = 0;
                }
                else if (statut.Key == ConsoleKey.D2)
                {
                    choix = 1;
                }
                else
                {
                    return 0;
                }


                if (list_item[choix].count <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nVous n'avez plus de cette objet \n");
                }
                else
                {
                    switch (choix)
                    {
                        case 0:
                            list_item[choix].count--;
                            equipe.current_entity().giveHp();
                            return 0;
                        case 1:
                            list_item[choix].count--;
                            equipe.current_entity().giveAttackBuff();
                            return 0;
                    }    
                }
            }
        }


        /*
        public void MenuInventaire(Equipe equipe)
        {
            int showMenu = 1;
            while (showMenu == 1)
            {
                showMenu = Inventory(equipe);
            }
        }

        private static void Characters()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.Write("\r\nPress Enter to continue");
            Console.ReadLine();
        }

        private static void Load()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.Write("\r\nPress Enter to continue");
            Console.ReadLine();
        }

        private static void Other()
        {
            Console.Clear();
            Console.WriteLine("Autre");
            Console.Write("\r\nPress Enter to continue");
            Console.ReadLine();
        }*/
    }
}