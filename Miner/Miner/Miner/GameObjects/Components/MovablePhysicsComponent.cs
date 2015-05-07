using Microsoft.Xna.Framework;

namespace Miner.GameObjects.Components
{
    public class MovablePhysicsComponent : PhysicsComponent
    {
        public MovablePhysicsComponent(GameObject gameObject)
            : base(gameObject)
        {
            GameObject = (MovableGameObject)gameObject;
        }

        public new MovableGameObject GameObject { get; set; }

        public override void Update(GameTime gameTime)
        {
            MoveX();
            MoveY();
        }

        private void MoveY()
        {
            // change Y position
            if (GameObject.Airborne)
            {
                GameObject.Speed = new Vector2(GameObject.Speed.X, GameObject.Speed.Y + MovableGameObject.GravityAccelecation);
                GameObject.Position = new Vector2(GameObject.Position.X, GameObject.Position.Y + GameObject.Speed.Y);

                /*// stop falling if ground reached
                if (GameObject.Position.Y >= 500)
                {
                    GameObject.Position = new Vector2(GameObject.Position.X, 500);
                    GameObject.Speed = new Vector2(GameObject.Speed.X, 0);
                    GameObject.Airborne = false;
                }*/
            }
        }

        private void MoveX()
        {
            // change X position
            if (!GameObject.Moving)
            {
                GameObject.Speed = new Vector2(
                    GameObject.Speed.X > 0
                        ? GameObject.Speed.X - MovableGameObject.DeceleratingSpeed
                        : GameObject.Speed.X + MovableGameObject.DeceleratingSpeed, GameObject.Speed.Y);
            }

            // Deceleration may produce a speed that is greater than zero but
            // smaller than the smallest unit of deceleration. These lines ensure
            // that the player does not keep travelling at slow speed forever after
            // decelerating.
            if (GameObject.Speed.X > 0 && GameObject.Speed.X <= MovableGameObject.DeceleratingSpeed)
                GameObject.Speed = new Vector2(0, GameObject.Speed.Y);
            if (GameObject.Speed.X < 0 && GameObject.Speed.X >= -MovableGameObject.DeceleratingSpeed)
                GameObject.Speed = new Vector2(0, GameObject.Speed.Y);

            GameObject.Position = new Vector2(GameObject.Position.X + GameObject.Speed.X, GameObject.Position.Y);
        }
    }
}