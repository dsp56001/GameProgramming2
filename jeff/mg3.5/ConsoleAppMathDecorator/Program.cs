using DecoratorSample;
using System;

namespace ConsoleAppMathDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            MathDecorator md = new MathDecorator();
            md.AddComponent(new AddOne());
            md.AddComponent(new AddOne());
            md.AddComponent(new AddThree());
            Console.WriteLine(md.Calculate());

            MathComponentDecoratorNode mdn = new MathComponentDecoratorNode();
            mdn.AddComponent(new MathComponentDecoratorNodeAdd1());
            mdn.AddComponent(new MathComponentDecoratorNodeAdd2());

            MathComponentDecoratorNodeAdd1 one = new MathComponentDecoratorNodeAdd1();
            one.AddComponent(new MathComponentDecoratorNodeAdd3());

            

            Console.WriteLine(mdn.Calculate());

            Console.ReadLine();
        }
    }
}
