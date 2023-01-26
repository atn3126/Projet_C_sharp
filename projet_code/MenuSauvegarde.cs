/*using ConsoleApp;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Sauvegarde");
            Console.WriteLine("2) Charger");
            Console.WriteLine("3) Quitter");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Save();
                    return true;
                case "2":
                    Load();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }

        private static void Save()
        {
            Console.Clear();
            Console.WriteLine("Voulez vous Sauvegardez votre progression");
            ClassSerialization.Save();
            Console.Write("\r\nPress Enter to continue");
            Console.ReadLine();
        }

        private static void Load()
        {
            Console.Clear();
            Console.WriteLine("Chargez une partie")
            ClassSerialization.Open();
            Console.Write("\r\nPress Enter to continue");
            Console.ReadLine();
        }
    }
}*/