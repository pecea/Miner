using System.Linq;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace Miner
{
    public class Polygon
    {
        private float? _width;
        private float? _height;

        public Polygon()
        {
        }

        public Polygon(Vector2[] vertices)
            : this()
        {
            Vertices = vertices;
        }

        [XmlElement]
        public Vector2[] Vertices { get; set; }

        public float Width
        {
            get { return _width ?? (_width = Vertices.Max(v => v.X) - Vertices.Min(v => v.X)).Value; }
        }

        public float Height
        {
            get { return _height ?? (_height = Vertices.Max(v => v.Y) - Vertices.Min(v => v.Y)).Value; }
        }
    }
}