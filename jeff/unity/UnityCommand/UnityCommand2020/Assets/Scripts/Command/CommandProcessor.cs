﻿using ConsoleCommandWUndo;
using ConsoleCommandWUndo.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityCommand
{
    class CommandProcessor : MonoBehaviour
    {
        bool debug = false;
        KeyMap keyMap;

        //List of previously processed commands
        Stack<ICommand> Commands = new Stack<ICommand>();

        public GameObject MoveCommandTarget;

        public object CommandWUndo { get; private set; }

        public CommandProcessor() : base ()
        {
            
        }
        public virtual void Start()
        {
            //keyMap = new KeyMapReleaseMove();
            keyMap = new KeyMapDownMove();
            Commands.Clear();
        }

        public void Update()
        {
            //Check keys in keymap
            //Has Released Keys
            foreach (var item in keyMap.OnReleasedKeyMap)
            {
                //will generate two commands if there are two keys...
                if (Input.GetKeyUp(item.Key))
                {
                    if(debug)Debug.Log(string.Format("onReleasedKeyMap Key released {0}", item.Value.ToString())); //Log key to console
                    MakeCommand(item);
                }
            }

            //Holding Key Down Map
            foreach (var item in keyMap.OnKeyDownMap)
            {
                if (Input.GetKey(item.Key))
                {
                    if(debug)Debug.Log(string.Format("onKeyDownMap Key held {0}", item.Value.ToString())); //Log key to console
                    MakeCommand(item);
                }
                if (Input.GetKeyUp(item.Key))
                {
                    if(debug)Debug.Log(string.Format("onKeyDownMap Key released {0}", item.Value.ToString())); //Log key to console
                    
                }
            }
            //base.Update(gameTime);
        }

        private void MakeCommand(KeyValuePair<KeyCode, string> item)
        {
            Command command = null;
            switch (item.Value)
            {
                case "Move Up":
                    //trigger Move Up command
                    command = new MoveUpCommand();
                    break;
                case "Move Down":
                    //trigger Move Down command
                    command = new MoveDownCommand();
                    break;
                case "Move Left":
                    //trigger Move Left command
                    command = new MoveLeftCommand();
                    break;
                case "Move Right":
                    //trigger Move Down command
                    command = new MoveRightCommand();
                    break;
                case "Undo":
                    if (Commands.Count > 0)
                    {
                        command = (Command)Commands.Pop();
                        if (command is ICommandWithUndo) //if the popped command has an undo command use it
                        {
                            command = ((ICommandWithUndo)command).UndoCommand;
                        }
                    }
                    break;
            }
            if (command != null)
            {
                if (command is ICommandWithUndo)
                {
                    Commands.Push((ICommandWithUndo)command); //only push commands with undo to the stack
                }
                
                //execute right
                command.Execute(MoveCommandTarget);
            }
        }
    }
}
