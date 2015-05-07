using System;
using Microsoft.Xna.Framework;

namespace Miner.GameObjects.Components
{
    public abstract class InputComponent : Component
    {
        protected InputComponent(GameObject gameObject)
            : base(gameObject)
        {
            GameObject = (MovableGameObject) gameObject;
        }

        protected new MovableGameObject GameObject { get; set; }
        protected bool Moved { get; set; }

        protected void Move(Direction direction, float delta)
        {
            switch (direction)
            {
                case Direction.Left:
                    GameObject.Speed = new Vector2(-(GameObject.MoveSpeedX * delta), GameObject.Speed.Y);
                    break;
                case Direction.Right:
                    GameObject.Speed = new Vector2(GameObject.MoveSpeedX * delta, GameObject.Speed.Y);    
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction");
            }
            Moved = true;
        }

        protected void Jump()
        {
            GameObject.Airborne = true;
            GameObject.Speed = new Vector2(GameObject.Speed.X, GameObject.Speed.Y - MovableGameObject.JumpStartSpeed);
        }

        public override void Update(GameTime gameTime)
        {
            GameObject.Moving = Moved;
            Moved = false;
        }
    }
}