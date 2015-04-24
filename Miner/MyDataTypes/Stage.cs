using System.Collections.Generic;
using System.Linq;
using Engine.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class Stage
    {
        private Player _player;
        public Vector2 Size { get; set; }

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

        public Stage()
        {
            Objects = new List<GameObject>();
        }

        public Stage(Vector2 size, Player player, IEnumerable<GameObject> objects)
            : this()
        {
            Size = size;
            Player = player;
            Objects.AddRange(objects);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var gameObject in Objects)
            {
                gameObject.Draw(spriteBatch);
            }
        }
    }
}