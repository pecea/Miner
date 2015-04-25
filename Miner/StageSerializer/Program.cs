using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Miner;
using Miner.ContentInitializers;

namespace StageSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(StageCreator));
            var stage = new StageCreator()
            {
                Player = new GameObjectInitializer { X = 0, Y = 300, Texture = "Textures\\Player\\player", Shape = new Polygon(new[] { new Vector2(0, 0), new Vector2(0, 10), new Vector2(10, 0) }) },
                Size = new Vector2(1200, 600),
            };

            var t = new List<GameObjectInitializer>();
            for (var i = 0; i < 38; i++)
            {
                t.Add(new GameObjectInitializer { X = i * 32, Y = 568, Texture = "Textures\\terrain", Shape = new Polygon(new[] { new Vector2(0, 0), new Vector2(0, 32), new Vector2(32, 32), new Vector2(32, 0) }) });
            }

            for (var i = 0; i < 10; i++)
            {
                t.Add(new GameObjectInitializer { X = i * 32, Y = 536, Texture = "Textures\\terrain", Shape = new Polygon(new[] { new Vector2(0, 0), new Vector2(0, 32), new Vector2(32, 32), new Vector2(32, 0) }) });
            }
            t.Add(new GameObjectInitializer { X = 10 * 32, Y = 536, Texture = "Textures\\terrain_nw_se", Shape = new Polygon(new[] { new Vector2(0, 0), new Vector2(0, 32), new Vector2(32, 32) }) });
            t.Add(new GameObjectInitializer { X = 27 * 32, Y = 536, Texture = "Textures\\terrain_sw_ne", Shape = new Polygon(new[] { new Vector2(0, 32), new Vector2(32, 32), new Vector2(32, 0) }) });

            for (var i = 28; i < 38; i++)
            {
                t.Add(new GameObjectInitializer { X = i * 32, Y = 536, Texture = "Textures\\terrain", Shape = new Polygon(new[] { new Vector2(0, 0), new Vector2(0, 32), new Vector2(32, 32), new Vector2(32, 0) }) });
            }

            stage.Terrain = t.ToArray();

            StreamWriter writer = new StreamWriter(@"C:\Users\Piotr\Source\Repos\Miner\Miner\Miner\MinerContent\StageLevels\one.xml");
            serializer.Serialize(writer, stage);
            writer.Close();
        }
    }
}
