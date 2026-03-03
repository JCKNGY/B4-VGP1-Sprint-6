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

namespace Breakout
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        enum GameState { level1, level2, level3 }
        GameState currentGameState;

        Brick[,] brickGrid;
        Texture2D whiteBox;
        Rectangle paddle;
        Rectangle ball;
        Vector2 ballPosition;
        Vector2 ballVelocity;

        int ROWS = 9;
        int COLS = 25;
        bool levelIsActive = false;

        KeyboardState oldkb; 


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
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
            currentGameState = GameState.level1;

            paddle = new Rectangle(350, 550, 100, 15);
            ResetBall();


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 

        private void ResetBall()
        {
            ballPosition = new Vector2(400, 350);

            ballVelocity = new Vector2(4, -4);
            ball = new Rectangle((int)ballPosition.X, (int)ballPosition.Y, 10, 10);
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            whiteBox = this.Content.Load<Texture2D>("output-onlinepngtools");

            LoadLevel("Content/level1.txt");




            // TODO: use this.Content to load your game content here
        }



        public void LoadLevel(string fileName)
        {
            brickGrid = new Brick[ROWS, COLS];

            levelIsActive = false;

            this.Window.Title = "Breakout";

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                int bWidth = 800 / COLS;
                int bHeight = 25;

                for (int r = 0; r < lines.Length && r < ROWS; r++)
                {
                    for (int c = 0; c < lines[r].Length && c < COLS; c++)
                    {
                        char desc = lines[r][c];

                        if (desc != '.')
                        {
                            Color bColor = GetColor(desc);

                            Rectangle rect = new Rectangle(c * bWidth, (r * bHeight) + 60, bWidth - 1, bHeight - 1);

                            brickGrid[r, c] = new Brick(whiteBox, bColor, rect, 1);

                            levelIsActive = true;
                        }
                    }
                }
            }
        }

        private Color GetColor(char c)
        {
            if (c == 'b')
            {
                return Color.Blue;
            }

            if (c == 'g')
            {
                return Color.Green;
            }

            if (c == 'o')
            {
                return Color.Orange;
            }

            if (c == 'r')
            {
                return Color.Red;
            }

            if (c == 'y')
            {
                return Color.Yellow;
            }

            return Color.White;
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
            KeyboardState k = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || k.IsKeyDown(Keys.Escape) && oldkb.IsKeyDown(Keys.Escape))
                this.Exit();


            if (k.IsKeyDown(Keys.Left) && paddle.X > 0)
            {
                paddle.X -= 8;
            }

            if (k.IsKeyDown(Keys.Right) && paddle.X < 800 - paddle.Width)
            {
                paddle.X += 8;
            }

            ballPosition += ballVelocity;

            ball.X = (int)ballPosition.X;

            ball.Y = (int)ballPosition.Y;

            if (ball.X <= 0 || ball.X >= 800 - ball.Width)
            {
                ballVelocity.X *= -1;
            }

            if (ball.Y <= 0)
            {
                ballVelocity.Y *= -1;
            }

            if (ball.Intersects(paddle))
            {
                ballVelocity.Y = -Math.Abs(ballVelocity.Y);

                ballPosition.Y = paddle.Y - ball.Height;
            }

            bool anyBricksLeft = false;

            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLS; c++)
                {
                    if (brickGrid[r, c] != null)
                    {
                        anyBricksLeft = true;

                        if (ball.Intersects(brickGrid[r, c].rectangle))
                        {
                            ballVelocity.Y *= -1;
                            brickGrid[r, c] = null;
                            return;
                        }
                    }
                }
            }

            if (levelIsActive && !anyBricksLeft)
            {
                GoToNextLevel();
            }

            if (ball.Y > 600)
            {
                ResetBall();
            }




            // TODO: Add your update logic here
            oldkb = k;
            base.Update(gameTime);
        }



        private void GoToNextLevel()
        {
            if (currentGameState == GameState.level1)
            {
                currentGameState = GameState.level2;
            }
            else if (currentGameState == GameState.level2)
            {
                currentGameState = GameState.level3;
            }
            else
            {
                currentGameState = GameState.level1;
            }

            LoadLevel("Content/" + currentGameState.ToString().ToLower() + ".txt");

            ResetBall();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLS; c++)
                {
                    if (brickGrid[r, c] != null)
                    {
                        spriteBatch.Draw(brickGrid[r, c].texture, brickGrid[r, c].rectangle, brickGrid[r, c].color);
                    }
                }
            }

            spriteBatch.Draw(whiteBox, paddle, Color.White);

            spriteBatch.Draw(whiteBox, ball, Color.Red);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
