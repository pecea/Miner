using System;
using System.Globalization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Miner.Camera;

namespace Miner.GameObjects.Components
{
    public class DrawingComponent : Component, IFocusable
    {
        private readonly SpriteBatch _spriteBatch;

        public DrawingComponent(GameObject gameObject, SpriteBatch spriteBatch)
            : base(gameObject)
        {
            _spriteBatch = spriteBatch;
        }

        public Texture2D Texture { get; set; }
        public float Width { get { return Texture.Width; } }
        public float Height { get { return Texture.Height; } }
        public Vector2 Center
        {
            get { return new Vector2(GameObject.Position.X + (Width / 2), GameObject.Position.Y + (Height / 2)); }
        }

        public override void Update(GameTime gameTime)
        {
        }

        public void Draw(GameTime gameTime)
        {
            var o = GameObject as Player;
            if (o != null)
            {
                var str = String.Format("X: {0}, Y: {1}", o.Speed.X.ToString(CultureInfo.InvariantCulture), o.Speed.Y.ToString(CultureInfo.InvariantCulture));
                _spriteBatch.DrawString(((MinerGame)o.Game).Font, str, new Vector2(o.Position.X - 40, o.Position.Y - 40), Color.White);
            }
            _spriteBatch.Draw(Texture, GameObject.Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}