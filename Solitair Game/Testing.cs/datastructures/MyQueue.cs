using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireGame.DataStructures
{
    public  class MyQueue<T>
    {
        public Node<T> front;
        public Node<T> back;
        public int count;
        public MyQueue()
            {
            front=back=null;
            count=0;
            }
        public MyQueue(IEnumerable<T> collection)
          : this() // call default constructor
        {
            foreach (var item in collection)
            {
                enqueue(item);
            }
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
                count++;
            }

        }
        public T Dequeue()
        {
            if (Isempty())
            {
                throw new InvalidOperationException("Queue is empty");

            }
            T removedata=front.Data;
            front = front.Next;
            count--;
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
                throw new InvalidOperationException("Queue is empty");
                
               
            }
            return front.Data;
        }
        public int Count
        {
            get { return count; }
        }
    }
}
