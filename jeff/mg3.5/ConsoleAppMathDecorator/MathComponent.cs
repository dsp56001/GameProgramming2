using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppMathDecorator
{
    
    interface IMathComponent
    {
        int Calculate(int input);
    }
    
    abstract class MathComponent : IMathComponent
    {
        public virtual int Calculate(int input)
        {
            return input;
        }

    }

    class AddOne : MathComponent
    {
        public override int Calculate(int input)
        {
            return base.Calculate(input) + 1;
        }
    }

    class AddTwo : MathComponent
    {
        public override int Calculate(int input)
        {
            return base.Calculate(input) + 2;
        }
    }

    class AddThree : MathComponent
    {
        public override int Calculate(int input)
        {
            return base.Calculate(input) + 3;
        }
    }
}
