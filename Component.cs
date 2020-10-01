using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MonoGameV2
{
    public abstract class Component
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}