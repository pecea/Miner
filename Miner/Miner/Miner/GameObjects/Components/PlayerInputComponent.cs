using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Miner.GameObjects.Components
{
    public class PlayerInputComponent : InputComponent
    {
        public PlayerInputComponent(GameObject gameObject, float moveSpeedX) 
            : base(gameObject)
        {
            GameObject.MoveSpeedX = moveSpeedX;
        }
        
        public override void Update(GameTime gameTime)
        {
            KeyboardStateManager.UpdateKeyboardState();
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (KeyboardStateManager.IsCurPress(Keys.A)) Move(Direction.Left, delta);
            if (KeyboardStateManager.IsCurPress(Keys.D)) Move(Direction.Right, delta);

            if (KeyboardStateManager.IsNewPress(Keys.A)) Move(Direction.Left, delta);
            if (KeyboardStateManager.IsNewPress(Keys.D)) Move(Direction.Right, delta);

            if (KeyboardStateManager.IsCurPress(Keys.Space) && !GameObject.Airborne) Jump();

            base.Update(gameTime);
        }
    }
}