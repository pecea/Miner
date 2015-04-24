using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Miner.ContentInitializers;
using Miner.Controllers;

namespace Miner
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Miner : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        GameController _game;
        MenuController _menu;
        Controller _activeController;

        public Miner()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = AppSettings.Default.ResolutionX,
                PreferredBackBufferHeight = AppSettings.Default.ResolutionY
            };

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
            _activeController = _game = new GameController(this, StageLevel.One);
            _menu = new MenuController(this);

            Components.Add(_game);
            Components.Add(_menu);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            base.LoadContent();
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
            GraphicsDevice.Clear(new Color(6, 0, 26));
            
            _activeController.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
