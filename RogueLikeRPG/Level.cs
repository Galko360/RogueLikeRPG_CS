using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeRPG
{
    internal class Level
    {
        public Map @Map {  get; set; }

        // When player moves from entry , draw 'E'.
        public int EntryX { get; set; }
        public int EntryY { get; set; }

        // When player moves to exit , load new level.
        public int ExitX { get; set; }
        public int ExitY { get; set; }


        public Level(Map map, int entryX, int entryY, int exitX, int exitY)
        {
            Map = map;
            EntryX = entryX;
            EntryY = entryY;
            ExitX = exitX;
            ExitY = exitY;
        }

        public void SetEntry(int x, int y)
        {
            EntryX = x;
            EntryY = y;
        }

        public void SetExit(int x, int y)
        {
            ExitX = x;
            ExitY = y;
        }
    }
}
