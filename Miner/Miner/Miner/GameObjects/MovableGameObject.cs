using Microsoft.Xna.Framework;
using Miner.ContentInitializers;
using Miner.GameObjects.Components;

namespace Miner.GameObjects
{
    public abstract class MovableGameObject : GameObject
    {
        protected MovableGameObject(MinerGame game) 
            : base(game)
        {
        }

        protected MovableGameObject(MinerGame game, GameObjectInitializer initializer)
            : base(game, initializer)
        {
        }

        public InputComponent Input { get; set; }
        public float MoveSpeed { get; set; }

        public override void Update(GameTime gameTime)
        {
            Input.Update(gameTime);

            base.Update(gameTime);
        }
    }
}