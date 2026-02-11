using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Start_Me_Up
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 

    enum GameState
    {
        Start,
        Play,
        Quit
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameState gameState = GameState.Start;

        Texture2D[] textures = new Texture2D[3];

        KeyboardState oldKb = Keyboard.GetState();

        int current = 0;


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
            textures[0] = this.Content.Load<Texture2D>("start");
            textures[1] = this.Content.Load<Texture2D>("play");
            textures[2] = this.Content.Load<Texture2D>("quit");
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
            KeyboardState kb = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || kb.IsKeyDown(Keys.Escape) && !oldKb.IsKeyDown(Keys.Escape))
                this.Exit();


            if (gameState == GameState.Start && kb.IsKeyDown(Keys.Enter) && !oldKb.IsKeyDown(Keys.Enter))
            {
                
            }

            if (gameState == GameState.Play && kb.IsKeyDown(Keys.Enter) && !oldKb.IsKeyDown(Keys.Enter))
            {
                

            }


            if (gameState == GameState.Quit && kb.IsKeyDown(Keys.Enter) && !oldKb.IsKeyDown(Keys.Enter))
            {


                

            }


            if (kb.IsKeyDown(Keys.Enter) && !oldKb.IsKeyDown(Keys.Enter))
            {
                switch (gameState)
                {
                    case GameState.Start:
                        current = 0;
                        gameState = GameState.Play;
                        break;


                    case GameState.Play:
                        current = 1;
                        gameState = GameState.Quit;
                        break;

                    case GameState.Quit:
                        current = 2;
                        gameState = GameState.Start;
                        break;
                
                }

            }

            oldKb = kb;
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
            spriteBatch.Begin();

            spriteBatch.Draw(textures[current], new Rectangle(0, 0, 255, 255), Color.White);


            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
