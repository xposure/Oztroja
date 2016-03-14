using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oztroja.Sprites
{
    public class Animator
    {
        private int _curAnimation = 0;
        private List<Animation> _animations;

        public Animator(params Animation[] animations)
        {
            _animations = new List<Animation>(animations);
        }

        public void Update(float dt)
        {
            var anim = _animations[_curAnimation];

            anim.Update(dt);
            if (_curAnimation > 0 && anim.Frame >= anim.FrameCount)
            {
                anim.Reset();
                _curAnimation = 0;
            }
        }

        public void Draw(int x, int y)
        {
            _animations[_curAnimation].Draw(x, y);
        }

        public void Set(string name)
        {
            _curAnimation = 0;
            for (var i = 0; i < _animations.Count; i++)
            {
                if (_animations[i].Name == name)
                {
                    _curAnimation = i;
                    break;
                }
            }
        }
    }
}
