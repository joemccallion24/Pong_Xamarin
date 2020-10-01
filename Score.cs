using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoGameV2
{
    public class Score
    {

        public int playerScore;
        public int AIscore; //Maybe Player 2 score in future?

        private SpriteFont _font;

        public Score(SpriteFont font)
        {
            _font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, playerScore.ToString(), new Vector2(320, 70), Color.White);
            spriteBatch.DrawString(_font, AIscore.ToString(), new Vector2(450, 70), Color.White);
        }

        public void GameOver(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, "GAME OVER", new Vector2(225, 50), Color.White);
        }


    }
}
