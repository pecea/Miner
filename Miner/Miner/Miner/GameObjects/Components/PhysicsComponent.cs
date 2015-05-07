using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Miner.Command;

namespace Miner.GameObjects.Components
{
    public class PhysicsComponent : Component
    {
        public PhysicsComponent(GameObject gameObject)
            : base(gameObject)
        {
            Types = new List<Type> {typeof (MoveCommand)};
        }

        public Polygon Shape { get; set; }

        public override bool CanHandle(ICommand command)
        {
            return Types.Contains(command.GetType());
        }

        public override void Handle(ICommand command)
        {
            if (CanHandle(command))
                HandleMoveCommand((MoveCommand) command);

            if (Successor != null)
                Successor.Handle(command);
        }

        public void HandleMoveCommand(MoveCommand command)
        {
            /*if (command.AttemptedPosition.X <= 0) command.AttemptedPosition = new Vector2(0, command.AttemptedPosition.Y);
            if (command.AttemptedPosition.X >= 1000) command.AttemptedPosition = new Vector2(1000, command.AttemptedPosition.Y);
            if (command.AttemptedPosition.Y >= 470) command.AttemptedPosition = new Vector2(command.AttemptedPosition.X, 470);*/

            command.Execute();
        }
    }
}