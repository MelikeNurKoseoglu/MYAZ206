using System;
using System.Collections;
using System.Linq;

namespace DataStructures.Array
{
    public class ArrayList : DataStructures.Array.Array,IEnumerable
    {
        private int position;
        public int Count => position;

        public object Current => throw new NotImplementedException();

        public ArrayList(int defaultSize=2):base(defaultSize)
        {
            position = 0;
        }
        public ArrayList(IEnumerable collection):this()
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        public void Add(object value)
        {
            if (position==Length)
            {
                DoubleArray();
            }
            if (position<Length)
            {
                innerArr[position] = value;
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
                var temp = new Object[innerArr.Length*2];
                System.Array.Copy(innerArr, temp, innerArr.Length);
                innerArr = temp;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Object Remove()
        {
            if (position >= 0)
            {
                var temp = innerArr[position - 1];
                position--;
                if (position==innerArr.Length/ 4)
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
                var temp = new Object[innerArr.Length / 2];
                System.Array.Copy(innerArr,temp,innerArr.Length/2);
                innerArr=temp;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        new public IEnumerator GetEnumerator()
        {
            return innerArr.Take(position).GetEnumerator();
        }

        
    }
}













