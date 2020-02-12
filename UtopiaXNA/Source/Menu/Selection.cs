using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

namespace UtopiaMG
{
	class Selection
	{
		ContentManager Content;
		GraphicsDevice device;
		SpriteBatch batch;
        SpriteFont font;

        MouseState mouseState;
		MouseState oldMouseState;

        Texture2D selectionimg;
		SoundEffect buttonSound;

		Sprite backButton;
		Texture2D backTexture;
		Vector2 backPosition;

        // ----- Buttons ----- \\
        Sprite termOfOfficePlusButton;
        Texture2D termOfOfficePlusTexture;
        Vector2 termOfOfficePlusPosition;

        Sprite termOfOfficeMinusButton;
        Texture2D termOfOfficeMinusTexture;
        Vector2 termOfOfficeMinusPosition;

        Sprite termLengthPlusButton;
        Texture2D termLengthPlusTexture;
        Vector2 termLengthPlusPosition;

        Sprite termLengthMinusButton;
        Texture2D termLengthMinusTexture;
        Vector2 termLengthMinusPosition;

        float termOfOffice = 30; // Amount of rounds
        float termLength = 60;   // Round length in seconds

        void SetTermOfOffice(float termOfOffice)
        {
            termOfOffice = this.termOfOffice;
        }

        void SetTermLength(float termLength)
        {
            termLength = this.termLength;
        }

        public float GetTermOfOffice()
        {
            return termOfOffice;
        }

        public float GetTermLength()
        {
            return termLength;
        }

        public void Load(GraphicsDevice device, SpriteBatch batch, ContentManager Content)
		{
			this.device = device;
    		this.batch = batch;
    		this.Content = Content;

            font = Content.Load<SpriteFont>("Fonts/font");

            selectionimg = Content.Load<Texture2D>("Art/Background/selectionimg");
			buttonSound = Content.Load<SoundEffect>("Audio/SFX/BUTTON_SOUND");

            backTexture = Content.Load<Texture2D>("Art/Buttons/Menu/backButtonIdle");
			backPosition = new Vector2(25, 515); // 78x30
			backButton = new Sprite(backTexture, backPosition);

            termOfOfficePlusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/sfxPlusIdle");
            termOfOfficePlusPosition = new Vector2(580, 138);
            termOfOfficePlusButton = new Sprite(termOfOfficePlusTexture, termOfOfficePlusPosition);

            termOfOfficeMinusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/sfxMinusIdle");
            termOfOfficeMinusPosition = new Vector2(410, 138);
            termOfOfficeMinusButton = new Sprite(termOfOfficeMinusTexture, termOfOfficeMinusPosition);

            termLengthPlusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/musPlusIdle");
            termLengthPlusPosition = new Vector2(580, 300);
            termLengthPlusButton = new Sprite(termLengthPlusTexture, termLengthPlusPosition);

            termLengthMinusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/musMinusIdle");
            termLengthMinusPosition = new Vector2(410, 300);
            termLengthMinusButton = new Sprite(termLengthMinusTexture, termLengthMinusPosition);
        }

		public void Update(GameTime gameTime)
		{
            Console.WriteLine("GET TERMOFOFFICE: " + GetTermOfOffice());
            Console.WriteLine("GET TERMLENGTH: " + GetTermLength());

            KeyboardState keyboard = Keyboard.GetState();
            oldMouseState = mouseState;
            mouseState = Mouse.GetState();

            int mouseX = mouseState.X;
            int mouseY = mouseState.Y;

            // --- ENTER BUTTON --- \\
            if (keyboard.IsKeyDown(Keys.Enter))
            {
                Main.state = GameState.SINGLEPLAYER;
            }
            // -------------------- \\

            // -------------------------- ** TERM OF OFFICE PLUS ** --------------------------- \\
            if ((mouseX > 570 && mouseX < 610) && (mouseY > 135 && mouseY < 175))
            {
                termOfOfficePlusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/sfxPlusHover");
                termOfOfficePlusButton = new Sprite(termOfOfficePlusTexture, termOfOfficePlusPosition);
                if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                {
                    buttonSound.Play();
                    if (termOfOffice != 99) SetTermOfOffice(termOfOffice++);
                    return;
                }
            }
            else
            {
                termOfOfficePlusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/sfxPlusIdle");
                termOfOfficePlusButton = new Sprite(termOfOfficePlusTexture, termOfOfficePlusPosition);
            }
            // -------------------------------------------------------------------------------- \\ 

            // -------------------------- ** TERM OF OFFICE MINUS ** -------------------------- \\
            if ((mouseX > 415 && mouseX < 455) && (mouseY > 145 && mouseY < 195))
            {
                termOfOfficeMinusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/sfxMinusHover");
                termOfOfficeMinusButton = new Sprite(termOfOfficeMinusTexture, termOfOfficeMinusPosition);
                if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                {
                    buttonSound.Play();
                    if (termOfOffice != 5) SetTermOfOffice(termOfOffice--);
                    return;
                }
            }
            else
            {
                termOfOfficeMinusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/sfxMinusIdle");
                termOfOfficeMinusButton = new Sprite(termOfOfficeMinusTexture, termOfOfficeMinusPosition);
            }
            // -------------------------------------------------------------------------------- \\  

            // --------------------------- ** TERM LENGTH PLUS ** ----------------------------- \\
            if ((mouseX > 580 && mouseX < 620) && (mouseY > 300 && mouseY < 345))
            {
                termLengthPlusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/musPlusHover");
                termLengthPlusButton = new Sprite(termLengthPlusTexture, termLengthPlusPosition);
                if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                {
                    buttonSound.Play();
                    if (termLength != 99) termLength++;
                    return;
                }
            }
            else
            {
                termLengthPlusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/musPlusIdle");
                termLengthPlusButton = new Sprite(termLengthPlusTexture, termLengthPlusPosition);
            }
            // -------------------------------------------------------------------------------- \\ 

            // --------------------------- ** TERM LENGTH MINUS ** ---------------------------- \\
            if ((mouseX > 415 && mouseX < 455) && (mouseY > 290 && mouseY < 345))
            {
                termLengthMinusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/musMinusHover");
                termLengthMinusButton = new Sprite(termLengthMinusTexture, termLengthMinusPosition);
                if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                {
                    buttonSound.Play();
                    if (termLength != 5) termLength--;
                    return;
                }
            }
            else
            {
                termLengthMinusTexture = Content.Load<Texture2D>("Art/Buttons/Volume/musMinusIdle");
                termLengthMinusButton = new Sprite(termLengthMinusTexture, termLengthMinusPosition);
            }
            // -------------------------------------------------------------------------------- \\ 

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

            SetTermOfOffice(termOfOffice);
            SetTermLength(termLength);
		}

		public void Draw(GameTime gameTime)
		{
   			batch.Begin();
    		batch.Draw(selectionimg, new Rectangle(0, 0, 1024, 576), Color.White);
            batch.DrawString(font, "" + termOfOffice, new Vector2(485, 136), Color.DarkSlateGray);
            batch.DrawString(font, "" + termLength, new Vector2(485, 298), Color.DarkSlateGray);
            termOfOfficePlusButton.Draw(batch, gameTime);
            termOfOfficeMinusButton.Draw(batch, gameTime);
            termLengthPlusButton.Draw(batch, gameTime);
            termLengthMinusButton.Draw(batch, gameTime);
            backButton.Draw(batch, gameTime);
			batch.End();
		}
	}
}
