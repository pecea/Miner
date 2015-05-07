using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Miner.Camera;
using Miner.Command;
using Miner.ContentInitializers;

namespace Miner
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MinerGame : Game
    {
        GraphicsDeviceManager _graphics;
        readonly Color _backgroundColor = new Color(6, 0, 26);

        public SpriteBatch SpriteBatch { get; set; }
        public Camera2D Camera { get; set; }
        public List<ICommand> Commands { get; set; } 

        public MinerGame()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = AppSettings.Default.ResolutionX,
                PreferredBackBufferHeight = AppSettings.Default.ResolutionY
            };

            Commands = new List<ICommand>();
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
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            var stage = StageCreator.Create(this, StageLevel.One);
            Camera = new Camera2D(this, stage.Player.Drawing);

            Components.Add(stage);
            Components.Add(Camera);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // TODO: Load any ContentManager content here
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
            GraphicsDevice.Clear(_backgroundColor);
            
            SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Camera.Transform);
            base.Draw(gameTime);
            SpriteBatch.End();
        }
    }
}
