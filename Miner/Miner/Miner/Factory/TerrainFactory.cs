using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Miner.GameObjects;

namespace Miner.Factory
{
    public class TerrainFactory : IGameObjectFactory
    {
        public GameObject Create(Game game, string texturePath, Vector2 position, Polygon shape)
        {
            var terrain = new Terrain(game);
            terrain.Initialize(game.Content.Load<Texture2D>(texturePath), position, shape);

            return terrain;
        }
    }
}