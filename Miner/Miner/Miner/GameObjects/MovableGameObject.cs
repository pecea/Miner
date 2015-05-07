using System;
using Microsoft.Xna.Framework;
using Miner.ContentInitializers;
using Miner.GameObjects.Components;

namespace Miner.GameObjects
{
    public abstract class MovableGameObject : GameObject
    {
        public const float JumpStartSpeed = 12;
        public const float GravityAccelecation = 0.1f;
        public const float MaxGravitySpeed = 0.01F;
        public const float DeceleratingSpeed = 1;

        protected MovableGameObject(MinerGame game, GameObjectInitializer initializer)
            : base(game, initializer)
        {
            Physics = new MovablePhysicsComponent(this);
        }

        public Vector2 Speed { get; set; }
        public InputComponent Input { get; set; }
        public float MoveSpeedX { get; set; }
        public bool Airborne { get; set; }
        public bool Moving { get; set; }

        public override void Update(GameTime gameTime)
        {
            Input.Update(gameTime);

            base.Update(gameTime);
        }

        public virtual void LandOn(GameObject obj)
        {
            Airborne = false;
        }
    }
}