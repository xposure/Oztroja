using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oztroja.Sprites;

namespace Oztroja.Entities
{
    public class Wall
    {
        public static Wall createWall1(int x, int y) { return new Wall(x, y, new Sprite(5, 2), new Sprite(0, 6)); }
        public static Wall createWall2(int x, int y) { return new Wall(x, y, new Sprite(6, 2), new Sprite(1, 6)); }
        public static Wall createWall3(int x, int y) { return new Wall(x, y, new Sprite(7, 2), new Sprite(2, 6)); }
        public static Wall createWall4(int x, int y) { return new Wall(x, y, new Sprite(0, 3), new Sprite(3, 6)); }
        public static Wall createWall5(int x, int y) { return new Wall(x, y, new Sprite(3, 3), new Sprite(4, 6)); }
        //public static Wall createWall6(int x, int y) { return new Wall(x, y, new Sprite(5, 3), new Sprite(5, 6)); }
        public static Wall createWall7(int x, int y) { return new Wall(x, y, new Sprite(6, 3), new Sprite(5, 6)); }
        public static Wall createWall8(int x, int y) { return new Wall(x, y, new Sprite(7, 3), new Sprite(6, 6)); }

        private Sprite _sprite;
        private Sprite _dmgSprite;

        public bool IsDamaged = false;

        public Wall(int x, int y, Sprite sprite, Sprite dmgSprite)
        {
            _sprite = sprite;
            _dmgSprite = dmgSprite;
        }

        public void Draw(Screen screen, int x, int y)
        {
            if (IsDamaged)
                _dmgSprite.Draw(screen, x, y);
            else
                _sprite.Draw(screen, x, y);
        }
    }
}
