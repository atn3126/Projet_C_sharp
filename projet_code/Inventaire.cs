
using Projet_C_sharp;
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
            ajout_item(potion_soin);

            item potion_attaque = new item();
            potion_attaque.tag = "p_attaque";
            potion_attaque.count = 0;
            ajout_item(potion_attaque);

            item argent = new item();
            argent.tag = "argent";
            argent.count = 0;
            ajout_item(argent);

        }
        public void ajout_item(item objet)
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

        public int Inventory(Equipe equipe)
        {
            ConsoleKeyInfo statut;
            Console.Clear();
            Console.WriteLine("Argent actuelle : ", list_item[2].count);
            Console.WriteLine("Choisissez une action:");
            Console.WriteLine("1) Potion de soin : ", list_item[0].count);
            Console.WriteLine("2) Potion d'attaque : ", list_item[1].count);
            Console.WriteLine("3) Changer de personage");
            Console.WriteLine("4) Quitter");


            Console.Write("\r\nSelect an option: ");
            statut = Console.ReadKey();
            switch (statut.Key.ToString())
            {
                case "D1":
                    use_object(1, equipe);
                    return 0;
                case "D2":
                    use_object(2, equipe);
                    return 0;
                case "D3":
                    equipe.equipe_switch();
                    return 0;
                case "D4":
                    return 0;
                default:
                    return 0;
            }
        }
        public int use_object(int i, Equipe equipe)
        {
            if (list_item[0].count <= 0)
            {
                Console.WriteLine("Vous n'avez plus de cette objet");
                return 0;
            };

            switch (i)
            {
                case 0:
                    list_item[0].count--;
                    equipe.current_entity().lostHp(5);
                    break;
                case 1:
                    list_item[1].count--;

                    break; 
            }
            return 0;
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