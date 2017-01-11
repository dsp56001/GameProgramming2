using ConsoleCommand;
using ConsoleCommandWUndo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleCommandWUndo.Commands
{
    public class MoveRightCommand : CommandWithUndo
    {

        public MoveRightCommand()
        {
          
            this.CommandName = "Move Right";
            this.UndoCommand = new UndoMoveRightCommand(this);
        }
    

        public override void Execute(GameComponent gc)
        {
            gc.MoveRight();
            base.Execute(gc);
        }
    }

    public class UndoMoveRightCommand : UndoCommand
    {

        public UndoMoveRightCommand(CommandWithUndo command) : base(command)
        {

        }

        public override void Execute(GameComponent gc)
        {
            gc.MoveLeft();
            base.Execute(gc);
        }
    }
}
