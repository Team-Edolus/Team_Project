using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LostRPG_MonoGame
{
    using Controllers;
    using GameEngine;
    using Graphics;
    using Interfaces;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private  SpriteBatch spriteBatch;

        private IGraphicsEngine graphicsEngine;
        private IUserInputInterface controller;

        private Engine engine;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.IsFullScreen = true;
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            
            //
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            //
            this.graphicsEngine = new GraphicsEngine(this.spriteBatch);
            this.controller = new ControllerUserInput();

            ITextureHandler textureHandler = new TextureHandler(this.Content);
            IPaintInterface painter = new PaintBrush(textureHandler, graphicsEngine);
            this.engine = new Engine(this.controller, painter, 30); //TODO fix time interval
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                //this.graphics.IsFullScreen = false;
                Exit();
            }
            this.controller.CheckForInput();
            this.engine.Update();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.BlanchedAlmond);
            //
            this.graphicsEngine.RedrawAll(gameTime);

            //spriteBatch.Begin();
            //spriteBatch.Draw(Content.Load<Texture2D>("Character_16x24"), new Vector2(200, 200));
            //spriteBatch.Draw(Content.Load<Texture2D>("Character_16x24"), new Vector2(300, 200));
            //spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
