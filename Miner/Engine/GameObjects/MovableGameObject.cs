using Engine.GameObjects.Components;

namespace Engine.GameObjects
{
    public abstract class MovableGameObject : GameObject
    {
        protected MovableGameObject()
        {
            Input = new InputComponent();
        }

        public InputComponent Input { get; set; }
    }
}