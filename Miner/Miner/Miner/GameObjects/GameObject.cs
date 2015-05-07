﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Miner.ContentInitializers;
using Miner.GameObjects.Components;

namespace Miner.GameObjects
{
    public abstract class GameObject : DrawableGameComponent
    {
        protected GameObject(MinerGame game, GameObjectInitializer initializer)
            : base(game)
        {
            Drawing = new DrawingComponent(this, game.SpriteBatch);
            Physics = new PhysicsComponent(this);
            Initializer = initializer;
        }

        public Vector2 Position { get; set; }
        public DrawingComponent Drawing { get; set; }
        public PhysicsComponent Physics { get; set; }
        protected GameObjectInitializer Initializer { get; set; }

        public override void Initialize()
        {
            Position = Initializer.Position;
            Physics.Shape = Initializer.Shape;
            Drawing.Texture = Game.Content.Load<Texture2D>(Initializer.Texture);
        }

        public override void Draw(GameTime gameTime)
        {
            Drawing.Draw(gameTime);
        }
    }
}