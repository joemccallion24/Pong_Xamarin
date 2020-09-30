using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameV2.Sprites
{
    public class Player : Sprite
    {
        //TouchCollection touchCollection;
        
        public Player(Texture2D texture) : base(texture)
        {
            speed = 5f;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            //if (input == null) throw new Exception("give input");
            MouseState state = Mouse.GetState();
            if (state.LeftButton == ButtonState.Pressed)
            {
                if((position.Y + _texture.Height/2) < state.Y){
                        velocity.Y = speed;
                } else if (position.Y > (state.Y - _texture.Height/2.5))
                {
                    velocity.Y = -speed;
                }
                else if((position.Y + _texture.Height / 2) == state.Y)
                {
                    velocity.Y = 0;
                }
            }

            position += velocity;
            position.Y = MathHelper.Clamp(position.Y, 0, Game1.screenHeight - _texture.Height);

            velocity = Vector2.Zero;
        }
    }
}
