using Miner.Command;

namespace Miner.GameObjects.Components
{
    public abstract class Component : Handler
    {
        public GameObject GameObject { get; set; }

        protected Component(GameObject gameObject)
        {
            GameObject = gameObject;
        }
    }
}