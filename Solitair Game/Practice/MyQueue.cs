using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class MyQueue<T>
    {
        public Node<T> front;
        public Node<T> back;
        public MyQueue()
            {
            front=back=null;
            }
        public void enqueue(T item)
        {
            Node<T> newnode=new Node<T>(item);
            if (Isempty())
            {
                front=back=newnode;
            }
            else
            {
                back.Next=newnode;
                back = newnode;
            }

        }
        public T Dequeue()
        {
            if (Isempty())
            {
                Console.WriteLine("Queue is empty");


            }
            T removedata=front.Data;
            front = front.Next;
            return removedata;
        }

        public bool Isempty()
        {
            return front==null;
        }
            public T getfront()
        {
            if (Isempty())
            {
                Console.WriteLine("Queue is empty"); 
            }
            return front.Data;
        }
    }
}
