using Array.Generic;
using Stack.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Array.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        private readonly Array<T> _Array = new Array<T>();
        public ArrayStack()
        {
            _Array = new Array<T>();
        }

        public ArrayStack(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Push(item);
            }
        }

        public int Count => _Array.Count;

        public IEnumerator<T> GetEnumerator()
        {
            return _Array.GetEnumerator();
        }

        public T Peek()
        {
            if (Count == 0)
            {
                return default(T);
            }
            return _Array.GetValue(_Array.Count - 1);
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new Exception("Empty stack.");
            }
            var result = _Array.Remove();
            return result;
        }

        public void Push(T item)
        {
            _Array.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
