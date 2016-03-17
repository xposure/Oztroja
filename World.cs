using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oztroja
{
    public class World
    {
        //private Level _level;

        public World()
        {
            Level.GenNextLevel();
        }

        public void Tick(int tick)
        {
            Level.current.Update(1f / 30f);
        }

        public void Render(Screen screen)
        {
            Level.current.Draw(screen);
        }
    }
}
