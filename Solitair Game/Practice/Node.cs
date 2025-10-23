using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }


    public class LinkedList<T>
    {
        private Node<T> head;
        private int count;

        public LinkedList()
        {
            head = null;
            count = 0;
        }

      public void Addfirst(T item)
        {
            Node<T> newnode=new Node<T>(item);
            newnode.Next=head;
            head=newnode;
            count++;
        }
        public void AddLast(T item)
        {
            Node<T> newnode=new Node<T>(item);
            if (head == null)
            {

                head = newnode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                    head = newnode;

                
            }
            count++;
        }
        public void RemoveFirst()
        {
            if(head == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            head = head.Next;
            count--;

         
        }
        public int Count
        {
            get { return count; }
        }
        public void Clear()
        {
            head = null;
            count = 0;
        }
       
        public override string ToString()
        {
            Node<T> current = head;
            string result = "";
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