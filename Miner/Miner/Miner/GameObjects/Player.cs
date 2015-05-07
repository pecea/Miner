using Miner.ContentInitializers;
using Miner.GameObjects.Components;

namespace Miner.GameObjects
{
    public class Player : MovableGameObject
    {
        public Player(MinerGame game, MovableGameObjectInitializer initializer)
            : base(game, initializer)
        {
            Input = new PlayerInputComponent(this);
        }
    }
}