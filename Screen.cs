using Microsoft.Xna.Framework.Graphics;
using Oztroja.Sprites;

namespace Oztroja
{
    public class Screen
    {
        private SpriteBatch _batch;
        public SpriteBatch Batch { get { return _batch; } }

        public Screen(SpriteBatch batch)
        {
            _batch = batch;
        }
            
        public void Render(int x, int y, SpriteSheet sheet, int spriteCol, int spriteRow)
        {
            sheet.Draw(this, x, y, spriteCol, spriteRow);
        }
    }
}
