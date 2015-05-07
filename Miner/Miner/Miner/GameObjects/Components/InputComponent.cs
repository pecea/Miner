using System;
using Microsoft.Xna.Framework;

namespace Miner.GameObjects.Components
{
    public abstract class InputComponent : Component, IUpdateable
    {
        protected InputComponent(GameObject gameObject)
            : base(gameObject)
        {
        }

        protected new MovableGameObject GameObject { get { return base.GameObject as MovableGameObject; } }

        public abstract void Update(GameTime gameTime);

        public bool Enabled { get; set; }

        public int UpdateOrder { get; set; }

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
    }
}