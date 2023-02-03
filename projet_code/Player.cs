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
        public void Deplacement(ConsoleKeyInfo statut, char[,] _map)
        {
            if (statut.Key == ConsoleKey.UpArrow)
            {
                if (_map[x - 1,y] == ' ' || _map[x - 1, y] == '*' || _map[x - 1, y] == '$' || _map[x - 1, y] == '.' || _map[x - 1, y] == '▲')
                    x -= 1;
            }
            if (statut.Key == ConsoleKey.DownArrow)
            {
                if (_map[x + 1, y] == ' ' || _map[x + 1, y] == '*' || _map[x + 1, y] == '$' || _map[x + 1, y] == '.' || _map[x + 1, y] == '▲')
                    x += 1;
            }
            if (statut.Key == ConsoleKey.LeftArrow)
            {
                if (_map[x, y - 1] == ' ' || _map[x, y - 1] == '*' || _map[x, y - 1] == '$' || _map[x, y - 1] == '.' || _map[x, y - 1] == '▲')
                    y -= 1;
            }
            if (statut.Key == ConsoleKey.RightArrow)
            {
                if (_map[x, y + 1] == ' ' || _map[x, y + 1] == '*' || _map[x, y + 1] == '$' || _map[x, y + 1] == '.' || _map[x, y + 1] == '▲')
                    y += 1;
            }
        }
    }
}
