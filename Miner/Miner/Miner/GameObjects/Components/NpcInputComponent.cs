using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Miner.Command;

namespace Miner.GameObjects.Components
{
    public class NpcInputComponent : InputComponent
    {
        private ICommand _currentCommand;
        private int _currentCommandIndex;

        public NpcInputComponent(GameObject gameObject) 
            : base(gameObject)
        {
            Successor = gameObject.Physics;
        }

        public override void Update(GameTime gameTime)
        {
            if (_currentCommand == null)
            {
                _currentCommand = ((MinerGame) GameObject.Game).Commands.First();
                _currentCommandIndex = 0;
            }
            else
            {
                if (_currentCommandIndex < ((MinerGame)GameObject.Game).Commands.Count)
                _currentCommand = ((MinerGame) GameObject.Game).Commands[_currentCommandIndex++];
            }

            Handle(_currentCommand);
        }

        public override void Handle(ICommand command)
        {
            if (Successor != null) Successor.Handle(command);
        }
    }
}