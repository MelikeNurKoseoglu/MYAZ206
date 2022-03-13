using System;
using Xunit;

namespace ArrayTest
{
    public class ArrayTests
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
        public void IndexOfTest()
        {
            //Arrange
            var array = new DataStructures.Array.Array(4);
            array.SetValue(10,0);
            array.SetValue(20, 1);
            array.SetValue(30, 2);
            array.SetValue(40,3);
            
            //Act
            var result=array.IndexOf(10);
            var result2=array.IndexOf(15);

            //Assert
            Assert.Equal(result,0);
            Assert.NotEqual(result,1);
            

        }


    }
}
