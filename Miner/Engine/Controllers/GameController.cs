using Engine.ContentInitializers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Controllers
{
    public class GameController : Controller
    {
        Stage _stage;

        public GameController(Game game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            _stage = StageInitializer.Initialize(Game.Content);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _stage.Draw(spriteBatch);
        }
    }
}