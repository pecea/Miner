using Microsoft.Xna.Framework;

namespace Engine.GameObjects.Components
{
    public class PhysicsComponent : IComponent
    {
        public Vector2 Position { get; set; }
        public Polygon Shape { get; set; }

        public void Update()
        {
        }
    }
}