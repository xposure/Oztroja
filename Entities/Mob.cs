using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oztroja.Sprites;

namespace Oztroja.Entities
{
    public class Mob
    {
        protected int _x, _y;
        protected Animator _animator;
        protected int _health, _stamina;

        public int Health { get { return _health; } }
        public int Stamina { get { return _stamina; } }
        public bool IsAlive { get { return _health > 0; } }

        public virtual bool CanMoveTo(Mob e)
        {
            return false;
        }

        public Mob(int x, int y, Animator animator)
        {
            _x = x;
            _y = y;
            _animator = animator;
        }

        public virtual void Update(float dt)
        {
            _animator.Update(dt);
        }

        public virtual bool Turn(float dt)
        {
            return true;
        }

        public virtual void Draw(int x, int y)
        {
            _animator.Draw(x, y);
        }

        public virtual void Hurt(int amt)
        {
            _health -= amt;
            if (_health < 0)
            {
                //dead
                Level.current.SetMob(_x, _y, null);
            }
        }

        public virtual void AttemptMove(int x, int y)
        {
            if (x <= 0 || y <= 0 || x >= Level.current.Width - 1 || y >= Level.current.Height - 1)
                return;

            var wall = Level.current.GetWall(x, y);
            if (wall != null)
            {
                hitWall(x, y);
                return;
            }

            var enemy = Level.current.GetMob(x, y);
            if (enemy != null)
            {
                hitMob(x, y);
                return;
            }

            moveTo(x, y);

            var item = Level.current.GetItem(x, y);
            if (item != null)
                useItem(x, y);
        }

        public virtual void moveTo(int x, int y)
        {
            Level.current.SetMob(_x, _y, null);
            _x = x;
            _y = y;
            Level.current.SetMob(_x, _y, this);
        }

        protected virtual void hitWall(int x, int y) { }

        protected virtual void hitMob(int x, int y) { }

        protected virtual void useItem(int x, int y) { }
    }
}
