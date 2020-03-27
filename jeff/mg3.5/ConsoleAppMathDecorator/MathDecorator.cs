using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorSample
{
    class MathDecorator : IMathComponent
    {
        List<IMathComponent> Maths;

        int solution;

        public MathDecorator()
        {
            Maths = new List<IMathComponent>();
        }

        public int Calculate(int input)
        {
            foreach (var item in Maths)
            {
                solution = item.Calculate(solution);
            }
            return solution;
        }

        public void AddComponent(IMathComponent compenent)
        {
            this.Maths.Add(compenent);
        }

        public void RemoveComponetn(IMathComponent component)
        {
            this.Maths.Remove(component);
        }
    }
}
