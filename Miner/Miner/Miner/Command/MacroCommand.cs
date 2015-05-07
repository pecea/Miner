using System;
using System.Collections.Generic;

namespace Miner.Command
{
    [Obsolete("Na razie nie trzeba, jak sie okaze ze w ogole nie trzeba to nara z tym")]
    public class MacroCommand : ICommand
    {
        public MacroCommand()
        {
            Commands = new List<ICommand>();
        }

        public List<ICommand> Commands { get; set; }

        public void Add(params ICommand[] commands)
        {
            Commands.AddRange(commands);
        }

        public void Execute()
        {
            foreach (var command in Commands)
            {
                command.Execute();
            }
        }
    }
}