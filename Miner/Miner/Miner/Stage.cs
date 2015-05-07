using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Miner.ContentInitializers;
using Miner.GameObjects;

namespace Miner
{
    public class Stage : DrawableGameComponent
    {
        public Vector2 Size { get; set; }
        public StageLevel Level { get; set; }
        public Player Player { get; set; }
        public List<GameObject> GameObjects { get; set; }
        public CollisionSolver CollisionSolver { get; set; }

        public Stage(MinerGame game, StageLevel level, Vector2 size, IEnumerable<GameObject> objects)
            : base(game)
        {
            Level = level;
            Size = size;

            CollisionSolver = new CollisionSolver(this, game);

            GameObjects = objects.ToList();
            Game.Components.Add(CollisionSolver);

            foreach (var o in GameObjects)
                Game.Components.Add(o);

            Player = (Player)Game.Components.Single(o => o is Player);
        }
    }
}