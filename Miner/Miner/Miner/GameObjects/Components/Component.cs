using Microsoft.Xna.Framework;

namespace Miner.GameObjects.Components
{
    public abstract class Component
    {
        public GameObject GameObject { get; set; }

        protected Component(GameObject gameObject)
        {
            GameObject = gameObject;
        }

        public abstract void Update(GameTime gameTime);
    }
}