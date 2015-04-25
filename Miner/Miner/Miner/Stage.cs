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

        public Stage(Game game, StageLevel level, Vector2 size, IEnumerable<GameObject> objects)
            : base(game)
        {
            Level = level;
            Size = size;

            foreach (var o in objects)
                Game.Components.Add(o);

            Player = (Player)Game.Components.Single(o => o is Player);
        }
    }
}