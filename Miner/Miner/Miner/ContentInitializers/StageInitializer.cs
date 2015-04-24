using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Miner.Factory;
using Miner.GameObjects;

namespace Miner.ContentInitializers
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

        public static Stage Initialize(Game game, StageLevel level)
        {
            Stage stage;
            XmlSerializer serializer = new XmlSerializer(typeof(StageInitializer));

            using (var reader = new StreamReader(GetStageFilePath(level)))
            {
                stage = ((StageInitializer)serializer.Deserialize(reader)).ToStage(game, level);
            }

            return stage;
        }

        private Stage ToStage(Game game, StageLevel level)
        {
            var player = _playerFactory.Create(game, Player.Texture, Player.Position, Player.Shape) as Player;
            var terrain = Terrain.Select(t => _terrainFactory.Create(game, t.Texture, t.Position, t.Shape));

            return new Stage(game, level, Size, player, terrain);
        }

        private static string GetStageFilePath(StageLevel stageLevel)
        {
            var pathBase = AppSettings.Default.StagesPath;
            pathBase += stageLevel.ToString().ToLower();
            pathBase += ".xml";

            return pathBase;
        }
    }
}