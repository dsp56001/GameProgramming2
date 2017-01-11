using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleCommand.Commands
{
    public class MoveRightCommand : Command
    {

        public MoveRightCommand()
        {
          
            this.CommandName = "Move Right";
        }
    

        public override void Execute(GameComponent gc)
        {
            gc.MoveRight();
            base.Execute(gc);
        }
    }
}
