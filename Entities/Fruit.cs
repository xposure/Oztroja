using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oztroja.Sprites;

namespace Oztroja.Entities
{
    public class Fruit : Item
    {
        public Fruit() : base(new Sprite(3, 2)) { }

        public override void Use(Player player)
        {
            player.Heal(10);
        }
    }
}
