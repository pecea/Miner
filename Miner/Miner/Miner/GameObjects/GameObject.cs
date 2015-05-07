using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Miner.ContentInitializers;
using Miner.GameObjects.Components;

namespace Miner.GameObjects
{
    public abstract class GameObject : DrawableGameComponent
    {
        private Vector2 _position;
        public new MinerGame Game { get; set; }

        protected GameObject(MinerGame game)
            : base(game)
        {
            Game = game;
            Drawing = new DrawingComponent(this, game.SpriteBatch);
            Physics = new PhysicsComponent(this);
        }

        protected GameObject(MinerGame game, GameObjectInitializer initializer)
            : this(game)
        {
            Initializer = initializer;
        }

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                Physics.BoundingBox = new Rectangle((int)value.X, (int)value.Y, Physics.BoundingBox.Width, Physics.BoundingBox.Height);
                _position = value;
            }
        }

        public DrawingComponent Drawing { get; set; }
        public PhysicsComponent Physics { get; set; }
        protected GameObjectInitializer Initializer { get; set; }

        /// <summary>
        /// Perfroms an action on collision
        /// </summary>
        /// <param name="obj">Object which this is collding with</param>
        /// <param name="dir">Which side of this object is colliding with anouther</param>
        public virtual void Collide(GameObject obj, Direction dir)
        {
            //DrawingComponent.Text = "Collision!";
        }

        public override void Initialize()
        {
            Position = Initializer.Position;
            Physics.Shape = Initializer.Shape;
            Drawing.Texture = Game.Content.Load<Texture2D>(Initializer.Texture);
        }

        public override void Update(GameTime gameTime)
        {
            Physics.Update(gameTime);
            Drawing.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Drawing.Draw(gameTime);
        }
    }
}