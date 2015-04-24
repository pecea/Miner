using Microsoft.Xna.Framework.Input;

namespace Miner
{
    public static class KeyboardStateManager
    {
        private static KeyboardState _lastKeyboardState;
        private static KeyboardState _currentKeyboardState;

        public static KeyboardState LastKeyboardState
        {
            get { return _lastKeyboardState; }
        }

        public static KeyboardState CurrentKeyboardState
        {
            get { return _currentKeyboardState; }
        }

        public static void UpdateKeyboardState()
        {
            _lastKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();
        }

        public static bool IsNewPress(Keys key)
        {
            return (_lastKeyboardState.IsKeyUp(key) && _currentKeyboardState.IsKeyDown(key));
        }

        public static bool IsCurPress(Keys key)
        {
            return (_lastKeyboardState.IsKeyDown(key) && _currentKeyboardState.IsKeyDown(key));
        }

        public static bool IsOldPress(Keys key)
        {
            return (_lastKeyboardState.IsKeyDown(key) && _currentKeyboardState.IsKeyUp(key));
        } 
    }
}