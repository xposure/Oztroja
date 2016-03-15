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

            if (current != null)
            {
                current._allMobs.Clear();
                current._tiles = null;
                current._mobs = null;
                current._items = null;
                current._walls = null;
            }

            current = new Level(depth);
            current.Generate();
        }

        private Random _random;
        private int _width, _height;
        private Tile[,] _tiles;
        private Item[,] _items;
        private Wall[,] _walls;
        private Mob[,] _mobs;
        private List<Mob> _allMobs = new List<Mob>();

        private int _depth, _turn;

        public int Depth { get { return _depth; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }

        private Level(int depth)
        {
            _depth = depth;
            _random = new Random((int)((depth * 2654435761)));

            //System.Diagnostics.Debug.WriteLine(r);
            
        }

        private bool CanPlace(int x, int y)
        {
            if (x == 1 && y == 1)
                return false;

            if (x == _width - 2 && y == _height - 2)
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
            _depth++;
            _width = 10;
            _height = 10;
            _tiles = new Tile[_width, _height];
            _items = new Item[_width, _height];
            _mobs = new Mob[_width, _height];
            _walls = new Wall[_width, _height];

            _allMobs.Add(Game1.player);

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
                    _walls[x, y] = _random.Choose<Func<int, int, Wall>>(Wall.createWall1, Wall.createWall2, Wall.createWall3, Wall.createWall4, Wall.createWall5, Wall.createWall7, Wall.createWall8)(x, y);
                    walls--;
                }
            }

            var enemies = (int)Math.Log(_depth, 2f);
            while (enemies > 0)
            {
                var x = _random.Next(1, _width - 1);
                var y = _random.Next(1, _height - 1);

                if (CanPlace(x, y))
                {
                    _mobs[x, y] = _random.Choose<Func<int, int, Mob>>(Enemy.creatEnemy1, Enemy.creatEnemy2)(x, y);
                    _allMobs.Add(_mobs[x, y]);

                    enemies--;
                }
            }

            _mobs[1, 1] = Game1.player;
            _tiles[_width - 2, _height - 2] = Tile.exit;
            Game1.player.SetPosition(1, 1);
        }

        public void SetItem(int x, int y, Item val)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height)
                return;

            _items[x, y] = val;
        }

        public Item GetItem(int x, int y)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height)
                return null;

            return _items[x, y];
        }

        public void SetMob(int x, int y, Mob val)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height)
                return;

            _mobs[x, y] = val;
        }

        public Mob GetMob(int x, int y)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height)
                return null;

            return _mobs[x, y];
        }

        public Wall GetWall(int x, int y)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height)
                return null;

            return _walls[x, y];
        }

        public void SetWall(int x, int y, Wall val)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height)
                return;

            _walls[x, y] = val;
        }

        public Tile GetTile(int x, int y)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height)
                return null;

            return _tiles[x, y];
        }

        public void Update(float dt)
        {
            for (var x = 0; x < _width; x++)
            {
                for (var y = 0; y < _height; y++)
                {
                    if (_mobs[x, y] != null) _mobs[x, y].Update(dt);
                }
            }

            var mob = _allMobs[_turn % _allMobs.Count];
            if (!mob.IsAlive || mob.Turn(dt))
                _turn++;
        }

        public void Draw()
        {
            for (var x = 0; x < current._width; x++)
            {
                for (var y = 0; y < current._height; y++)
                {
                    _tiles[x, y].Draw(x * 32, y * 32);
                    if (_walls[x, y] != null)
                        _walls[x, y].Draw(x * 32, y * 32);
                    else if (_mobs[x, y] != null)
                        _mobs[x, y].Draw(x * 32, y * 32);
                    else if (_items[x, y] != null)
                        _items[x, y].Draw(x * 32, y * 32);
                }
            }
        }
    }
}
