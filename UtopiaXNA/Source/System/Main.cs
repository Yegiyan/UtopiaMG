using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System;

namespace UtopiaMG
{
	public enum GameState
	{
	STARTMENU,
	ABOUTMENU,
	OPTIONSMENU,
	HOWTOPLAYMENU,
	EXIT,
	SELECTIONMENU,
	SINGLEPLAYER,
	MULTIPLAYER,
	ENDGAME,
	
	GOVERNORAWARD,
	HOWTOBOAT,
	HOWTOBUILDING,
	HOWTOENVIRONMENT1,
	HOWTOENVIRONMENT2,
	HOWTOENVIRONMENT3
	}

	public class Main : Game
	{
		public static GameState state = GameState.STARTMENU;

		// ------------- CLASS OBJECTS ------------- \\
		Start startMenu = new Start();
		About aboutMenu = new About();
		Options optionsMenu = new Options();
		HowToPlay howToPlayMenu = new HowToPlay();
		Selection selectionMenu = new Selection();

		Music menuMusic = new Music();

		Singleplayer singlePlayer = new Singleplayer();
		Multiplayer multiPlayer = new Multiplayer();
		EndGame endGame = new EndGame();
		// ----------------------------------------- \\

		// ------ Root Objects ------ \\
		GraphicsDeviceManager graphics;
		SpriteBatch batch;
		// -------------------------- \\

		public Main()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = 1024;
			graphics.PreferredBackBufferHeight = 576;
			Content.RootDirectory = "Content";
		}

		protected override void Initialize()
		{
			base.Initialize();
			IsMouseVisible = true;
		}

        protected override void LoadContent()
		{
			menuMusic.Play(Content);
			batch = new SpriteBatch(GraphicsDevice);

            startMenu.Load(GraphicsDevice, batch, Content);
			aboutMenu.Load(GraphicsDevice, batch, Content);
			optionsMenu.Load(GraphicsDevice, batch, Content);
			howToPlayMenu.Load(GraphicsDevice, batch, Content);
			selectionMenu.Load(GraphicsDevice, batch, Content);

            singlePlayer.Load(GraphicsDevice, batch, Content);
        }

		protected override void Update(GameTime gameTime)
		{
			switch (state)
			{
				case GameState.STARTMENU:
					startMenu.Update(gameTime);
					break;
				case GameState.ABOUTMENU:
					aboutMenu.Update(gameTime);
					break;
				case GameState.OPTIONSMENU:
					optionsMenu.Update(gameTime);
					break;
				case GameState.HOWTOPLAYMENU:
					howToPlayMenu.Update(gameTime);
					break;
				case GameState.SELECTIONMENU:
					selectionMenu.Update(gameTime);
					break;
				case GameState.SINGLEPLAYER:
					singlePlayer.Update(gameTime);
					break;
				case GameState.MULTIPLAYER:
					//multiPlayer.Update(gameTime);
					break;
				case GameState.ENDGAME:
					//endGame.Update(gameTime);
					break;
				default:
					Console.WriteLine("Update() state is null!");
					break;
			}
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
        {
            TargetElapsedTime = TimeSpan.FromSeconds(1d / 30d);
            float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            MouseState mouseState = Mouse.GetState();

            Console.WriteLine("Mouse Position: ({0}, {1})", mouseState.X, mouseState.Y);
            Console.WriteLine("Game State: {0}", state);
            Console.WriteLine("FPS: " + (int)frameRate);

            switch (state)
			{
				case GameState.STARTMENU:
					startMenu.Draw(gameTime);
					break;
				case GameState.ABOUTMENU:
					aboutMenu.Draw(gameTime);
					break;
				case GameState.OPTIONSMENU:
					optionsMenu.Draw(gameTime);
					break;
				case GameState.HOWTOPLAYMENU:
					howToPlayMenu.Draw(gameTime);
					break;
				case GameState.SELECTIONMENU:
					selectionMenu.Draw(gameTime);
					break;
				case GameState.SINGLEPLAYER:
					singlePlayer.Draw(gameTime);
					break;
				case GameState.MULTIPLAYER:
					multiPlayer.Draw(gameTime);
					break;
				case GameState.ENDGAME:
					endGame.Draw(gameTime);
					break;
				default:
                    Console.WriteLine("Draw() state is null!");
					break;
			}
            base.Draw(gameTime);
		}

		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}
	}
}