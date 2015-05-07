using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Miner.GameObjects;

namespace Miner.ContentInitializers
{
    [XmlRoot]
    [Serializable]
    public class StageCreator
    {
        [XmlElement]
        public Vector2 Size { get; set; }

        [XmlElement]
        public GameObjectInitializer Player { get; set; }

        [XmlArray]
        public GameObjectInitializer[] Terrain { get; set; }

        public static Stage Create(MinerGame game, StageLevel level)
        {
            Stage stage;
            XmlSerializer serializer = new XmlSerializer(typeof(StageCreator));

            using (var reader = new StreamReader(GetStageFilePath(level)))
            {
                var creator = (StageCreator) serializer.Deserialize(reader);
                var objects = creator.LoadGameObjects(game, level);
                stage = new Stage(game, level, creator.Size, objects);
            }

            return stage;
        }

        private IEnumerable<GameObject> LoadGameObjects(MinerGame game, StageLevel level)
        {
            var gameObjectsList = new List<GameObject>();

            gameObjectsList.Add(new Player(game, Player));
            gameObjectsList.AddRange(Terrain.Select(t => new Terrain(game, t)));

            return gameObjectsList;
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