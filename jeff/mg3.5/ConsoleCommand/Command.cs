using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleCommand
{
    public class Command : ICommand
    {

        public string CommandName;

        public Command()
        {

        }

        public virtual void Execute(GameComponent gc)
        {
            this.Log();
        }

        protected virtual void Log()
        {
            Console.WriteLine(string.Format("{0} executed.",CommandName));
        }
    }
}
