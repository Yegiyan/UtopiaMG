using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace UtopiaMG
{
    class Start
    {
        ContentManager Content;
        GraphicsDevice device;
        Texture2D titleimg;
		SpriteBatch batch;

		SoundEffect buttonSound;

		MouseState mouseState;
		MouseState oldMouseState;

		// --- Button Handler --- \\
		Sprite playButton;
        Sprite aboutButton;
        Sprite optionsButton;
        Sprite howToPlayButton;
        Sprite exitButton;

        // --- Button Texture --- \\
        Texture2D playTexture;
        Texture2D aboutTexture;
        Texture2D optionsTexture;
        Texture2D howToPlayTexture;
        Texture2D exitTexture;

        // --- Button Position --- \\
        Vector2 playPosition;
        Vector2 aboutPosition;
        Vector2 optionsPosition;
        Vector2 howToPlayPosition;
        Vector2 exitPosition;

        public void Load(GraphicsDevice device, SpriteBatch batch, ContentManager Content)
        {
            this.device = device;
            this.batch = batch;
            this.Content = Content;
            titleimg = Content.Load<Texture2D>("Art/Background/titleimg");
			buttonSound = Content.Load<SoundEffect>("Audio/SFX/BUTTON_SOUND");

			mouseState = Mouse.GetState();
			oldMouseState = mouseState;

			// --- Button Loading --- \\
			playTexture = Content.Load<Texture2D>("Art/Buttons/Menu/playButtonIdle");
            playPosition = new Vector2(25, 175); // 96x42
            playButton = new Sprite(playTexture, playPosition);

            aboutTexture = Content.Load<Texture2D>("Art/Buttons/Menu/aboutButtonIdle");
            aboutPosition = new Vector2(25, 260); // 138x30
            aboutButton = new Sprite(aboutTexture, aboutPosition);

            optionsTexture = Content.Load<Texture2D>("Art/Buttons/Menu/optionsButtonIdle");
            optionsPosition = new Vector2(25, 345); // 180x42
            optionsButton = new Sprite(optionsTexture, optionsPosition);

            howToPlayTexture = Content.Load<Texture2D>("Art/Buttons/Menu/howToPlayButtonIdle");
            howToPlayPosition = new Vector2(25, 430); // 294x42
            howToPlayButton = new Sprite(howToPlayTexture, howToPlayPosition);

            exitTexture = Content.Load<Texture2D>("Art/Buttons/Menu/exitButtonIdle");
            exitPosition = new Vector2(25, 515); // 78x30
            exitButton = new Sprite(exitTexture, exitPosition);
        }

        public void Update(GameTime gameTime)
        {
			oldMouseState = mouseState;
			mouseState = Mouse.GetState();

			int mouseX = mouseState.X;
			int mouseY = mouseState.Y;

			// -------------------------- ** PLAY BUTTON ** -------------------------- \\
			if ((mouseX > 20 && mouseX < 124) && (mouseY > 170 && mouseY < 220))
            {
                playTexture = Content.Load<Texture2D>("Art/Buttons/Menu/playButtonHover");
				playButton = new Sprite(playTexture, playPosition);
				if (mouseState.LeftButton == ButtonState.Pressed)
                {
					buttonSound.Play();
					Main.state = GameState.SELECTIONMENU;
					return;
                }
            }
            else
			{
				playTexture = Content.Load<Texture2D>("Art/Buttons/Menu/playButtonIdle");
				playButton = new Sprite(playTexture, playPosition);
			}
			// ----------------------------------------------------------------------- \\ 


			// -------------------------- ** ABOUT BUTTON ** ------------------------- \\
			if ((mouseX > 20 && mouseX < 165) && (mouseY > 260 && mouseY < 295))
			{
				aboutTexture = Content.Load<Texture2D>("Art/Buttons/Menu/aboutButtonHover");
				aboutButton = new Sprite(aboutTexture, aboutPosition);
				if (mouseState.LeftButton == ButtonState.Pressed)
				{
					buttonSound.Play();
					Main.state = GameState.ABOUTMENU;
					return;
				}
			}
			else
			{
				aboutTexture = Content.Load<Texture2D>("Art/Buttons/Menu/aboutButtonIdle");
				aboutButton = new Sprite(aboutTexture, aboutPosition);
			}
			// ----------------------------------------------------------------------- \\ 


			// ------------------------- ** OPTIONS BUTTON ** ------------------------ \\
			if ((mouseX > 20 && mouseX < 207) && (mouseY > 345 && mouseY < 390))
			{
				optionsTexture = Content.Load<Texture2D>("Art/Buttons/Menu/optionsButtonHover");
				optionsButton = new Sprite(optionsTexture, optionsPosition);
				if (mouseState.LeftButton == ButtonState.Pressed)
				{
					buttonSound.Play();
					Main.state = GameState.OPTIONSMENU;
					return;
				}
			}
			else
			{
				optionsTexture = Content.Load<Texture2D>("Art/Buttons/Menu/optionsButtonIdle");
				optionsButton = new Sprite(optionsTexture, optionsPosition);
			}
			// ----------------------------------------------------------------------- \\ 


			// ------------------------ ** HOWTOPLAY BUTTON ** ----------------------- \\
			if ((mouseX > 20 && mouseX < 323) && (mouseY > 430 && mouseY < 475))
			{
				howToPlayTexture = Content.Load<Texture2D>("Art/Buttons/Menu/howToPlayButtonHover");
				howToPlayButton = new Sprite(howToPlayTexture, howToPlayPosition);
				if (mouseState.LeftButton == ButtonState.Pressed)
				{
					buttonSound.Play();
					Main.state = GameState.HOWTOPLAYMENU;
					return;
				}
			}
			else
			{
				howToPlayTexture = Content.Load<Texture2D>("Art/Buttons/Menu/howToPlayButtonIdle");
				howToPlayButton = new Sprite(howToPlayTexture, howToPlayPosition);
			}
			// ----------------------------------------------------------------------- \\ 


			// -------------------------- ** EXIT BUTTON ** -------------------------- \\
			if ((mouseX > 20 && mouseX < 104) && (mouseY > 515 && mouseY < 547))
			{
				exitTexture = Content.Load<Texture2D>("Art/Buttons/Menu/exitButtonHover");
				exitButton = new Sprite(exitTexture, exitPosition);
				
				if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
				{
					System.Console.WriteLine("-- END OF OUTPUT --");
					Content.Dispose();
					System.Environment.Exit(1);
				}
			}
			else
			{
				exitTexture = Content.Load<Texture2D>("Art/Buttons/Menu/exitButtonIdle");
				exitButton = new Sprite(exitTexture, exitPosition);
			}
			// ----------------------------------------------------------------------- \\ 
		}

		public void Draw(GameTime gameTime)
        {
            device.Clear(Color.CornflowerBlue);
            batch.Begin();
            batch.Draw(titleimg, new Rectangle(0, 0, 1024, 576), Color.White);
            playButton.Draw(batch, gameTime);
            aboutButton.Draw(batch, gameTime);
            optionsButton.Draw(batch, gameTime);
            howToPlayButton.Draw(batch, gameTime);
            exitButton.Draw(batch, gameTime);
            batch.End();
        }
    }
}
