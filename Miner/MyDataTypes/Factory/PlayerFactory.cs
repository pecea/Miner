using System.Collections.Generic;
using Engine.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Factory
{
    public class PlayerFactory : IGameObjectFactory
    {
        public GameObject Create(ContentManager content, string texturePath, Vector2 position, Polygon shape)
        {
            var player = new Player();
            player.Initialize(content.Load<Texture2D>(texturePath), position, shape);

            return player;
        }
    }
}