using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameV2.Sprites;
using System;

namespace MonoGameV2.States
{
    public class GameState : State
    {
        private SpriteBatch _spriteBatch;

        public static int screenWidth = Game1.screenWidth;
        public static int screenHeight = Game1.screenHeight;
        public static Random random = Game1.random;
        private Ball ball;
        private AIPlayer AIplayer;
        private List<Sprite> sprites;
        private Score score;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
      : base(game, graphicsDevice, content)
        {
            _spriteBatch = new SpriteBatch(_graphicsDevice);
            //use this.Content to load your game content here
            var ballTexture = _content.Load<Texture2D>("Ball");
            var playerTexture = _content.Load<Texture2D>("Player1");
            var player2Texture = _content.Load<Texture2D>("Player2");

            score = new Score(_content.Load<SpriteFont>("File"));

            ball = new Ball(ballTexture)
            {
                position = new Vector2((screenWidth / 2) - (ballTexture.Width / 2), (screenHeight / 2) - (ballTexture.Height / 2)), //positions the ball in the centre of the screen
                score = score,
            };
            AIplayer = new AIPlayer(player2Texture)
            {
                position = new Vector2(740, (screenHeight / 2) - (playerTexture.Height / 2)),
            };

            //load in the sprites
            sprites = new List<Sprite>()
            {
                new Sprite(_content.Load<Texture2D>("Background")),
                ball,
                new Player(playerTexture)
                {
                    position = new Vector2(20, (screenHeight/2) - (playerTexture.Height/2)),
                },
                AIplayer,
            };
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            foreach (var sprite in sprites)
            {
                sprite.Update(gameTime, sprites);
            }

            AIMove();

            if(score.playerScore == 5 || score.AIscore == 5)
            {
                _game.changeState(new Endgame(_game, _graphicsDevice, _content));
            }
            //base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            foreach (var sprite in sprites) sprite.Draw(_spriteBatch);

            score.Draw(_spriteBatch);

            _spriteBatch.End();

            //base.Draw(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }
        
        public void AIMove()
        {
            if (ball.position.Y > AIplayer.position.Y && ball.position.X > screenWidth / 2)
            {
                AIplayer.velocity.Y = AIplayer.speed;
            }
            else if (ball.position.Y < AIplayer.position.Y && ball.position.X > screenWidth / 2)
            {
                AIplayer.velocity.Y = -AIplayer.speed;
            }
            else if (ball.position.Y == AIplayer.position.Y && ball.position.X > screenWidth / 2)
            {
                AIplayer.velocity.Y = 0;
            }
        }
    }
}



