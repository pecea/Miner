using Microsoft.Xna.Framework;

namespace Miner.GameObjects.Components
{
    public class PhysicsComponent : Component
    {
        private Polygon _shape;

        public PhysicsComponent(GameObject gameObject)
            : base(gameObject)
        {
        }

        public Polygon Shape 
        {
            get
            {
                return _shape;
            }
            set
            {
                BoundingBox = new Rectangle((int)GameObject.Position.X, (int)GameObject.Position.Y, (int)value.Width, (int)value.Height);
                _shape = value;
            } 
        }

        public bool CollisionX { get; set; }
        public bool CollisionTopY { get; set; }
        public bool CollisionBottomY { get; set; }
        public Rectangle BoundingBox { get; set; }

        public override void Update(GameTime gameTime)
        {
        }
    }
}