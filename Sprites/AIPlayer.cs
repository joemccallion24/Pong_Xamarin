using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameV2.States;
namespace MonoGameV2.Sprites
{
    public class AIPlayer : Player
    {
        public AIPlayer(Texture2D texture) : base(texture)
        {
            speed = 5f;
        }
        
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            position += velocity;
            position.Y = MathHelper.Clamp(position.Y, 0, GameState.screenHeight - _texture.Height);

            velocity = Vector2.Zero;
        }

        public void Player2Move()
        {
            MouseState state = Mouse.GetState();
            if (state.LeftButton == ButtonState.Pressed && state.Position.X > GameState.screenWidth/2)
            {
                if ((position.Y + _texture.Height / 2) < state.Y)
                {
                    velocity.Y = speed;
                }
                else if (position.Y > (state.Y - _texture.Height / 2.7))
                {
                    velocity.Y = -speed;
                }
                else if ((position.Y + _texture.Height / 2) == state.Y)
                {
                    velocity.Y = 0;
                }
            }
        }
    }
}
