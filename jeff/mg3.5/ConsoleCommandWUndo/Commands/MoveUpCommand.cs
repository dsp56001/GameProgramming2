using ConsoleCommand;
using ConsoleCommandWUndo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleCommandWUndo.Commands
{
    public class MoveUpCommand : CommandWithUndo
    {
        public MoveUpCommand()
        {
            this.CommandName = "Move Up";
            this.UndoCommand = new UndoMoveUpCommand(this);
        }

        public override void Execute(GameComponent gc)
        {
            gc.MoveUp();
            base.Execute(gc);
        }
    }

    public class UndoMoveUpCommand : UndoCommand
    {

        public UndoMoveUpCommand(CommandWithUndo command) : base(command)
        {

        }

        public override void Execute(GameComponent gc)
        {
            gc.MoveDown();
            base.Execute(gc);
        }
    }
}
