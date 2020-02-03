using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationSingleton
{
    public class Singleton
    {
        //Private Static instance
        private static Singleton instance;

        //Private Constructor
        private Singleton() { }

        //Accessible Public instance
        public static Singleton Instance
        {
            get
            {
                //Lazy Load
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}
