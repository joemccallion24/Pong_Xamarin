using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoGameV2
{
    public class ScreenText
    {
        public int playerScore;
        public int AIscore; //Maybe Player 2 score in future?

        private SpriteFont _font;

        public ScreenText(SpriteFont font)
        {
            _font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, "FIRST TO FIVE", new Vector2(285, 20), Color.Black);
        }
    }
}

