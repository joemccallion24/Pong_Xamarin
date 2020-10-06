using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGameV2.Constants;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using MonoGameV2.States;

namespace MonoGameV2.Sprites
{
    
        public class Ball : Sprite
        {
            public Score score;
            private Vector2? startPosition = null; //'?' allows the vector2 to be null 
            private float? startSpeed;
            private bool isPlaying;
            private float timer = 0;

            public Ball(Texture2D texture) : base(texture)
            {
                speed = 3f;
            }

            public override void Update(GameTime gameTime, List<Sprite> sprites)
            {
                if (startPosition == null) //first time the ball is updated it goes to here, allows restart
                {
                    startPosition = position;
                    startSpeed = speed;
                    restart();
                }

                MouseState state = Mouse.GetState();
                if (state.LeftButton == ButtonState.Pressed) isPlaying = true; //this is just a placeholder until a start  button is created
                if (!isPlaying) return;

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(timer > Constant.INCREMENT_SPEED_TIME)
            {
                speed++;
                timer = 0;
            }

                //keeping the ball on the screen my bouncing off top and bottom
                if (position.Y <= 0 || position.Y + _texture.Height >= GameState.screenHeight) velocity.Y = -velocity.Y;

                //if the ball goes left or right the appropriate score increments
                if (position.X <= 0)
                {
                    score.AIscore++;
                    restart();
                }
                if (position.X + _texture.Width >= GameState.screenWidth)
                {
                    score.playerScore++;
                    restart();
                }

            position += velocity * speed;

                foreach (var sprite in sprites) //check if the ball hits either player 
                {
                    if (sprite == this) continue;
                    if (this.velocity.X > 0 && this.IsTouchingLeft(sprite)) this.velocity.X = -this.velocity.X; //hits the left side of sprite and bounce in the opposite direction
                    if (this.velocity.X < 0 && this.IsTouchingRight(sprite)) this.velocity.X = -this.velocity.X;
                    if (this.velocity.Y > 0 && this.IsTouchingTop(sprite)) this.velocity.Y = -this.velocity.Y;
                    if (this.velocity.Y < 0 && this.IsTouchingBottom(sprite)) this.velocity.Y = -this.velocity.Y;
                }
            }

            private void restart()
            {
                var direction = GameState.random.Next(0, 4); //four directions

                switch (direction)
                {
                    case 0:
                        velocity = new Vector2(1, 1);
                        break;
                    case 1:
                        velocity = new Vector2(-1, 1);
                        break;
                    case 2:
                        velocity = new Vector2(-1, -1);
                        break;
                    case 3:
                        velocity = new Vector2(1, -1);
                        break;
            }

            position = (Vector2)startPosition; //casting as startPosition is nullable
                speed = (float)startSpeed;
                isPlaying = false;
                timer = 0;
            }

    }
}
