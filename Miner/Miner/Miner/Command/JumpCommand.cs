using Miner.GameObjects;

namespace Miner.Command
{
    public class JumpCommand : MovableGameObjectCommand
    {
        public JumpCommand(MovableGameObject gameObject) 
            : base(gameObject)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}