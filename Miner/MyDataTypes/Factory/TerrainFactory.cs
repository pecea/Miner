using Engine.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Factory
{
    public class TerrainFactory : IGameObjectFactory
    {
        public GameObject Create(ContentManager content, string texturePath, Vector2 position, Polygon shape)
        {
            var terrain = new Terrain();
            terrain.Initialize(content.Load<Texture2D>(texturePath), position, shape);

            return terrain;
        }
    }
}