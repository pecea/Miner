using Microsoft.Xna.Framework;
using Miner.GameObjects;

namespace Miner.Factory
{
    public interface IGameObjectFactory
    {
        GameObject Create(Game game, string texturePath, Vector2 position, Polygon shape);
    }
}