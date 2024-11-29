using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueLikeRPG;
namespace RogueLikeRPG
{
    internal class Map
    {
        private int mapWidth;
        private int mapHeight;
        private char[,] map;

        public Map(int width, int height)
        {
            mapWidth = width;
            mapHeight = height;
            map = new char[mapWidth, mapHeight];
            InitializeMap();
        }

        private void InitializeMap()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    map[x, y] = (x == 0 || x == mapWidth - 1 || y == 0 || y == mapHeight - 1) ? '#' : ' ';
                }
            }
        }

        public void PlacePlayer(int PlayerX, int PlayerY)
        {
            map[PlayerX, PlayerY] = '@';
        }

        public void UpdatePosition(int oldX, int oldY, int newX, int newY)
        {
            map[oldX, oldY] = ' '; // clear old position
            map[newX, newY] = '@'; // place player in new position
        }

        public bool IsWalkable(int newX, int newY)
        {
            return newX >= 0 && newX < mapWidth &&
                   newY >= 0 && newY < mapHeight &&
                   map[newX, newY] == ' '; // ' ' is walkable space
        }

        public void DisplayMap()
        {
            Console.Clear();
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}