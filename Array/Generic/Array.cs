using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array.Generic
{
    public class Array<T> : ICloneable, IEnumerable<T>
    {
        private int position;
        public int Count => position;
        private T[] _innerArray { get; set; }
        public int Length => _innerArray.Length;

        public Array(int defaultSize = 2)
        {
            _innerArray = new T[defaultSize];
        }
        
        public Array(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        public object Clone()
        {
            return MemberwiseClone();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ArrayEnumerator<T>(_innerArray);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public void Add(T value)
        {
            if (position == Length)
            {
                DoubleArray();
            }
            if (position < Length)
            {
                _innerArray[position] = value;
                //SetValue(value,position);
                position++;
                return;
            }
            throw new Exception();
        }

        private void DoubleArray()
        {
            try
            {
                var temp = new T[_innerArray.Length * 2];
                System.Array.Copy(_innerArray, temp, _innerArray.Length);
                _innerArray = temp;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public T Remove()
        {
            if (position >= 0)
            {
                var temp = _innerArray[position - 1];
                position--;
                if (position == _innerArray.Length / 4)
                {
                    HalfArray();
                }
                return temp;
            }
            throw new Exception();
        }

        private void HalfArray()
        {
            try
            {
                var temp = new T[_innerArray.Length / 2];
                System.Array.Copy(_innerArray, temp, _innerArray.Length / 2);
                _innerArray = temp;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void SetValue(T value, int index)
        {
            if (!(index >= 0 && index < _innerArray.Length))
                throw new ArgumentOutOfRangeException();

            if (value == null)
                throw new ArgumentNullException();

            _innerArray[index] = value;
        }

        public T GetValue(int index)
        {
            if (!(index >= 0 && index < _innerArray.Length))
                throw new ArgumentOutOfRangeException();
            return _innerArray[index];
        }
        public int IndexOf(T value)
        {
            for (int i = 0; i < _innerArray.Length; i++)
            {
                if (value.Equals(_innerArray[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public class ArrayEnumerator<T> : IEnumerator<T>
        {
            private T[] _array;
            private int index;
            public ArrayEnumerator(T[] array)
            {
                _array = array;
                index = -1;

            }
            public T Current =>_array[index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                _array=null;
            }

            public bool MoveNext()
            {
                if (index<_array.Length-1)
                {
                    index++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
