using System;
using Microsoft.Xna.Framework;
using Miner.GameObjects;

namespace Miner.Command
{
    public class MoveCommand : MovableGameObjectCommand
    {
        public MoveCommand(MovableGameObject gameObject)
            : base(gameObject)
        {
        }

        public Vector2 AttemptedPosition { get; set; }

        public override void Execute()
        {
            GameObject.Position = AttemptedPosition;
        }
    }
}