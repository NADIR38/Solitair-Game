using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> queue=new MyQueue<int>();
            queue.enqueue(1);
            queue.enqueue(2);
            queue.enqueue(3);
            int remove = queue.Dequeue();
            int remove2 = queue.Dequeue();
            Console.WriteLine(remove);

        }
    }
}
