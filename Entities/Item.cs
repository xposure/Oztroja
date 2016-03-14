using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oztroja.Sprites;

namespace Oztroja.Entities
{
    public class Item 
    {
        public static Item soda, fruit;

        static Item()
        {
            soda = new Soda();
            fruit = new Fruit();
        }

        private Sprite _sprite;

        public Item(Sprite sprite)
        {
            _sprite = sprite;
        }

        public void Draw(int x, int y)
        {
            _sprite.Draw(x, y);
        }

        public virtual void Use(Player player)
        {

        }
    }
}
