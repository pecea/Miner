using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Miner.GameObjects.Components
{
    public class PlayerInputComponent : InputComponent
    {
        public PlayerInputComponent(GameObject gameObject, float moveSpeed) 
            : base(gameObject)
        {
            GameObject.MoveSpeed = moveSpeed;
        }
        
        public override void Update(GameTime gameTime)
        {
            KeyboardStateManager.UpdateKeyboardState();
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (KeyboardStateManager.IsCurPress(Keys.W)) Move(Direction.Up, delta);
            if (KeyboardStateManager.IsCurPress(Keys.S)) Move(Direction.Down, delta);
            if (KeyboardStateManager.IsCurPress(Keys.A)) Move(Direction.Left, delta);
            if (KeyboardStateManager.IsCurPress(Keys.D)) Move(Direction.Right, delta);

            if (KeyboardStateManager.IsNewPress(Keys.W)) Move(Direction.Up, delta);
            if (KeyboardStateManager.IsNewPress(Keys.S)) Move(Direction.Down, delta);
            if (KeyboardStateManager.IsNewPress(Keys.A)) Move(Direction.Left, delta);
            if (KeyboardStateManager.IsNewPress(Keys.D)) Move(Direction.Right, delta);
        }
    }
}