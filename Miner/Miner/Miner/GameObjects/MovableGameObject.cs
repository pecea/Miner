using Microsoft.Xna.Framework;
using Miner.ContentInitializers;
using Miner.GameObjects.Components;

namespace Miner.GameObjects
{
    public abstract class MovableGameObject : GameObject
    {
        protected MovableGameObject(MinerGame game, MovableGameObjectInitializer initializer)
            : base(game, initializer)
        {
        }

        public InputComponent Input { get; set; }
        public float MoveSpeed { get; set; }

        public override void Initialize()
        {
            base.Initialize();
            MoveSpeed = ((MovableGameObjectInitializer) Initializer).MoveSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            Input.Update(gameTime);

            //TODO: Komendy od INPUT nie zawsze są kierowane do PHYSICS - na przykład włączenie menu. Co wtedy? ODP: Chain of responsibility

            //base.Update(gameTime);
        }

        public void Move(Vector2 newPosition)
        {
            Position = newPosition;
        }
    }
}