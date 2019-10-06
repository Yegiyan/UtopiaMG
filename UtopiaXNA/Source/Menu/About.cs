using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace UtopiaMG
{
	class About
	{
		ContentManager Content;
		GraphicsDevice device;
		SpriteBatch batch;

		Texture2D aboutimg;
		SoundEffect buttonSound;

		Sprite backButton;
		Texture2D backTexture;
		Vector2 backPosition;

		public void Load(GraphicsDevice device, SpriteBatch batch, ContentManager Content)
		{
			this.device = device;
    		this.batch = batch;
    		this.Content = Content;

			aboutimg = Content.Load<Texture2D>("Art/Background/aboutimg");
			buttonSound = Content.Load<SoundEffect>("Audio/SFX/BUTTON_SOUND");

			backTexture = Content.Load<Texture2D>("Art/Buttons/Menu/playButtonIdle");
			backPosition = new Vector2(25, 515); // 78x30
			backButton = new Sprite(backTexture, backPosition);
		}

		public void Update(GameTime gameTime)
		{
			MouseState mouseState = Mouse.GetState();
			int mouseX = mouseState.X;
			int mouseY = mouseState.Y;

			// -------------------------- ** BACK BUTTON ** -------------------------- \\
			if ((mouseX > 20 && mouseX < 140) && (mouseY > 515 && mouseY < 547))
			{
				backTexture = Content.Load<Texture2D>("Art/Buttons/Menu/backButtonHover");
				backButton = new Sprite(backTexture, backPosition);
				if (mouseState.LeftButton == ButtonState.Pressed)
				{
					buttonSound.Play();
					Main.state = GameState.STARTMENU;
					return;
				}
			}
			else
			{
				backTexture = Content.Load<Texture2D>("Art/Buttons/Menu/backButtonIdle");
				backButton = new Sprite(backTexture, backPosition);
			}
			// ----------------------------------------------------------------------- \\ 
		}

		public void Draw(GameTime gameTime)
		{
			device.Clear(Color.CornflowerBlue);
   			batch.Begin();
    		batch.Draw(aboutimg, new Rectangle(0, 0, 1024, 576), Color.White);
			backButton.Draw(batch, gameTime);
			batch.End();
		}
	}
}
