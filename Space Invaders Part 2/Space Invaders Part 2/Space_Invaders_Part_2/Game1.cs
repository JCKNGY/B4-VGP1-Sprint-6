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
        Alien[,] aliens = new Alien[10, 10];

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    aliens[i, j].alienRect = new Rectangle(50 * i, 50 * j, 30, 40);
                    switch (i){
                        case 0:
                            aliens[i, j].alienTex = this.Content.Load<Texture2D>("Space Invaders 1st");
                            break;
                        case 1:
                            aliens[i, j].alienTex = this.Content.Load<Texture2D>("Space Invaders 2nd");
                            break;
                        case 2:
                            aliens[i, j].alienTex = this.Content.Load<Texture2D>("Space Invaders 3rd");
                            break;
                        case 3:
                            aliens[i, j].alienTex = this.Content.Load<Texture2D>("Space Invaders 4th");
                            break;
                        case 4:
                            aliens[i, j].alienTex = this.Content.Load<Texture2D>("Space Invaders 5th");
                            break;
                        case 5:
                            aliens[i, j].alienTex = this.Content.Load<Texture2D>("Space Invaders 6th");
                            break;
                        case 6:
                            aliens[i, j].alienTex = this.Content.Load<Texture2D>("Space Invaders 7th");
                            break;
                        case 7:
                            aliens[i, j].alienTex = this.Content.Load<Texture2D>("Space Invaders 8th");
                            break;
                        
                    }
                    
                }


            }
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

            // TODO: use this.Content to load your game content here
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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
