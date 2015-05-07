using System;
using System.Collections.Generic;

namespace Miner.Command
{
    public abstract class Handler
    {
        public IEnumerable<Type> Types { get; set; }
        public Handler Successor { get; set; }

        public abstract void Handle(ICommand command);

        public virtual bool CanHandle(ICommand command)
        {
            return true;
        }
    }
}