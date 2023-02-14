using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleCommandWUndo;
using ConsoleCommand;

namespace ConsoleCommandWUndo.Commands
{
    public class MoveDownCommand : CommandWithUndo
    {
        public MoveDownCommand()
        {
            this.CommandName = "Move Down";
            this.UndoCommand = new UndoMoveDownCommand(this);
        }

        public override void Execute(GameComponent gc)
        {
            gc.MoveDown();
            base.Execute(gc);
        }
    }

    public class UndoMoveDownCommand : UndoCommand
    {

        public UndoMoveDownCommand(CommandWithUndo command) : base(command)
        {

        }

        public override void Execute(GameComponent gc)
        {
            gc.MoveUp();
            base.Execute(gc);
        }
    }
}
