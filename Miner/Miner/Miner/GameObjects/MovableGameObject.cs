using Microsoft.Xna.Framework;
using Miner.GameObjects.Components;

namespace Miner.GameObjects
{
    public abstract class MovableGameObject : GameObject
    {
        protected MovableGameObject(Game game) 
            : base(game)
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