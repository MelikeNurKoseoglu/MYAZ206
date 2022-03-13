using System;

namespace ValueAndReferenceTypes
{
    public class ReferenceType
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ReferenceType()
        {

        }
        public ReferenceType(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void SwapByValue(int x,int y)
        {
            // Değişiklik sadeec parantez içinde geçerli olur
            var temp = x;
            x = y;
            y = temp;
        }
        public void SwapByRef( ref int x, ref int y)
        {
            var temp = x;
            x = y;
            y = temp;
        }
        public void CheckOutKeyWordByRef( int veriable)
        {
            veriable = 100;
            return;
        }
        public void CheckOutKeyWordByVal(out int veriable)
        {
            veriable = 100;
            return;
        }

    }
}
