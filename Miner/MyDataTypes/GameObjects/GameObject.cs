using Engine.GameObjects.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.GameObjects
{
    public abstract class GameObject
    {
        protected GameObject()
        {
            Drawing = new DrawingComponent();
            Physics = new PhysicsComponent();
            Input = new InputComponent();
        }

        public DrawingComponent Drawing { get; set; }
        public PhysicsComponent Physics { get; set; }
        public InputComponent Input { get; set; }
        
        public virtual void Initialize(Texture2D texture, Vector2 position, Polygon shape)
        {
            Drawing.Texture = texture;
            Drawing.Position = position;

            Physics.Shape = shape;
        }

        public virtual void Update()
        {
            Drawing.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Drawing.Draw(spriteBatch);
        }
    }
}