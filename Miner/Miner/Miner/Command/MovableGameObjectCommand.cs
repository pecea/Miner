using Miner.GameObjects;

namespace Miner.Command
{
    public abstract class MovableGameObjectCommand : ICommand
    {
        protected MovableGameObject GameObject { get; set; }

        protected MovableGameObjectCommand(MovableGameObject gameObject)
        {
            GameObject = gameObject;
        }

        public abstract void Execute();
    }
}