using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace UtopiaMG
{
    class Building
    {
        Texture2D texture { get; set; }
        Vector2 position { get; set; }

        int decaySpeed;

        public Building(Texture2D texture, Vector2 position, int decaySpeed)
        {
            this.texture = texture;
            this.position = position;
            this.decaySpeed = decaySpeed;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch batch, GameTime gameTime)
        {
            batch.Draw(texture, position, Color.White);
        }
    }
}
