using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Engine.Factory;
using Engine.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Engine.ContentInitializers
{
    [XmlRoot]
    [Serializable]
    public class StageInitializer
    {
        private PlayerFactory _playerFactory;
        private TerrainFactory _terrainFactory;

        public StageInitializer()
        {
            _playerFactory = new PlayerFactory();
            _terrainFactory = new TerrainFactory();
        }

        [XmlElement]
        public Vector2 Size { get; set; }

        [XmlElement]
        public GameObjectInitializer Player { get; set; }

        [XmlArray]
        public GameObjectInitializer[] Terrain { get; set; }

        public static Stage Initialize(ContentManager content)
        {
            Stage stage;
            XmlSerializer serializer = new XmlSerializer(typeof(StageInitializer));

            using (var reader = new StreamReader(@"..\..\..\..\MinerContent\StageLevels\one.xml"))
            {
                stage = ((StageInitializer)serializer.Deserialize(reader)).ToStage(content);
            }

            return stage;
        }

        private Stage ToStage(ContentManager content)
        {
            var player = _playerFactory.Create(content, "Textures\\Player\\player", Player.Position, Player.Shape) as Player;
            var terrain = Terrain.Select(t => _terrainFactory.Create(content, t.Texture, t.Position, t.Shape));

            return new Stage(Size, player, terrain);
        }
    }
}