using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Oztroja.Sprites
{
    public class SpriteSheet
    {
        public static SpriteSheet spriteSheet;

        public static void Initialize(SpriteBatch batch, ContentManager content)
        {
            var spriteSheetTex = content.Load<Texture2D>("Assets/Sprites/Scavengers_SpriteSheet");
            spriteSheet = new SpriteSheet(batch, spriteSheetTex, 8, 7);
        }

        private SpriteBatch _batch;
        private Texture2D _texture;
        private int _cols, _rows;
        private int _colWidth, _rowHeight;

        public Texture2D Texture { get { return _texture; } }

        public SpriteSheet(SpriteBatch batch, Texture2D texture, int cols, int rows)
        {
            _batch = batch;
            _texture = texture;
            _cols = cols;
            _rows = rows;

            _colWidth = texture.Width / cols;
            _rowHeight = texture.Height / rows;
        }

        public void Draw(Screen screen, int x, int y, int col, int row)
        {
            var pos = new Vector2(x, y);
            var srcx = _colWidth * col;
            var srcy = _rowHeight * row;
            var srcRect = new Rectangle(srcx, srcy, _colWidth, _rowHeight);

            screen.Batch.Draw(_texture, position: pos, sourceRectangle: srcRect);
        }
    }
}
