using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oztroja.Sprites;

namespace Oztroja.Entities
{
    public class Enemy : Mob
    {
        public static Enemy creatEnemy1(int x, int y) { return new Enemy(x, y, new Animator(Animation.enemyIdle1, Animation.enemyAttack1)); }
        public static Enemy creatEnemy2(int x, int y) { return new Enemy(x, y, new Animator(Animation.enemyIdle2, Animation.enemyAttack2)); }

        private static Random _random = new Random();
        private bool _skipTurn = false;

        public Enemy(int x, int y, Animator animator) : base(x, y, animator)
        {
            _health = 20;            
        }

        public override bool Turn(float dt)
        {
            _skipTurn = !_skipTurn;
            if (_skipTurn)
                return true;

            var action = _random.Next(0, 5);

            switch (action)
            {
                case 0:
                    return true; //do nothing
                case 1:
                    AttemptMove(_x - 1, _y);
                    return true;
                case 2:
                    AttemptMove(_x + 1, _y);
                    return true;
                case 3:
                    AttemptMove(_x, _y - 1);
                    return true;
                case 4:
                    AttemptMove(_x, _y + 1);
                    return true;
            }

            return true;
        }

        protected override void hitMob(int x, int y)
        {
            var player = Level.current.GetMob(x, y) as Player;
            if (player != null)
            {
                player.Hurt(10);
                _animator.Set("attack");
            }
        }
    }
}
