using System;
using System.Collections.Generic;

namespace SolitaireGame.DataStructures
{
    public class MyQueue<T>
    {
        public Node<T> front;
        public Node<T> back;
        public int count;

        public MyQueue()
        {
            front = back = null;
            count = 0;
        }

        public MyQueue(IEnumerable<T> collection)
            : this() 
        {
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }

        public void Enqueue(T item)
        {
            Node<T> newnode = new Node<T>(item);
            if (IsEmpty())
            {
                front = back = newnode;
                count++;
            }
            else
            {
                back.Next = newnode;
                back = newnode;
                count++;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T removedata = front.Data;
            front = front.Next;
            count--;

            if (front == null)
            {
                back = null;
            }

            return removedata;
        }

        public bool IsEmpty()
        {
            return front == null;
        }

        public T GetFront()
        {
            if (IsEmpty())
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