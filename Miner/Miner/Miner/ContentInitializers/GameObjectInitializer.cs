using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace Miner.ContentInitializers
{
    public class GameObjectInitializer
    {
        [XmlAttribute]
        public float X { get; set; }

        [XmlAttribute]
        public float Y { get; set; }

        [XmlAttribute]
        public string Texture { get; set; }

        [XmlElement]
        public Polygon Shape { get; set; }

        public Vector2 Position { get { return new Vector2(X, Y);} }
    }
}