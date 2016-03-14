using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oztroja.Sprites;

namespace Oztroja.Entities
{
    public class Wall
    {
        public static Wall wall1 = new Wall(new Sprite(5, 2));
        public static Wall wall2 = new Wall(new Sprite(6, 2));
        public static Wall wall3 = new Wall(new Sprite(7, 2));
        public static Wall wall4 = new Wall(new Sprite(0, 3));
        public static Wall wall5 = new Wall(new Sprite(3, 3));
        public static Wall wall6 = new Wall(new Sprite(5, 3));
        public static Wall wall7 = new Wall(new Sprite(6, 3));
        public static Wall wall8 = new Wall(new Sprite(7, 3));
        private Sprite _sprite;

        public Wall(Sprite sprite)
        {
            _sprite = sprite;
        }

        public void Draw(int x, int y)
        {
            _sprite.Draw(x, y);
        }
    }
}
