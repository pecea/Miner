using System;
using Miner.ContentInitializers;
using Miner.GameObjects.Components;

namespace Miner.GameObjects
{
    public class Player : MovableGameObject
    {
        public Player(MinerGame game, GameObjectInitializer initializer)
            : base(game, initializer)
        {
            Input = new PlayerInputComponent(this, 700f);
            Airborne = true;
        }

        public override void Collide(GameObject obj, Direction dir)
        {
            DrawingComponent.Text = String.Format("Collision {0}!", dir);

            if (dir == Direction.Down) LandOn(obj);
        }
    }
}