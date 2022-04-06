using SinglyLinkedListEnumerator;
using SinglyLinkedListNode;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedListNode<T> Head { get; set; } //başlangıç düğümü için
        public int Count { get; set; }
        private bool isHeadNull => Head == null;

        public SinglyLinkedList()
        {
            Head = null;
            Count = 0;
        }

        public SinglyLinkedList(IEnumerable<T> collection) : this()//koleksiyon verdiğinde direk eleman ekleme
        {
            foreach (var item in collection)
            {
                AddFirst(item);
            }
        }

        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            if (isHeadNull)
            {
                Head = newNode;
                Count++;
                return;
            }
            newNode.Next = Head;
            Head = newNode;
            Count++;
            return;
        }
        public void AddLast(T value)
        {
            var newNode=new SinglyLinkedListNode<T>(value);

            if (isHeadNull)
            {
                Head=newNode;
                Count++;
                return;
            }

            var current = Head;
            while (current.Next!=null)
                current = current.Next;
            current.Next = newNode;
            Count++;
            return;

        }
        public void AddBefore(SinglyLinkedListNode<T> node, T value)
        {
            if (node==null)//bize verilen değer null mu
                throw new ArgumentNullException(nameof(node));
            if (isHeadNull || node.Equals(Head))//liste boş mu 
            {
                AddFirst(value);
                return;
            }
            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;
            var prev = current;
            while (current != null)
            {
                if (current.Equals(node))//verilen değer current ile eşleşiyor mu
                {
                    newNode.Next = prev.Next;
                    prev.Next = newNode;
                    Count++;
                    return;
                }
                prev = current;
                current = current.Next;
            }
            throw new ArgumentException("verilen düğüm bağlı listede yok");
            
        }
        public void AddAfter(SinglyLinkedListNode<T> node, T value)
        {
            if (node ==null)
                throw new ArgumentException(nameof(node));
            if (isHeadNull)//liste boş ise
            {
                AddFirst(value);
                return;
            }
            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;
            while (current!=null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    Count++;
                    return;
                }
                current=current.Next;

            }
            throw new ArgumentException("referens düğümü yok");
                
        }
        public T RemoveFirst() //method paremetresi olarak geri döndüğümüz için T kullanıldı
        {
            if (isHeadNull)
            {
                throw new Exception(nameof(Head));
            }
            
            var temp = Head;

            Head=Head.Next;
            Count--;

            return temp.Value;
        }
        public T RemoveLast()
        {
            if (isHeadNull || Count==0)//listede silinecek eleman yoksa
                throw new Exception(nameof(Head));

            if (Count==1)//listede tek eleman kaldıysa
            {
                var temp= Head;
                Head = null;
                Count--;
                return temp.Value;
            }
            else
            {
                var current = Head;
                var prev = current;
                while (current.Next!=null)// null oluncaya kadar ilerleme
                {
                    prev = current;
                    current=current.Next;
                }
                prev.Next = null;
                Count--;
                return current.Value;
            }
        }
        public T Remove(T value)
        {
            if (Count == 0 || isHeadNull)//silinecek eleman yoksak
                throw new Exception(nameof(value));
            if (Head.Value.Equals(value))//silmek istenilen head ise
                return RemoveFirst();

            var current = Head;
            var prev = current;
            while (current!=null)
            {
                if (current.Value.Equals(value))
                {
                    prev.Next = current.Next;
                    Count--;
                    return current.Value;
                }
            }
            throw new ArgumentException();
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);//nerde başladığını söyledik
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<T> ToList() => new List<T>(this);// liste elemanları tek tek oluşup listeye atılabilecek
    }
}
