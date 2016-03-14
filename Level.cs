using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oztroja.Entities;
using Oztroja.Sprites;

namespace Oztroja
{
    public class Level
    {
        public static Level current;

        public static void GenNextLevel()
        {
            var depth = current == null ? 1 : current.Depth;
            current = new Level(depth);
            current.Generate();
        }

        private Random _random;
        private int _width, _height;
        private Tile[,] _tiles;
        private Item[,] _items;
        private Wall[,] _walls;
        private Mob[,] _mobs;

        private int _depth;

        public int Depth { get { return _depth; } }

        private Level(int depth)
        {
            _depth = depth;
            _random = new Random((int)((depth * 2654435761) % (2 ^ 32)));

        }

        private bool CanPlace(int x, int y)
        {
            if (x == 1 && y == 1)
                return false;

            if (x == _width - 1 && y == _height - 1)
                return false;

            if (x == 0 || x == _width - 1 || y == 0 || y == _height - 1)
                return false;

            if (_mobs[x, y] != null)
                return false;

            if (_items[x, y] != null)
                return false;

            if (_walls[x, y] != null)
                return false;

            return true;
        }

        private void Generate()
        {
            _width = 8;
            _height = 8;
            _tiles = new Tile[_width, _height];
            _items = new Item[_width, _height];
            _mobs = new Mob[_width, _height];
            _walls = new Wall[_width, _height];

            for (var x = 0; x < _width; x++)
            {
                for (var y = 0; y < _height; y++)
                {
                    if (x == 0 || x == _width - 1 || y == 0 || y == _height - 1)
                    {
                        _tiles[x, y] = _random.Choose(Tile.outerWall1, Tile.outerWall2, Tile.outerWall3);
                    }
                    else
                    {
                        _tiles[x, y] = _random.Choose(Tile.floor1, Tile.floor2, Tile.floor3, Tile.floor4, Tile.floor5, Tile.floor6, Tile.floor7, Tile.floor8);
                    }
                }
            }

            var food = _random.Next(1, 5);
            while (food > 0)
            {
                var x = _random.Next(1, _width - 1);
                var y = _random.Next(1, _height - 1);

                if (CanPlace(x, y))
                {
                    _items[x, y] = _random.Choose(Item.soda, Item.fruit);
                    food--;
                }
            }

            var walls = _random.Next(5, 9);
            while (walls > 0)
            {
                var x = _random.Next(1, _width - 1);
                var y = _random.Next(1, _height - 1);

                if (CanPlace(x, y))
                {
                    _walls[x, y] = _random.Choose(Wall.wall1, Wall.wall2, Wall.wall3, Wall.wall4, Wall.wall5, Wall.wall6, Wall.wall7, Wall.wall8);
                    walls--;
                }
            }
        }

        public void Update(float dt)
        {

        }

        public void Draw()
        {
            for (var x = 0; x < current._width; x++)
            {
                for (var y = 0; y < current._height; y++)
                {
                    _tiles[x, y].Draw(x * 32, y * 32);
                    if (_items[x, y] != null)
                        _items[x, y].Draw(x * 32, y * 32);
                    else if (_walls[x, y] != null)
                        _walls[x, y].Draw(x * 32, y * 32);
                }
            }
        }
    }
}
