using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCommand
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool playingGame = true;    //Bool used to loop unti Q is presse
            //Face Game Component
            GameComponent fakeComponent = new GameComponent();
            while (playingGame) //really bad game loop
            {

                ConsoleKeyInfo keyI = AskForCommand();

                Command command = null;
                switch (keyI.Key)
                {
                    case ConsoleKey.A:          //Move left
                    case ConsoleKey.LeftArrow:
                        command = new Commands.MoveLeftCommand();
                        break;
                    case ConsoleKey.D:          //Move right
                    case ConsoleKey.RightArrow:
                        command = new Commands.MoveRightCommand();
                        break;
                    case ConsoleKey.W:          //Move up
                    case ConsoleKey.UpArrow:
                        command = new Commands.MoveUpCommand();
                        break;
                    case ConsoleKey.S:          //Move down
                    case ConsoleKey.DownArrow:
                        command = new Commands.MoveDownCommand();
                        break;
                    case ConsoleKey.Escape:     //Exit game
                    case ConsoleKey.Q:
                        playingGame = false;
                        break;

                }
                if (command != null)
                {
                    command.Execute(fakeComponent);
                }
                else
                {
                    Console.WriteLine("Sorry I don't know that command");
                }

                Console.WriteLine(fakeComponent.About());
            }
        }

        private static ConsoleKeyInfo AskForCommand()
        {
            Console.Write("Please enter a key:");
            ConsoleKeyInfo ki = Console.ReadKey();
            Console.WriteLine(""); //new line
            return ki;
        }
    }
}
