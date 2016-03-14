using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oztroja.Entities
{
    public class Player : Mob
    {
        public void Heal(int amt)
        {
            _health += amt;
        }

        public void Energize(int amt)
        {
            _stamina += amt;
        }
    }
}
