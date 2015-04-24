using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Miner.Camera;
using Miner.GameObjects.Components;

namespace Miner.GameObjects
{
    public abstract class GameObject : DrawableGameComponent
    {
        protected GameObject(Game game) 
            : base(game)
        {
            Drawing = new DrawingComponent(this);
            Physics = new PhysicsComponent(this);
        }

        public Vector2 Position { get; set; }
        public DrawingComponent Drawing { get; set; }
        public PhysicsComponent Physics { get; set; }
        
        public virtual void Initialize(Texture2D texture, Vector2 position, Polygon shape)
        {
            Position = position;

            Drawing.Texture = texture;

            Physics.Shape = shape;
        }

        public override void Update(GameTime gameTime)
        {
            Physics.Update(gameTime);
            Drawing.Update(gameTime);

            base.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch, ICamera2D camera)
        {
            Drawing.Draw(spriteBatch, camera);
        }
    }
}