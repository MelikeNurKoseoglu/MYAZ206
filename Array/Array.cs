using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Array
{
    public class Array : ICloneable,IEnumerable
    {
        protected Object[] innerArr { get; set; }
        public int Length => innerArr.Length;


        public Array(int defaultSize = 16)
        {
            innerArr = new Object[defaultSize];
        }
        public Array(params Object[] sourceArrays):this(sourceArrays.Length)
        {
            System.Array.Copy(sourceArrays,innerArr,sourceArrays.Length);
        }

        public void SetValue(Object value, int index)
        {
            if (!(index >= 0 && index < innerArr.Length))
                throw new ArgumentOutOfRangeException();

            if (value == null)
                throw new ArgumentNullException();

            innerArr[index] = value;
            return;

        }

        public Object GetValue(int index)
        {
            if (!(index >= 0 && index < innerArr.Length))
                throw new ArgumentOutOfRangeException();

            return innerArr[index];
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        
        public IEnumerator GetEnumerator()
        {
            //return innerArr.GetEnumerator(); 
            return new CustomArrayEnumerator(innerArr);
        }
        
        public int IndexOf(Object value)
        {
            for (int i = 0; i < innerArr.Length; i++)
            {
                if (value.Equals(innerArr[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}













