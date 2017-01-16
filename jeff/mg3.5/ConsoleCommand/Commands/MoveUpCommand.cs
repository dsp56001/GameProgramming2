using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleCommand.Commands
{
    public class MoveUpCommand : Command
    {
        public MoveUpCommand()
        {
            this.CommandName = "Move Up";
            
        }

        public override void Execute(GameComponent gc)
        {
            gc.MoveUp();
            base.Execute(gc);
        }
    }
    
}
