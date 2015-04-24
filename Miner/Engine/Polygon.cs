using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace Engine
{
    public class Polygon
    {
        public Polygon()
        {
        }

        public Polygon(Vector2[] vertices)
        {
            Vertices = vertices;
        }

        [XmlElement]
        public Vector2[] Vertices { get; set; }
    }
}