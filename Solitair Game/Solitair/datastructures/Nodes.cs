using System;
using System.Collections.Generic;

namespace SolitaireGame.DataStructures
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Next;

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class MyLinkedList<T>
    {
        public Node<T> Head;
        private int count;

        public MyLinkedList()
        {
            Head = null;
            count = 0;
        }

        // Add at start
        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = Head;
            Head = newNode;
            count++;
        }

        // Add at end
        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node<T> current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            count++;
        }

        // Remove first item
        public void RemoveFirst()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("List is empty");
            }

            Head = Head.Next;
            count--;
        }

        // Remove a specific item
        public bool Remove(T item)
        {
            if (Head == null)
                return false;

            if (EqualityComparer<T>.Default.Equals(Head.Data, item))
            {
                Head = Head.Next;
                count--;
                return true;
            }

            Node<T> current = Head;
            while (current.Next != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Next.Data, item))
                {
                    current.Next = current.Next.Next;
                    count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        // Get first node
        public Node<T> GetHead()
        {
            return Head;
        }

        // Get last node
        public Node<T> GetLast()
        {
            if (Head == null)
                return null;

            Node<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current;
        }

        // Convert to normal list
        public List<T> ToList()
        {
            List<T> list = new List<T>();
            Node<T> current = Head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
            return list;
        }

        // Clear all nodes
        public void Clear()
        {
            Head = null;
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public override string ToString()
        {
            string result = "";
            Node<T> current = Head;
            while (current != null)
            {
                result += current.Data + " -> ";
                current = current.Next;
            }
            result += "null";
            return result;
        }
    }
}
