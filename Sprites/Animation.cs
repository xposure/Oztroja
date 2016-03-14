using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Oztroja.Sprites
{
    public class Animation
    {
        public static Animation playerIdle;
        public static Animation playerAttack;
        public static Animation playerHurt;
        public static Animation enemyIdle1, enemyIdle2;
        public static Animation enemyAttack1, enemyAttack2;


        public static void Initialize()
        {
            playerIdle = new Animation("idle", 6,
                                new Sprite(0, 0),
                                new Sprite(1, 0),
                                new Sprite(2, 0),
                                new Sprite(3, 0),
                                new Sprite(4, 0),
                                new Sprite(5, 0)
                            );

            playerAttack = new Animation("attack", 12,
                                new Sprite(0, 5),
                                new Sprite(1, 5)
                            );

            playerHurt = new Animation("hurt", 6,
                                new Sprite(6, 5),
                                new Sprite(7, 5)
                            );

            enemyIdle1 = new Animation("idle", 8,
                                new Sprite(6, 0),
                                new Sprite(7, 0),
                                new Sprite(0, 1),
                                new Sprite(1, 1),
                                new Sprite(2, 1),
                                new Sprite(3, 1)
                            );

            enemyAttack1 = new Animation("attack", 12,
                                new Sprite(2, 5),
                                new Sprite(3, 5)
                            );

            enemyIdle2 = new Animation("idle", 6,
                                new Sprite(4, 1),
                                new Sprite(5, 1),
                                new Sprite(6, 1),
                                new Sprite(7, 1),
                                new Sprite(0, 2),
                                new Sprite(1, 2)
                            );

            enemyAttack2 = new Animation("attack", 12,
                                new Sprite(4, 5),
                                new Sprite(5, 5)
                            );


        }

        private string _name;
        private float _speed;
        private float _frameTime;
        private int _frame = 0;
        private List<Sprite> _sprites;

        public string Name { get { return _name; } }
        public int Frame { get { return _frame; } }
        public int FrameCount { get { return _sprites.Count; } }

        public Animation(string name, int speed, params Sprite[] sprites)
        {
            _name = name;
            _speed = 1f / speed;
            _sprites = new List<Sprite>(sprites);
            _frameTime = _speed;
        }

        public void Reset()
        {
            _frame = 0;
        }

        public void Update(float dt)
        {
            _frameTime -= dt;
            if (_frameTime <= 0)
            {
                _frameTime = _speed;
                _frame++;
            }
        }

        public void Draw(int x, int y)
        {
            var sprite = _sprites[_frame % _sprites.Count];
            sprite.Draw(x, y);
        }
    }
}
