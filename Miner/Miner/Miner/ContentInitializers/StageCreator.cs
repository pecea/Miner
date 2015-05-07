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
        public MovableGameObjectInitializer Player { get; set; }

        [XmlArray]
        public GameObjectInitializer[] Terrain { get; set; }

        public static Stage Create(MinerGame game, StageLevel level)
        {
            using (var reader = new StreamReader(GetStageFilePath(level)))
            {
                var serializer = new XmlSerializer(typeof(StageCreator));
                var creator = (StageCreator) serializer.Deserialize(reader);
                var objects = creator.LoadGameObjects(game, level);

                return new Stage(game, level, creator.Size, objects);
            }
        }

        private IEnumerable<GameObject> LoadGameObjects(MinerGame game, StageLevel level)
        {
            var gameObjectsList = new List<GameObject>();

            gameObjectsList.AddRange(Terrain.Select(t => new Terrain(game, t)));
            gameObjectsList.Add(new Player(game, Player));

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