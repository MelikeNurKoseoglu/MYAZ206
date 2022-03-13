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
        private T[] _innerArray { get; set; }
        public int Length => _innerArray.Length;

        public Array(int defaultSize = 15)
        {
            _innerArray = new T[defaultSize];
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in this._innerArray)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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
    }
}
