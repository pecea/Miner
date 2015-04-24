﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Miner.Controllers
{
    public abstract class Controller : DrawableGameComponent
    {
        protected Controller(Game game) 
            : base(game)
        {
        }

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}