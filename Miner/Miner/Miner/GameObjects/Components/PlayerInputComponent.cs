using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Miner.Command;

namespace Miner.GameObjects.Components
{
    public class PlayerInputComponent : InputComponent
    {
        public PlayerInputComponent(GameObject gameObject)
            : base(gameObject)
        {
            Successor = gameObject.Physics;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardStateManager.UpdateKeyboardState();

            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var command = new MoveCommand(GameObject) { AttemptedPosition = GameObject.Position };

            if (KeyboardStateManager.IsCurPress(Keys.W)) command.AttemptedPosition = new Vector2(command.AttemptedPosition.X, command.AttemptedPosition.Y - (GameObject.MoveSpeed * delta));
            if (KeyboardStateManager.IsCurPress(Keys.S)) command.AttemptedPosition = new Vector2(command.AttemptedPosition.X, command.AttemptedPosition.Y + (GameObject.MoveSpeed * delta));
            if (KeyboardStateManager.IsCurPress(Keys.A)) command.AttemptedPosition = new Vector2(command.AttemptedPosition.X - (GameObject.MoveSpeed * delta), command.AttemptedPosition.Y);
            if (KeyboardStateManager.IsCurPress(Keys.D)) command.AttemptedPosition = new Vector2(command.AttemptedPosition.X + (GameObject.MoveSpeed * delta), command.AttemptedPosition.Y);
                                                         
            if (KeyboardStateManager.IsNewPress(Keys.W)) command.AttemptedPosition = new Vector2(command.AttemptedPosition.X, command.AttemptedPosition.Y - (GameObject.MoveSpeed * delta));
            if (KeyboardStateManager.IsNewPress(Keys.S)) command.AttemptedPosition = new Vector2(command.AttemptedPosition.X, command.AttemptedPosition.Y + (GameObject.MoveSpeed * delta));
            if (KeyboardStateManager.IsNewPress(Keys.A)) command.AttemptedPosition = new Vector2(command.AttemptedPosition.X - (GameObject.MoveSpeed * delta), command.AttemptedPosition.Y);
            if (KeyboardStateManager.IsNewPress(Keys.D)) command.AttemptedPosition = new Vector2(command.AttemptedPosition.X + (GameObject.MoveSpeed * delta), command.AttemptedPosition.Y);

            if (KeyboardStateManager.IsNewPress(Keys.Space)) GameObject.Input = new NpcInputComponent(GameObject);

            ((MinerGame)GameObject.Game).Commands.Add(command);
            // start of the chain of responsibility
            Handle(command);
        }

        public override void Handle(ICommand command)
        {
            if (Successor != null) Successor.Handle(command);
        }
    }
}