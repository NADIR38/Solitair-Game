using System;
using System.Collections.Generic;

namespace SolitaireGame.DataStructures
{
    public class MyStack<T>
    {
        private Node<T> top { get; set; }
        private int count { get; set; }

        public MyStack()
        {
            top = null;
            count = 0;
        }

        public void Push(T item)
        {
            Node<T> temp = new Node<T>(item);
            temp.Next = top;
            top = temp;
            count++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            T item = top.Data;
            top = top.Next;
            count--;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            return top.Data;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public List<T> ToListReversed()
        {
            List<T> list = new List<T>();
            Node<T> current = top;

            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }

            // Since stack top is the first element, reverse to show bottom → top
            list.Reverse();
            return list;
        }

        public void Clear()
        {
            top = null;
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }
    }
}