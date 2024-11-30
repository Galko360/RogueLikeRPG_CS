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
        #region Definitions Symbols
        private const char _entrance = 'E';
        private const char _exit = 'X';
        private const char _horizontalWall = '-';
        private const char _verticalWall = '|';
        private const char _player = '@';
        private const char _enemy = 'M';
        private const char _treasure = '#';
        private const char _walkable = ' ';
        #endregion

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
                    if (y == 0 || y == mapHeight - 1) // Horizontal walls
                    {
                        map[x, y] = _horizontalWall;
                    }
                    else if (x == 0 || x == mapWidth - 1) // Vertical walls
                    {
                        map[x, y] = _verticalWall;
                    }
                    else
                    {
                        map[x, y] = _walkable; // Empty space
                    }
                }
            }
        }

        public void PlacePlayer(int PlayerX, int PlayerY)
        {
            map[PlayerX, PlayerY] = _player;
        }

        public void UpdatePosition(Level level,int oldX, int oldY, int newX, int newY)
        {
            map[oldX, oldY] = _walkable; // clear old position
            map[newX, newY] = _player; // place player in new position

            // When player moves from entry , draw 'E'.
            if (map[level.EntryX, level.EntryY] != _player)
            {
                map[level.EntryX, level.EntryY] = _entrance;
            }

            // When player go to exit, load new level.
            if (map[newX, newY] == _exit)
            {
                // Load new level.
            }
        }

        public bool IsWalkable(int newX, int newY)
        {
            return newX >= 0 && newX < mapWidth &&
                   newY >= 0 && newY < mapHeight && 
                  ( map[newX, newY] == _walkable || map[newX, newY] == _entrance );
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