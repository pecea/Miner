using System.Linq;
using Microsoft.Xna.Framework;

namespace Miner
{
    public class BoundingBox
    {
        public BoundingBox()
        {
        }

        public BoundingBox(Vector2[] vertices)
        {
            Left = vertices.OrderBy(v => v.X).First();
            Right = vertices.OrderByDescending(v => v.X).First();
            Top = vertices.OrderBy(v => v.Y).First();
            Bottom = vertices.OrderByDescending(v => v.Y).First();
        }

        public Vector2 Left { get; set; }
        public Vector2 Right { get; set; }
        public Vector2 Top { get; set; }
        public Vector2 Bottom { get; set; }
    }
}