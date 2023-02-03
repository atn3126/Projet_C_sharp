using StringManipulation;

namespace Projet_C_sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Toute la logique du jeu à était déplacer dans Game.cs
            //ne pas paniquer


            Game myGame = new Game();//Création d'une Nouvelle partie
            myGame.start();//Lancement Nouvelle Partie  
        }
    }
}