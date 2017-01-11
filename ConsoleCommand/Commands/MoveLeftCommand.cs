using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleCommand.Commands
{
    public class MoveLeftCommand : Command
    {

        public MoveLeftCommand()
        {
            this.CommandName = "Move Left";
        }

        public override void Execute(GameComponent gc)
        {
            gc.MoveLeft();
            base.Execute(gc);
        }
    }
}
