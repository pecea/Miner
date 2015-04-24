using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Miner.Camera;
using Miner.ContentInitializers;

namespace Miner.Controllers
{
    public class GameController : Controller
    {
        readonly StageLevel _level;
        readonly Camera2D _camera;

        Stage _stage;

        public GameController(Game game, StageLevel level)
            : base(game)
        {
            _level = level;
            _camera = new Camera2D(game);
        }

        public override void Initialize()
        {
            _stage = StageInitializer.Initialize(Game, _level);
           
            _camera.Focus = _stage.Player.Drawing;
            _camera.Initialize();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _stage.Draw(spriteBatch, _camera);
        }

        public override void Update(GameTime gameTime)
        {
            _camera.Update(gameTime);
            _stage.Update(gameTime);
            base.Update(gameTime);
        }
    }
}