using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TextFileToDungeonMap
{
    class Map
    {
        private readonly char Floor = '.';


        private const int MapSizeX = 110;
        private const int MapSizeY = 35;

        private readonly Tile[,] GameMap = new Tile[MapSizeX, MapSizeY];

        private int PlayerPOSX { get; set; }
        private int PlayerPOSY { get; set; }
        private readonly char PlayerIcon = '@';


        public void ReadFile()
        {
            //int Row = 0;
            int Column = 0;


            StreamReader reader = new StreamReader(@"Maps\Map1.txt");
            while (reader.EndOfStream == false)
            {
                string line = reader.ReadLine();
                char[] chars = line.ToCharArray();

                for (int i = 0; i < chars.Length; i++)
                {
                    if (chars[i] == '.' || chars[i] == '+')
                    {
                        GameMap[i, Column] = new Tile(i, Column, chars[i], true);
                    }
                    else
                    {
                        GameMap[i, Column] = new Tile(i, Column, chars[i], false);
                    }

                }
                Column++;
            }
            reader.Close();

        }




        public void FillMap()
        {
            for (int x = 0; x <= MapSizeX - 1; x++)
            {
                for (int y = 0; y <= MapSizeY - 1; y++)
                {
                    GameMap[x, y] = new Tile(x, y, ' ', false);
                }
            }
        }

        public void Display()
        {
            for (int x = 0; x <= MapSizeX - 1; x++)
            {
                for (int y = 0; y <= MapSizeY - 1; y++)
                {
                    Tile CurrentTile = (Tile)GameMap[x, y];
                    char _icon = CurrentTile.Icon;

                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(_icon);
                }
            }
        }

        public void DisplayPlayerPosition()
        {
            Console.SetCursorPosition(110, 0);
            Console.WriteLine($"Player Position: x{PlayerPOSX}, y{PlayerPOSY}");
        }

        public void PlacePlayer()
        {
            Random random = new Random();
            int _placed = 0;

            do
            {
                int _randX = random.Next(0, MapSizeX);
                int _randY = random.Next(0, MapSizeY);

                Tile CurrentTile = (Tile)GameMap[_randX, _randY];
                bool _iswalkable = CurrentTile.IsWalkable;

                if (_iswalkable && _placed == 0)
                {
                    CurrentTile.Icon = PlayerIcon;

                    PlayerPOSX = _randX;
                    PlayerPOSY = _randY;
                    _placed = 1;
                }
            } while (_placed == 0);

            DisplayPlayerPosition();
        }



        //todo switch icon() to check if floor or door is being walked through
        //todo right now if you walk through a door it is replaced with floor icon
        public void MovePlayer(string _direction)
        {
            if (_direction == "North")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY - 1];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSY--;
                    DisplayPlayerPosition();
                }
            }
            if (_direction == "South")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY + 1];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSY++;
                    DisplayPlayerPosition();
                }
            }
            if (_direction == "West")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX - 1, PlayerPOSY];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSX--;
                    DisplayPlayerPosition();
                }
            }
            if (_direction == "East")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX + 1, PlayerPOSY];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSX++;
                    DisplayPlayerPosition();
                }
            }
            if (_direction == "NorthWest")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX - 1, PlayerPOSY - 1];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSX--;
                    PlayerPOSY--;
                    DisplayPlayerPosition();
                }
            }
            if (_direction == "NorthEast")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX + 1, PlayerPOSY - 1];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSX++;
                    PlayerPOSY--;
                    DisplayPlayerPosition();
                }
            }
            if (_direction == "SouthWest")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX - 1, PlayerPOSY + 1];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSX--;
                    PlayerPOSY++;
                    DisplayPlayerPosition();
                }
            }
            if (_direction == "SouthEast")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX + 1, PlayerPOSY + 1];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSX++;
                    PlayerPOSY++;
                    DisplayPlayerPosition();
                }
            }
        }
    }
}
