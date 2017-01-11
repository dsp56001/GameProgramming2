using ConsoleCommand;
using ConsoleCommandWUndo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleCommandWUndo.Commands
{
    public class MoveLeftCommand : CommandWithUndo
    {
        public MoveLeftCommand()
        {
            this.CommandName = "Move Left";
            this.UndoCommand = new UndoMoveLeftCommand(this);
        }

        public override void Execute(GameComponent gc)
        {
            gc.MoveLeft();
            base.Execute(gc);
        }
    }

    public class UndoMoveLeftCommand : UndoCommand
    {

        public UndoMoveLeftCommand(CommandWithUndo command) : base (command)
        {

        }

        public override void Execute(GameComponent gc)
        {
            gc.MoveRight();
            base.Execute(gc);
        }
    }
}
