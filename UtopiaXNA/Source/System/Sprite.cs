using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

namespace UtopiaMG
{
	public class Sprite
	{
    	public Texture2D texture { get; set; }
    	public Vector2 position { get; set; }

		bool isClicked = false;
    	bool isHovered = false;

        public Sprite(Texture2D texture, Vector2 position)
    	{
        	this.texture = texture;
        	this.position = position;
		}

		public bool isMousePressed()
		{
			MouseState mouseState = Mouse.GetState();
    		Point mousePoint = new Point(mouseState.X, mouseState.Y);
    		Rectangle rectangle = new Rectangle(mousePoint.X, mousePoint.Y, this.texture.Width, this.texture.Height);

    		if (rectangle.Contains(mousePoint))
    		{
        		isHovered = true;
        		isClicked = mouseState.LeftButton == ButtonState.Pressed;
				return true;
    		}
    		else
    		{
        		isHovered = false;
        		isClicked = false;
				return false;
    		}
		}

    	public virtual void Draw(SpriteBatch batch, GameTime gameTime)
    	{
            batch.Draw(texture, position, Color.White);
    	}
	}
}