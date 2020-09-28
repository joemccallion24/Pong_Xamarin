using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameV2.Sprites;

namespace MonoGameV2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static int screenWidth;
        public static int screenHeight;
        public static Random random;

        private List<Sprite> sprites;
        private Score score;
        private Ball ball;

        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //initialization logic here
            screenWidth = _graphics.PreferredBackBufferWidth;
            screenHeight = _graphics.PreferredBackBufferHeight;
            random = new Random();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //use this.Content to load your game content here
            var ballTexture = Content.Load<Texture2D>("Ball");
            var playerTexture = Content.Load<Texture2D>("Player1");
            var player2Texture = Content.Load<Texture2D>("Player2");

            score = new Score(Content.Load<SpriteFont>("File"));


            //load in the sprites
            sprites = new List<Sprite>()
            {
                new Sprite(Content.Load<Texture2D>("Background")),
                new Ball(ballTexture)
                {
                    position = new Vector2((screenWidth / 2) - (ballTexture.Width / 2), (screenHeight / 2) - (ballTexture.Height / 2)), //positions the ball in the centre of the screen
                    score = score,
                },
                new Player(playerTexture)
                {
                    position = new Vector2(20, (screenHeight/2) - (playerTexture.Height/2)),
                    input = new Models.Input()
                    {
                        up = Keys.W,
                        down = Keys.S,
                    }
                },
                new Player(player2Texture)
                {
                    position = new Vector2(740,(screenHeight/2) - (playerTexture.Height/2)),
                    input = new Models.Input()
                    {
                        up = Keys.Up,
                        down = Keys.Down,
                    }
                },
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (var sprite in sprites)
            {
                sprite.Update(gameTime, sprites);
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            foreach (var sprite in sprites) sprite.Draw(_spriteBatch);

            score.Draw(_spriteBatch);

            _spriteBatch.End();


            base.Draw(gameTime);
        }

        
           
    }
}
