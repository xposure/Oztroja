using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oztroja.Sprites
{
    public class Tile
    {
        public static Tile floor1, floor2, floor3, floor4, floor5, floor6, floor7, floor8;
        public static Tile exit;
        public static Tile outerWall1, outerWall2, outerWall3;
        public static Tile wall1, wall2, wall3, wall4, wall5, wall6, wall7, wall8;

        public static void Initialize()
        {
            floor1 = new Tile(new Sprite(0, 4));
            floor2 = new Tile(new Sprite(1, 4));
            floor3 = new Tile(new Sprite(2, 4));
            floor4 = new Tile(new Sprite(3, 4));
            floor5 = new Tile(new Sprite(4, 4));
            floor6 = new Tile(new Sprite(5, 4));
            floor7 = new Tile(new Sprite(6, 4));
            floor8 = new Tile(new Sprite(7, 4));
            exit = new Tile(new Sprite(4, 2));
            outerWall1 = new Tile(new Sprite(1, 3));
            outerWall2 = new Tile(new Sprite(2, 3));
            outerWall3 = new Tile(new Sprite(4, 3));
        }

        private Sprite _sprite;
        public Tile(Sprite sprite)
        {
            _sprite = sprite;
        }

        public void Draw(int x, int y)
        {
            _sprite.Draw(x, y);
        }

    }
}
