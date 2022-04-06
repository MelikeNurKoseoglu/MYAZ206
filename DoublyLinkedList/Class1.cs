using DbNode;
using DoublyLinkedListEnumerator;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public DbNode<T> Head { get; private set; }
        public DbNode<T> Tail { get; private set; }
        private bool isHeadNull=>Head == null;

      
        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        public DoublyLinkedList(IEnumerable<T> collection):this()
        {
            foreach (var item in collection)
            {
                AddFirst(item);
            } 
        }
        public void AddFirst(T value)
        {
            var newNode=new DbNode<T>(value);

            if (isHeadNull)//head boş olma durumu
            {
                Head = newNode;
                Tail= newNode; 
                Count++;
                return;
            }
            //liste boi değil
            newNode.Next=Head;
            Head.Prev = newNode;
            Head= newNode;
            Count++;
            return;
        }
        public void AddLast(T value) 
        {
            var newNode = new DbNode<T>(value);

            if (isHeadNull)// liste boş ise
            {
                AddFirst(value);
                return;
            }

            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
            Count++;
            return;
        }
        public void AddBefore(DbNode<T> node, T value)
        {
            if (node == null || value is null)
                throw new ArgumentNullException();

            
            if (isHeadNull || node.Equals(Head))// liste boş veya Head öncesine ekleme
            {
                AddFirst(value);
                return;
            }

            var newNode = new DbNode<T>(value);
            var current = Head;
            var prev = current;

            while (current != null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = prev.Next;
                    newNode.Prev = prev;
                    prev.Next = newNode;
                    newNode.Next.Prev = newNode;
                    Count++;
                    return;
                }
                prev = current;
                current = current.Next;
            }
            throw new ArgumentException("There is no such a node in the list.");
        }


        public void AddAfter(DbNode<T> node, T value)
        {
            if (node == null)
                throw new ArgumentNullException();

            
            if (isHeadNull)// liste boşsa
            {
                AddFirst(value);
                return;
            }

            // diğer durumda
            var newNode = new DbNode<T>(value);
            var current = Head;
            while (current != null)
            {
                if (current.Equals(node))
                {
                    // eklenecek elemanın soransı null olmamalı ki
                    // araya eklensin. 
                    if (current.Next != null)
                    {
                        newNode.Next = current.Next;
                        current.Next = newNode;
                        newNode.Prev = current;
                        newNode.Next.Prev = newNode;
                        Count++;
                        return;
                    }
                    else
                    {
                        AddLast(value);
                        return;
                    }
                }
                current = current.Next;
            }
            throw new ArgumentException("There is no such a node in the list.");
        }

        public T RemoveFirst() // O(1)
        {
            if (isHeadNull)//liste boşsa
                throw new Exception(nameof(Head));

            var temp = Head;
            if (Count == 1)//liste tek elemanlı
            {
                Head = null;
                Count--;
                return temp.Value;
            }

            Head = Head.Next;
            Head.Prev = null;
            Count--;
            return temp.Value;
        }

        public T RemoveLast()
        {
            if (isHeadNull || Count == 0)
                throw new Exception();

            
            if (Count == 1)
            {
                var temp = Head;
                Head = null;
                Count--;
                return temp.Value;
            }
            else
            {
                var temp = Tail;
                Tail.Prev.Next = null;
                Tail = Tail.Prev;
                Count--;
                return temp.Value;
            }
        }

        
        public T Remove(T value) // O(n)
        {
            
            if (isHeadNull)// liste boş
                throw new Exception("The list is empty.");

           
            var current = Head;
            var prev = current;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    
                    if (current.Value.Equals(Head.Value))// ilk düğüm
                        return RemoveFirst();

                    
                    if (current.Value.Equals(Tail.Value))// son düğüm
                        return RemoveLast();

                     
                    var temp = current;
                    prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                    current = null;
                    Count--;
                    return temp.Value;
                }
                prev = current;
                current = current.Next;
            }
            throw new ArgumentException("There is no such a this node in the list.");
        }



        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<T> ToList() =>
            new List<T>(this);


    }
}
