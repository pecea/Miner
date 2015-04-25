using System;
using Microsoft.Xna.Framework;

namespace Miner.GameObjects.Components
{
    public abstract class InputComponent : Component
    {
        protected InputComponent(GameObject gameObject)
            : base(gameObject)
        {
        }

        protected new MovableGameObject GameObject { get { return base.GameObject as MovableGameObject; } }

        protected void Move(Direction direction, float delta)
        {
            switch (direction)
            {
                case Direction.Left:
                    GameObject.Position = new Vector2(GameObject.Position.X - (GameObject.MoveSpeed * delta), GameObject.Position.Y);
                    break;
                case Direction.Right:
                    GameObject.Position = new Vector2(GameObject.Position.X + (GameObject.MoveSpeed * delta), GameObject.Position.Y);
                    break;
                case Direction.Up:
                    GameObject.Position = new Vector2(GameObject.Position.X, GameObject.Position.Y - (GameObject.MoveSpeed * delta));
                    break;
                case Direction.Down:
                    GameObject.Position = new Vector2(GameObject.Position.X, GameObject.Position.Y + (GameObject.MoveSpeed * delta));
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction");
            }
        }

        protected Vector2 Jump()
        {
            throw new NotImplementedException();
        }
    }
}