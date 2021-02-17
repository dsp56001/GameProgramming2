using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ConsoleCommandWUndo
{
    public class Command : ICommand
    {
        public string CommandName;       //Name For logging
        static bool debug = false;
        public Command()
        {

        }

        public virtual void Execute(GameObject gc)
        {
            this.Log();     //Log that command happened;
        }

        string LogString;

        protected virtual string Log()
        {


#if DEBUG
            LogString = string.Format("{0} executed.", CommandName);
            //Only write to console if run in Debug
            if (debug)Debug.Log(LogString);
#endif
            return LogString;
        }
    }
}
