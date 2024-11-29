using RogueLikeRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeRPG
{
    internal class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Player(int startX, int startY)
        {
            X = startX;
            Y = startY;
        }

        public void MovePlayer(Map map, char direction)
        {
            int NewX = X;
            int NewY = Y;

            switch (direction)
            {
                case 'w': NewY--; break;
                case 'a': NewX--; break;
                case 's': NewY++; break;
                case 'd': NewX++; break;
                default: return; // ignore invalid input
            }

            if (map.IsWalkable(NewX, NewY))
            {
                map.UpdatePosition(X, Y, NewX, NewY);
                X = NewX;
                Y = NewY;
            }

        }
    }
}