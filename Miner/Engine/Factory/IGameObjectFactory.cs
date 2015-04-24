using Engine.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Engine.Factory
{
    public interface IGameObjectFactory
    {
        GameObject Create(ContentManager content, string texturePath, Vector2 position, Polygon shape);
    }
}