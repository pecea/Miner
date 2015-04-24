using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Miner.Camera;
using Miner.ContentInitializers;
using Miner.GameObjects;

namespace Miner
{
    public class Stage : DrawableGameComponent
    {
        private Player _player;
        public Vector2 Size { get; set; }
        public StageLevel Level { get; set; }

        public Player Player
        {
            get { return _player; }
            set
            {
                var playerInObjectsList = Objects.OfType<Player>().SingleOrDefault();
                if (playerInObjectsList != null) Objects.Remove(playerInObjectsList);

                Objects.Add(value);
                _player = value;
            }
        }

        public List<GameObject> Objects { get; set; }

        public Stage(Game game)
            : base(game)
        {
            Objects = new List<GameObject>();
        }

        public Stage(Game game, StageLevel level, Vector2 size, Player player, IEnumerable<GameObject> objects)
            : this(game)
        {
            Level = level;
            Size = size;
            Player = player;
            Objects.AddRange(objects);
        }

        public void Draw(SpriteBatch spriteBatch, ICamera2D camera)
        {
            foreach (var gameObject in Objects)
            {
                gameObject.Draw(spriteBatch, camera);
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var gameObject in Objects)
            {
                gameObject.Update(gameTime);
            }
            base.Update(gameTime);
        }
    }
}