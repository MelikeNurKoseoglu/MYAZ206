using SinglyLinkedListNode;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SinglyLinkedListEnumerator
{
    public class SinglyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private SinglyLinkedListNode<T> Head { get; set; }
        private SinglyLinkedListNode<T> Curr { get; set; }

        public SinglyLinkedListEnumerator(SinglyLinkedListNode<T> head)
        {
            Head = head;
            Curr = null;
        }
        public T Current => Curr.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Head = null;
        }

        public bool MoveNext()
        {
            if (Head is null)//boş bir liste ise
                return false;

            if (Curr == null)//liste içinde gezmeye başlanmadıysa
            {
                Curr = Head;
                return true;
            }

            if (Curr.Next != null)//her defasında bir eleman dönüyorsa liste sonuna gelinmedi
            {
                Curr = Curr.Next;
                return true;
            }

            return false;//eleman yoksa
        }

        public void Reset()
        {
            Curr = null;
            Head = null;
        }
    }
}
