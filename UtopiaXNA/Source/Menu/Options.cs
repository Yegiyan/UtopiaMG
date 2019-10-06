using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace UtopiaMG
{
	class Options
	{
		ContentManager Content;
		GraphicsDevice device;
		SpriteBatch batch;
        SpriteFont font;

        float sfxVolume;
		float musVolume;

		MouseState mouseState;
		MouseState oldMouseState;

		Texture2D optionsimg;

		ButtonSound buttonSound;
		Music music;

		Sprite backButton;
		Texture2D backTexture;
		Vector2 backPosition;

		// -- SFX Button -- \\
		Sprite sfxPlusButton;
		Texture2D sfxPlusTexture;
		Vector2 sfxPlusPosition;

		Sprite sfxMinusButton;
		Texture2D sfxMinusTexture;
		Vector2 sfxMinusPosition;

		// -- MUS Button -- \\
		Sprite musPlusButton;
		Texture2D musPlusTexture;
		Vector2 musPlusPosition;

		Sprite musMinusButton;
		Texture2D musMinusTexture;
		Vector2 musMinusPosition;

		public void Load(GraphicsDevice device, SpriteBatch batch, ContentManager Content)
		{
			this.device = device;
    		this.batch = batch;
    		this.Content = Content;

            font = Content.Load<SpriteFont>("Fonts/font");
            musVolume = 1.0f;
            sfxVolume = 1.0f;

			optionsimg = Content.Load<Texture2D>("Art/Background/optionsimg");
			buttonSound = new ButtonSound();
			music = new Music();

			backTexture = Content.Load<Texture2D>("Art/Buttons/Menu/backButtonIdle");
			backPosition = new Vector2(25, 515); // 78x30
			backButton = new Sprite(backTexture, backPosition);

			sfxPlusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/sfxPlusIdle");
			sfxPlusPosition = new Vector2(645, 183); 
			sfxPlusButton = new Sprite(sfxPlusTexture, sfxPlusPosition);

			sfxMinusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/sfxMinusIdle");
			sfxMinusPosition = new Vector2(475, 183);
			sfxMinusButton = new Sprite(sfxMinusTexture, sfxMinusPosition);

			musPlusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/musPlusIdle");
			musPlusPosition = new Vector2(645, 266);
			musPlusButton = new Sprite(musPlusTexture, musPlusPosition);

			musMinusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/musMinusIdle");
			musMinusPosition = new Vector2(475, 266);
			musMinusButton = new Sprite(musMinusTexture, musMinusPosition);
		}

		public void Update(GameTime gameTime)
		{
			oldMouseState = mouseState;
			mouseState = Mouse.GetState();

			int mouseX = mouseState.X;
			int mouseY = mouseState.Y;

			// -------------------------- ** SFX VOL PLUS ** --------------------------- \\
			if ((mouseX > 640 && mouseX < 678) && (mouseY > 182 && mouseY < 218))
			{
				sfxPlusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/sfxPlusHover");
				sfxPlusButton = new Sprite(sfxPlusTexture, sfxPlusPosition);
				if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
				{
					buttonSound.Play(Content);
                    if (sfxVolume != 1.0f) sfxVolume += 0.2f;
                    buttonSound.Update(gameTime, sfxVolume);
					return;
				}
			}
			else
			{
				sfxPlusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/sfxPlusIdle");
				sfxPlusButton = new Sprite(sfxPlusTexture, sfxPlusPosition);
			}
			// ------------------------------------------------------------------------- \\ 

			// -------------------------- ** SFX VOL MINUS ** -------------------------- \\
			if ((mouseX > 470 && mouseX < 512) && (mouseY > 190 && mouseY < 212))
			{
				sfxMinusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/sfxMinusHover");
				sfxMinusButton = new Sprite(sfxMinusTexture, sfxMinusPosition);
				if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
				{
					buttonSound.Play(Content);
                    if (sfxVolume != 0.0f) sfxVolume -= 0.2f;
                    if (sfxVolume < 0.1f) sfxVolume = 0.0f;
                    buttonSound.Update(gameTime, sfxVolume);
					return;
				}
			}
			else
			{
				sfxMinusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/sfxMinusIdle");
				sfxMinusButton = new Sprite(sfxMinusTexture, sfxMinusPosition);
			}
			// ------------------------------------------------------------------------- \\ 

			// -------------------------- ** MUS VOL PLUS ** --------------------------- \\
			if ((mouseX > 640 && mouseX < 678) && (mouseY > 265 && mouseY < 303))
			{
				musPlusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/musPlusHover");
				musPlusButton = new Sprite(musPlusTexture, musPlusPosition);
				if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
				{
					buttonSound.Play(Content);
					if (musVolume != 1.0f) musVolume += 0.2f;
					music.Update(gameTime, musVolume);
					return;
				}
			}
			else
			{
				musPlusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/musPlusIdle");
				musPlusButton = new Sprite(musPlusTexture, musPlusPosition);
			}
			// ------------------------------------------------------------------------- \\ 

			// -------------------------- ** MUS VOL MINUS ** -------------------------- \\
			if ((mouseX > 470 && mouseX < 512) && (mouseY > 270 && mouseY < 295))
			{
				musMinusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/musMinusHover");
				musMinusButton = new Sprite(musMinusTexture, musMinusPosition);
				if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
				{
					buttonSound.Play(Content);
                    if (musVolume != 0.0f) musVolume -= 0.2f;
                    if (musVolume < 0.1f) musVolume = 0.0f;
					music.Update(gameTime, musVolume);
					return;
				}
			}
			else
			{
				musMinusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/musMinusIdle");
				musMinusButton = new Sprite(musMinusTexture, musMinusPosition);
			}
			// ------------------------------------------------------------------------- \\ 

			// -------------------------- ** BACK BUTTON ** ---------------------------- \\
			if ((mouseX > 20 && mouseX < 140) && (mouseY > 515 && mouseY < 547))
			{
				backTexture = Content.Load<Texture2D>("Art/Buttons/Menu/backButtonHover");
				backButton = new Sprite(backTexture, backPosition);
				if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
				{
					buttonSound.Play(Content);
					Main.state = GameState.STARTMENU;
					return;
				}
			}
			else
			{
				backTexture = Content.Load<Texture2D>("Art/Buttons/Menu/backButtonIdle");
				backButton = new Sprite(backTexture, backPosition);
			}
			// ------------------------------------------------------------------------- \\ 
		}

		public void Draw(GameTime gameTime)
		{
			device.Clear(Color.CornflowerBlue);
   			batch.Begin();
    		batch.Draw(optionsimg, new Rectangle(0, 0, 1024, 576), Color.White);
            batch.DrawString(font, "" + musVolume, new Vector2(560, 265), Color.DarkSlateGray);
            batch.DrawString(font, "" + sfxVolume, new Vector2(560, 180), Color.DarkSlateGray);
            sfxPlusButton.Draw(batch, gameTime);
			sfxMinusButton.Draw(batch, gameTime);
			musPlusButton.Draw(batch, gameTime);
			musMinusButton.Draw(batch, gameTime);
			backButton.Draw(batch, gameTime);
			batch.End();
		}
	}
}
