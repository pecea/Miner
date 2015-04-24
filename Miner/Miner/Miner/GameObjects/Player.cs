using Microsoft.Xna.Framework;
using Miner.GameObjects.Components;

namespace Miner.GameObjects
{
    public class Player : MovableGameObject
    {
        public Player(Game game) 
            : base(game)
        {
            Input = new PlayerInputComponent(this, 700f);
        }
    }
}