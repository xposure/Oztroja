using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oztroja.Sprites;

namespace Oztroja.Entities
{
    public class Soda : Item
    {
        public Soda() : base(new Sprite(2, 2)) { }

        public override void Use(Player player)
        {
            player.Energize(10);
        }
    }
}
