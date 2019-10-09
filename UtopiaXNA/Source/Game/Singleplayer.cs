﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Diagnostics;
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

            termLength = selectionMenu.termLength;
            termOfOffice = selectionMenu.termOfOffice;
        }

        public void Update(GameTime gameTime)
        {
            mainUI = new Sprite(mainUITexture, mainUIPosition);
            water = new Sprite(waterTexture, waterPosition);
            player1Island = new Sprite(player1IslandTexture, player1IslandPosition);
            player2Island = new Sprite(player2IslandTexture, player2IslandPosition);

            termLength -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (termLength <= 0)
            {
                roundEndDing.Play();
                termOfOffice--;
                termLength = selectionMenu.termLength;
            }
            if (termOfOffice < 1)
            {
                Main.state = GameState.STARTMENU; // CHANGE STATE TO ENDGAME WHEN WE'RE DONE
                return;
            }
        }

        public void Draw(GameTime gameTime)
        {
            device.Clear(Color.White);
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

            batch.End();
        }
    }
}
