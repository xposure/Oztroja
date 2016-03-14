using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oztroja.Entities
{
    public class Mob
    {
        protected int _health, _stamina;

        public int Health { get { return _health; } }
        public int Stamina { get { return _stamina; } }

        public virtual bool CanMoveTo(Mob e)
        {
            return false;
        }
    }
}
