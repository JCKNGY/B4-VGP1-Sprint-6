using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Slide_Show
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont font;
        string[] parts;
        List<string> lines;
        int inputX,inputY,inputZ,inputV;

        List<Rectangle> totalRectangle = new List<Rectangle> {};

        Texture2D spriteImage;
        int current = 0;
        double time = 0;
        String totalCount;
        Rectangle currentRectangle;

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
            lines = new List<string>();
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
            font = this.Content.Load<SpriteFont>("SpriteFont1");

            spriteImage = this.Content.Load<Texture2D>("sprite sheet");

            

            ReadFileAsIntegers(@"Content/rectangle data.txt");
            // TODO: use this.Content to load your game content here
        }
       

        private void ReadFileAsIntegers(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            string line = reader.ReadLine();
                            totalCount = totalCount + line + " ";
                        }
                        parts = totalCount.Split(' ');
                        for (int j = 0; j < parts.Length; j++)
                        {

                            inputX = Convert.ToInt32(parts[0 + 4 * j]);
                            inputY = Convert.ToInt32(parts[1 + 4 * j]);
                            inputZ = Convert.ToInt32(parts[2 + 4 * j]);
                            inputV = Convert.ToInt32(parts[3 + 4 * j]);

                            totalRectangle.Add(new Rectangle(inputX, inputY, inputZ, inputV));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
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
            time += gameTime.ElapsedGameTime.TotalSeconds;

            
            if ((int)time % 4 > 1)
            {
                time = 0;
                current += 1;
                if (current > 5)
                {
                    current = 0;
                }
            }
            currentRectangle = totalRectangle[current];

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
            spriteBatch.Begin();


            spriteBatch.Draw(spriteImage, new Rectangle (200,200,100,100), currentRectangle,Color.White);

            spriteBatch.DrawString(font, time + "", new Vector2(600, 50), Color.White);
            spriteBatch.DrawString(font, current + "", new Vector2(600, 250), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }


        
    }
}
