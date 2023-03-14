using Microsoft.Extensions.ObjectPool;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppObjectPool
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Long running and single thread operation which creates an instance of 
             * object for every iteration.
             * See results in below depicted image.
             */
            /*
            for (int i = 0; i <= 10000; i++)
            {
                MyClass mc = new MyClass();
                Console.WriteLine(mc.GetValue(i));
            }
            */            

            // Object pool implementation
            ObjectPool<MyClass> pool = new ObjectPool<MyClass>(() => new MyClass());

            /* Use thread safe - multi threaded Parallel.For to speed up the process
             * Pool.GetObject() first creates an instance of MyClass and then get its
             * value, finally Pool.PutObject() places back the instance to the pool.
            */
            Parallel.For(0, 10000, (i, loopState) =>
            {
                MyClass mc = pool.GetObject();

                Console.CursorLeft = 5;
                Console.WriteLine(mc.GetValue(i));

                pool.PutObject(mc);
            });

            Console.WriteLine("Press the Enter key to exit.");
            Console.ReadLine();

        }

        // Sample class which creates an array of integers and then stores Random integers
        // into it. GetValue() takes a long as a param and then return the specific value 
        // stored in that position of array.
        class MyClass
        {
            public int[] Nums { get; set; }
            public long GetValue(long i)
            {
                return Nums[i];
            }
            public MyClass()
            {
                Nums = new int[100000];
                Random rand = new Random();
                for (int i = 0; i < Nums.Length; i++)
                    Nums[i] = rand.Next();
            }
        }
    }
}
