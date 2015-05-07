using System;
using Microsoft.Xna.Framework;
using Miner.GameObjects.Components;

namespace Miner.GameObjects
{
    public class CollisionSolver : GameComponent
    {
        public const int CollisionSolverIterations = 1;
        public Stage Stage { get; set; }

        public CollisionSolver(Stage stage, MinerGame game)
            : base(game)
        {
            Stage = stage;
        }

        public override void Update(GameTime gameTime)
        {
            var objectsCount = Stage.GameObjects.Count;

            for (int i = 0; i < CollisionSolverIterations; i++)
                for (int j = 0; j < objectsCount; j++)
                    for (int k = j + 1; k < objectsCount; k++)
                    {
                        var object1 = Stage.GameObjects[j];
                        var object2 = Stage.GameObjects[k];

                        if (object1.Physics.BoundingBox.Intersects(object2.Physics.BoundingBox))
                        {
                            Direction x;

                            if (Math.Abs(object1.Physics.BoundingBox.Bottom - object2.Physics.BoundingBox.Top) < 4)
                            {
                                object1.Collide(object2, Direction.Down);
                                object2.Collide(object1, Direction.Up);
                            }
                            else
                            {
                                var o = object1 as MovableGameObject;
                                if (o != null) 
                                    o.Airborne = true;

                                if (Math.Abs(object1.Physics.BoundingBox.Top - object2.Physics.BoundingBox.Bottom) < 4)
                                {
                                    object1.Collide(object2, Direction.Up);
                                    object2.Collide(object1, Direction.Down);
                                }
                                else if (Math.Abs(object1.Physics.BoundingBox.Right - object2.Physics.BoundingBox.Left) < 4)
                                {
                                    object1.Collide(object2, Direction.Right);
                                    object2.Collide(object1, Direction.Left);
                                }
                                else if (Math.Abs(object1.Physics.BoundingBox.Left - object2.Physics.BoundingBox.Right) < 4)
                                {
                                    object1.Collide(object2, Direction.Left);
                                    object2.Collide(object1, Direction.Right);
                                }
                            }
                        }
                        else
                        {
                            var o = object1 as MovableGameObject;
                            if (o != null) o.Airborne = true;
                        }
                    }
        }

        public override void Initialize()
        {
        }
    }
}