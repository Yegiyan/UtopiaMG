using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

namespace UtopiaMG
{
	class EndGame
	{
		public ContentManager Content;
		public GraphicsDevice device;
		public SpriteBatch batch;

		public void Load(GraphicsDevice device, SpriteBatch batch, ContentManager Content)
		{
			this.device = device;
    		this.batch = batch;
    		this.Content = Content;
		}

		public void Draw(GameTime gameTime)
		{
			device.Clear(Color.CornflowerBlue);
   			batch.Begin();
    		batch.End();
		}
	}
}
