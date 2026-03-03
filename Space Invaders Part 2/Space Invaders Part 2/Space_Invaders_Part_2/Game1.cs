using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Space_Invaders_Part_2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;



        Alien[,] aliens = new Alien[10, 8];

        int alienSize = 30;
        int xSpeed = 10;
        int yDrop = 40;
        int direction = 1;

        int screenWidth = 1000;
        int screenHeight = 1000;
        int totalGridHeight = 8 * 30;

        SoundEffect backgroundSound;
        bool start = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Invaders";
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 1000;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
                base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundSound = Content.Load<SoundEffect>("SI Homeworld");

            for (int r = 0; r < 8; r++)
            {
                Texture2D rowTex = Content.Load<Texture2D>(GetRowTextureName(r));

                for (int c = 0; c < 10; c++)
                {
                    aliens[c, r] = new Alien(new Rectangle(c * alienSize, r * alienSize, alienSize, alienSize), rowTex);
                }
            }


            // TODO: use this.Content to load your game content here
        }


        private string GetRowTextureName(int row)
        {
            if (row == 0)
            {
                return "Space Invaders 1st";
            }

            if (row == 1)
            {
                return "Space Invaders 2nd";
            }

            if (row == 2)
            {
                return "Space Invaders 3rd";
            }

            return "Space Invaders " + (row + 1) + "th";
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (start)
            {
                backgroundSound.Play();
                start = false;
            }

            bool hitWall = false;

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    aliens[c, r].alienRect.X += xSpeed * direction;

                    if (aliens[c, r].alienRect.Right >= screenWidth || aliens[c, r].alienRect.Left <= 0)
                    {
                        hitWall = true;
                    }

                    if (aliens[c, r].alienRect.Y >= screenHeight)
                    {
                        aliens[c, r].alienRect.Y -= screenHeight;
                    }
                }
            }

            if (hitWall)
            {
                direction *= -1;

                for (int r = 0; r < 8; r++)
                {
                    for (int c = 0; c < 10; c++)
                    {
                        aliens[c, r].alienRect.Y += yDrop;
                    }
                }
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            spriteBatch.Begin();

            foreach (Alien a in aliens)
            {
                spriteBatch.Draw(a.alienTex, a.alienRect, Color.White);
            }

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
