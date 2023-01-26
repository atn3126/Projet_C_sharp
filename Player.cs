using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_sharp
{


    public class Player
    {
        public int x;
        public int y;
        public Player()
        {
            x = 51;
            y = 4;
        }
        public void Deplacement(ConsoleKeyInfo statut)
        {
            if (statut.Key == ConsoleKey.UpArrow)
            {
                x -= 1;
            }
            if (statut.Key == ConsoleKey.DownArrow)
            {
                x += 1;
            }
            if (statut.Key == ConsoleKey.LeftArrow)
            {
                y -= 1;
            }
            if (statut.Key == ConsoleKey.RightArrow)
            {
                y += 1;
            }
        }
    }
}
