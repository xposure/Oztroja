using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Oztroja.Sprites;

namespace Oztroja.Entities
{
    public class Player : Mob
    {
        private int moveDelay = 60;

        public Player(int x, int y) :
            base(x, y, new Animator(Animation.playerIdle, Animation.playerHurt, Animation.playerAttack))
        {
            _health = 100;
            _stamina = 100;
        }

        public void SetPosition(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override void Hurt(int amt)
        {
            base.Hurt(amt);
            _animator.Set("hurt");
        }

        public override bool Turn(float dt)
        {
            if (moveDelay <= 0)
            {
                var state = Keyboard.GetState();
                if (state.IsKeyDown(Keys.A))
                    AttemptMove(_x - 1, _y);
                else if (state.IsKeyDown(Keys.D))
                    AttemptMove(_x + 1, _y);
                else if (state.IsKeyDown(Keys.W))
                    AttemptMove(_x, _y - 1);
                else if (state.IsKeyDown(Keys.S))
                    AttemptMove(_x, _y + 1);

                return false;
            }
            else
            {
                moveDelay--;
                return moveDelay == 0;
            }
        }

        public override void AttemptMove(int x, int y)
        {
            base.AttemptMove(x, y);
            moveDelay = 8;
            Sound.PlayRandom(Sound.footstep1, Sound.footstep2);
        }

        public void Heal(int amt)
        {
            _health += amt;
        }

        public void Energize(int amt)
        {
            _stamina += amt;
        }

        protected override void hitWall(int x, int y)
        {
            _animator.Set("attack");
            var wall = Level.current.GetWall(x, y);
            if (wall.IsDamaged)
                Level.current.SetWall(x, y, null);
            else
                wall.IsDamaged = true;

            _stamina -= 10;
            Sound.PlayRandom(Sound.chop1, Sound.chop2);
        }

        protected override void hitMob(int x, int y)
        {
            base.hitMob(x, y);
            var mob = Level.current.GetMob(x, y);
            mob.Hurt(10);

            _animator.Set("attack");
            Sound.PlayRandom(Sound.chop1, Sound.chop2);
        }

        public override void moveTo(int x, int y)
        {
            base.moveTo(x, y);
            _stamina -= 10;

            var tile = Level.current.GetTile(x, y);
            if(tile == Tile.exit)
                Level.GenNextLevel();
        }

        protected override void useItem(int x, int y)
        {
            Level.current.GetItem(x, y).Use(this);
            Level.current.SetItem(x, y, null);
        }
    }
}
