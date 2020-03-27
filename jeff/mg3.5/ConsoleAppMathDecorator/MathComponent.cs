using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorSample
{
    
    public interface IMathComponent
    {
        int Calculate(int input);
    }

    public abstract class MathComponent : IMathComponent
    {   
        public virtual int Calculate(int input)
        {
            return input;
        }

    }

    public class AddOne : MathComponent
    {
        public override int Calculate(int input)
        {
            return base.Calculate(input) + 1;
        }
    }

    public class AddTwo : MathComponent
    {
        public override int Calculate(int input)
        {
            return base.Calculate(input) + 2;
        }
    }

    public class AddThree : MathComponent
    {
        public override int Calculate(int input)
        {
            return base.Calculate(input) + 3;
        }
    }
}
