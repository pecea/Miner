using Microsoft.Xna.Framework;

namespace Miner.GameObjects.Components
{
    public class PhysicsComponent : Component
    {
        public PhysicsComponent(GameObject gameObject)
            : base(gameObject)
        {
        }

        public Polygon Shape { get; set; }

        public override void Update(GameTime gameTime)
        {
        }
    }
}