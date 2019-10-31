using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System;

namespace UtopiaMG
{
    class Singleplayer
    {
        public ContentManager Content;
        public GraphicsDevice device;
        public SpriteBatch batch;

        SoundEffect roundEndDing;
        SpriteFont font;

        Selection selectionMenu;
        List<Building> buildings = new List<Building>();

        // ------------- UI OBJECTS ------------- \\
        Sprite mainUI;
        Texture2D mainUITexture;
        Vector2 mainUIPosition;

        Sprite water;
        Texture2D waterTexture;
        Vector2 waterPosition;

        Sprite player1Island;
        Texture2D player1IslandTexture;
        Vector2 player1IslandPosition;

        Sprite player2Island;
        Texture2D player2IslandTexture;
        Vector2 player2IslandPosition;
        // -------------------------------------- \\

        // ------------ PLAYER STATS ------------ \\
        float termOfOffice = 0;
        float termLength = 0;

        int player1Gold = 100;
        int player1Census = 0;
        int player1Score = 0;

        int player2Gold = 100;
        int player2Census = 0;
        int player2Score = 0;

        bool isStart = false;

        Player player1;
        Texture2D player1Texture;
        Vector2 player1Position;

        Player player2;
        Texture2D player2Texture;
        Vector2 player2Position;
        // -------------------------------------- \\

        // ---------- BUILDING OBJECTS ---------- \\
        Texture2D grassTexture;
        Texture2D rebelTexture;
        Texture2D schoolTexture;
        Texture2D factoryTexture;
        Texture2D fortTexture;
        Texture2D houseTexture;
        Texture2D hospitalTexture;
        Texture2D fishingBoatTexture;
        Texture2D ptBoatTexture;
        // -------------------------------------- \\

        public void Load(GraphicsDevice device, SpriteBatch batch, ContentManager Content)
        {
            this.device = device;
            this.batch = batch;
            this.Content = Content;

            selectionMenu = new Selection();
            font = Content.Load<SpriteFont>("Fonts/font");

            roundEndDing = Content.Load<SoundEffect>("Audio/SFX/ROUND_END");

            mainUITexture = Content.Load<Texture2D>("Art/Cursors/mainUI");
            mainUIPosition = new Vector2(0, 0); // 1024x576
            mainUI = new Sprite(mainUITexture, mainUIPosition);

            waterTexture = Content.Load<Texture2D>("Art/Environment/water");
            waterPosition = new Vector2(0, 0); // 1024x576
            water = new Sprite(waterTexture, waterPosition);

            player1IslandTexture = Content.Load<Texture2D>("Art/Island/player1Island");
            player1IslandPosition = new Vector2(85, 100); // 448x285
            player1Island = new Sprite(player1IslandTexture, player1IslandPosition);

            player2IslandTexture = Content.Load<Texture2D>("Art/Island/player2Island");
            player2IslandPosition = new Vector2(550, 100); // 371x271
            player2Island = new Sprite(player2IslandTexture, player2IslandPosition);

            player1Texture = Content.Load<Texture2D>("Art/Cursors/player1Cursor");
            player1Position = new Vector2(225, 150); // 8x8
            player1 = new Player(player1Texture, player1Position);

            player2Texture = Content.Load<Texture2D>("Art/Cursors/player2Cursor");
            player2Position = new Vector2(650, 200); // 8x8
            player2 = new Player(player2Texture, player2Position);

            grassTexture = Content.Load<Texture2D>("Art/Buildings/grass");
            rebelTexture = Content.Load<Texture2D>("Art/Buildings/rebel");
            schoolTexture = Content.Load<Texture2D>("Art/Buildings/school");
            factoryTexture = Content.Load<Texture2D>("Art/Buildings/factory");
            fortTexture = Content.Load<Texture2D>("Art/Buildings/fort");
            houseTexture = Content.Load<Texture2D>("Art/Buildings/house");
            hospitalTexture = Content.Load<Texture2D>("Art/Buildings/hospital");
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (!isStart)
            {
                Console.WriteLine("GET TERMOFOFFICE: (S) " + selectionMenu.getTermOfOffice());
                Console.WriteLine("GET TERMLENGTH: (S) " + selectionMenu.getTermLength());
                termOfOffice = selectionMenu.getTermOfOffice();
                termLength = selectionMenu.getTermLength();
                isStart = true;
            }

            termLength -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (termLength <= 0)
            {
                roundEndDing.Play();
                termOfOffice--;
                termLength = selectionMenu.termLength;
            }
            if (termOfOffice < 1)
            {
                roundEndDing.Play();
                Thread.Sleep(6000);
                Main.state = GameState.STARTMENU; // CHANGE STATE TO ENDGAME WHEN WE'RE DONE
                return;
            }

            // Player 1 Controls
            if (keyboard.IsKeyDown(Keys.W))
                player1Position.Y -= 4;
            if (keyboard.IsKeyDown(Keys.A))
                player1Position.X -= 4;
            if (keyboard.IsKeyDown(Keys.S))
                player1Position.Y += 4;
            if (keyboard.IsKeyDown(Keys.D))
                player1Position.X += 4;

            if (keyboard.IsKeyDown(Keys.D1))
            {
                buildings.Add(new Building(grassTexture, player1Position, 0));
            }
            if (keyboard.IsKeyDown(Keys.D2))
            {
                buildings.Add(new Building(rebelTexture, player1Position, 0));
            }
            if (keyboard.IsKeyDown(Keys.D3))
            {
                buildings.Add(new Building(schoolTexture, player1Position, 0));
            }
            if (keyboard.IsKeyDown(Keys.D4))
            {
                buildings.Add(new Building(factoryTexture, player1Position, 0));
            }
            if (keyboard.IsKeyDown(Keys.D5))
            {
                buildings.Add(new Building(fortTexture, player1Position, 0));
            }
            if (keyboard.IsKeyDown(Keys.D6))
            {
                buildings.Add(new Building(houseTexture, player1Position, 0));
            }
            if (keyboard.IsKeyDown(Keys.D7))
            {
                buildings.Add(new Building(hospitalTexture, player1Position, 0));
            }
            if (keyboard.IsKeyDown(Keys.D8))
            {
                // place player1 fishingboat
            }
            if (keyboard.IsKeyDown(Keys.D9))
            {
                // place player1 ptboat
            }

            // Player 2 Controls
            if (keyboard.IsKeyDown(Keys.Up))
                player2Position.Y -= 4;
            if (keyboard.IsKeyDown(Keys.Left))
                player2Position.X -= 4;
            if (keyboard.IsKeyDown(Keys.Down))
                player2Position.Y += 4;
            if (keyboard.IsKeyDown(Keys.Right))
                player2Position.X += 4;

            if (keyboard.IsKeyDown(Keys.NumPad1))
            {
                // place player2 grass
            }
            if (keyboard.IsKeyDown(Keys.NumPad2))
            {
                // place player2 rebel
            }
            if (keyboard.IsKeyDown(Keys.NumPad3))
            {
                // place player2 school
            }
            if (keyboard.IsKeyDown(Keys.NumPad4))
            {
                // place player2 factory
            }
            if (keyboard.IsKeyDown(Keys.NumPad5))
            {
                // place player2 fort
            }
            if (keyboard.IsKeyDown(Keys.NumPad6))
            {
                // place player2 school
            }
            if (keyboard.IsKeyDown(Keys.NumPad7))
            {
                // place player2 hospital
            }
            if (keyboard.IsKeyDown(Keys.NumPad8))
            {
                // place player2 fishingboat
            }
            if (keyboard.IsKeyDown(Keys.NumPad9))
            {
                // place player2 ptboat
            }
        }

        public void Draw(GameTime gameTime)
        {
            //device.Clear(Color.White); <-- what is this for again...?
            batch.Begin();

            water.Draw(batch, gameTime);

            player1Island.Draw(batch, gameTime);
            player2Island.Draw(batch, gameTime);

            mainUI.Draw(batch, gameTime);

            batch.DrawString(font, "TURN LENGTH: " + termLength.ToString("0"), new Vector2(660, 15), Color.White);
            batch.DrawString(font, "TERM OF OFFICE: " + termOfOffice.ToString("0"), new Vector2(35, 15), Color.White);

            batch.DrawString(font, "" + player1Gold, new Vector2(375, 470), Color.White);
            batch.DrawString(font, "" + player1Census, new Vector2(375, 505), Color.White);
            batch.DrawString(font, "" + player1Score, new Vector2(375, 540), Color.White);

            batch.DrawString(font, "" + player2Gold, new Vector2(854, 470), Color.White);
            batch.DrawString(font, "" + player2Census, new Vector2(854, 505), Color.White);
            batch.DrawString(font, "" + player2Score, new Vector2(854, 540), Color.White);

            foreach (Building building in buildings)
            {
                building.Draw(batch, gameTime);
            }

            batch.Draw(player1Texture, player1Position, Color.White);
            batch.Draw(player2Texture, player2Position, Color.White);

            batch.End();
        }
    }
}
