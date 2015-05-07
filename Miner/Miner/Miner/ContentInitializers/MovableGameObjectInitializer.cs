using System.Xml.Serialization;

namespace Miner.ContentInitializers
{
    public class MovableGameObjectInitializer : GameObjectInitializer
    {
        [XmlAttribute]
        public float MoveSpeed { get; set; }
    }
}