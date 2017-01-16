using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleCommand
{
    /// <summary>
    /// ICommand Exceutes on a GameComponent
    /// </summary>
    interface ICommand
    {
        void Execute(GameComponent go);
    }
}
