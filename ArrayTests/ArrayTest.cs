using System;
using Xunit;

namespace ArrayTests
{
    public class ArrayTest
    {
        [Fact]
        public void ArraySetValueTest()
        {
            //Arrange
            var arr = new DataStructures.Array.Array();

            //Act
            arr.SetValue(10, 0);

            //Assert
            Assert.Equal(10, arr.GetValue(0));
        }
        [Theory]
        [InlineData(16)]
        [InlineData(32)]
        [InlineData(64)]
        [InlineData(128)]
        [InlineData(256)]
        public void CheckDefaultSizeFeature(int defaultSize)
        {
            //Arrange&act
            var arr = new DataStructures.Array.Array(defaultSize);

            //Assert
            Assert.Equal(defaultSize, arr.Length);
        }

        [Fact]
        public void CheckCloneableTest()
        {
            //Arrange
            var arr = new DataStructures.Array.Array(4);

            arr.SetValue(1, 0);
            arr.SetValue(2, 0);
            arr.SetValue(3, 0);
            arr.SetValue(4, 0);

            //Act
            var clonedArr = arr.Clone() as DataStructures.Array.Array;

            //Assert
            Assert.IsType<DataStructures.Array.Array>(clonedArr);

        }
        [Fact]
        public void Array_Clone_Test()
        {
            //Arrange
            var array=new DataStructures.Array.Array(1,2,3);
            //Act
            var clonedArray = array.Clone() as DataStructures.Array.Array;

            //Assert
            Assert.NotNull(clonedArray);
            Assert.Equal(array.Length, clonedArray.Length);


        }
        [Fact]
        public void Array_GetEnumerator_Test()
        {
            //Arrange
            var array = new DataStructures.Array.Array(10,20,30);

            //Act
            string s = "";
            foreach (var item in array)
            {
                s += item;
            }
            //Assert
            Assert.Equal("102030",s);

        }
        [Fact]
        public void Array_Custom_GetEnumerator_Test()
        {
            //Arrange
            var array = new DataStructures.Array.Array(10, 20, 30);

            //Act
            string s = "";
            foreach (var item in array)
            {
                s += item;
            }
            //Assert
            Assert.Equal("102030", s);

        }


        [Fact]
        public void IndexOfTest()
        {
            //Arrange
            var array = new DataStructures.Array.Array(4);
            array.SetValue(10, 0);
            array.SetValue(20, 1);
            array.SetValue(30, 2);
            array.SetValue(40, 3);

            //Act
            var result = array.IndexOf(10);
            var result2 = array.IndexOf(15);

            //Assert
            Assert.Equal(result, 0);
            Assert.NotEqual(result, 1);


        }

    }
}
