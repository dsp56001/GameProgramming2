using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCommandWUndo
{
    class Program
    {
        static void Main(string[] args)
        {
            //test instance of a Console Command Proccessor
            ConsoleCommandProcessor proc = new ConsoleCommandProcessor();
            proc.Run();
        }
    }
}
