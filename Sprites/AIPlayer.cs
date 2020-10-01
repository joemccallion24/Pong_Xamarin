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
    }
}
