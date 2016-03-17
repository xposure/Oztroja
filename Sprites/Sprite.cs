using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oztroja.Sprites
{
    public class Sprite
    {
        private int _col, _row;

        public Sprite(int col, int row)
        {
            _col = col;
            _row = row;
        }

        public void Draw(Screen screen, int x, int y)
        {
            SpriteSheet.spriteSheet.Draw(screen, x, y, _col, _row);
        }
    }
}
