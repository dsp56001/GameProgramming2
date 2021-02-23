using ConsoleCommandWUndo;
using UnityCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ConsoleCommandWUndo.Commands
{
    public enum MoveCommandName {  MoveLeft, MoveRight, MoveUp, MoveDown }
    
    
    public class MoveRightCommand : CommandWithUndo
    {

        public MoveRightCommand() : base ()
        {
          
            this.CommandName = MoveCommandName.MoveRight;
            this.UndoCommand = new UndoMoveRightCommand(this);
        }
    

        public override void Execute(GameObject gc)
        {
            //Different Game Components may move differently check if the gc is a CommandPacMan
            var target = gc.GetComponent<Player>();
            if (target is Player)
            {
                target.MoveRight();
            }
            base.Execute(gc);
        }
    }

    public class UndoMoveRightCommand : UndoCommand
    {

        public UndoMoveRightCommand(CommandWithUndo command) : base(command)
        {

        }

        public override void Execute(GameObject gc)
        {
            //Different Game Components may move differently check if the gc is a CommandPacMan
            var target = gc.GetComponent<Player>();
            if (target is Player)
            {
                target.MoveLeft();
            }
            base.Execute(gc);
        }
    }
}
