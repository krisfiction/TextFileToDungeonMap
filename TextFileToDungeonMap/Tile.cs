using System;
using System.Collections.Generic;
using System.Text;

namespace TextFileToDungeonMap
{
    public class Tile
    {
        public bool IsWalkable { get; set; }
        public char Icon { get; set; }
        public int Y { get; set; }
        public int X { get; set; }

        public Tile(int _x, int _y, char _icon, bool _iswalkable)
        {
            X = _x;
            Y = _y;
            Icon = _icon;
            IsWalkable = _iswalkable;
        }

        public char DisplayIcon()
        {
            return Icon;
        }
    }
}
