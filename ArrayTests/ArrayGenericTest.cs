using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Array.Generic;
using DataStructures.Array;
using Xunit;

namespace ArrayTests
{
    public class ArrayGenericTest
    {
        private Array<char> _array;
        public ArrayGenericTest()
        {
            _array = new Array<char>(new List<char> {'s','a','m','u'});

        }

        [Theory]
        [InlineData(16)]
        [InlineData(32)]
        [InlineData(64)]
        [InlineData(128)]
        [InlineData(256)]
        public void Default_Test(int defaultSize)
        {
            //act
            var arr=new Array<char>(defaultSize);

            //Assert
            Assert.Equal(arr.Length, defaultSize);
        }
        [Fact]
        public void GetValue_Test()
        {
            //Act
            var c=_array.GetValue(0);

            //Assert
            Assert.Equal('s',c);
            Assert.IsType<char>(c);
            Assert.True(c is char);
            Assert.IsType(typeof(char),c);
        }
        [Fact]
        public void SetValue_Test()
        {
            //Act
            _array.SetValue('S',0);

            //Assert
            Assert.Equal('S', _array.GetValue(0));
        }
    }
}
