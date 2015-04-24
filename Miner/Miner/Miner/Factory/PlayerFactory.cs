using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Miner.GameObjects;

namespace Miner.Factory
{
    public class PlayerFactory : IGameObjectFactory
    {
        public GameObject Create(Game game, string texturePath, Vector2 position, Polygon shape)
        {
            var player = new Player(game);
            player.Initialize(game.Content.Load<Texture2D>(texturePath), position, shape);

            return player;
        }
    }
}