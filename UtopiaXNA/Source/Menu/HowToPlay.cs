using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace UtopiaMG
{
	class HowToPlay
	{
		ContentManager Content;
		GraphicsDevice device;
		SpriteBatch batch;

		Texture2D howtoplayimg;
		SoundEffect buttonSound;

		Sprite backButton;
		Texture2D backTexture;
		Vector2 backPosition;

		// -- How To Buttons -- \\
		Sprite governorButton;
		Texture2D governorTexture;
		Vector2 governorPosition;

		Sprite boatsButton;
		Texture2D boatsTexture;
		Vector2 boatsPosition;

		Sprite buildingButton;
		Texture2D buildingTexture;
		Vector2 buildingPosition;

		Sprite environmentButton;
		Texture2D environmentTexture;
		Vector2 environmentPosition;

		public void Load(GraphicsDevice device, SpriteBatch batch, ContentManager Content)
		{
			this.device = device;
    		this.batch = batch;
    		this.Content = Content;

			howtoplayimg = Content.Load<Texture2D>("Art/Background/howtoplayimg");
			buttonSound = Content.Load<SoundEffect>("Audio/SFX/BUTTON_SOUND");

			backTexture = Content.Load<Texture2D>("Art/Buttons/Menu/backButtonIdle");
			backPosition = new Vector2(25, 515); // 78x30
			backButton = new Sprite(backTexture, backPosition);

			governorTexture = Content.Load<Texture2D>("Art/Buttons/Menu/How To Play/governorsAwardIdle");
			governorPosition = new Vector2(25, 60);
			governorButton = new Sprite(governorTexture, governorPosition);
		}

		public void Update(GameTime gameTime)
		{
			MouseState mouseState = Mouse.GetState();
			int mouseX = mouseState.X;
			int mouseY = mouseState.Y;

			// ADD BUTTONS HERE

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
    		batch.Draw(howtoplayimg, new Rectangle(0, 0, 1024, 576), Color.White);
			backButton.Draw(batch, gameTime);
			governorButton.Draw(batch, gameTime);
			batch.End();
		}
	}
}
