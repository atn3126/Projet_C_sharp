
namespace StringManipulation
{
    class ClassInventaire
    {
        static void MenuInventaire()
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Inventory();
            }
        }
        private static bool Inventory()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Personnage");
            Console.WriteLine("2) Objets");
            Console.WriteLine("3) Autre");
            Console.WriteLine("4) Quitter");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Characters();
                    return true;
                case "2":
                    Load();
                    return true;
                case "3":
                    return false;

                case "4":
                    Other();
                    return false;
                default:
                    return true;
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
        }
    }
}