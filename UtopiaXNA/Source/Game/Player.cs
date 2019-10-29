using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

namespace UtopiaMG
{
    class Player
    {
        public Texture2D texture { get; set; }
        public Vector2 position { get; set; }

        public Player(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public virtual void Draw(SpriteBatch batch, GameTime gameTime)
        {
            batch.Draw(texture, position, Color.White);
        }
    }
}
