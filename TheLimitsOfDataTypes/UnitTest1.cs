using System;
using Xunit;

namespace TheLimitsOfDataTypes
{
    public class UnitTest1
    {
        [Fact]
        public void Byte_Data_Type_MinAndMaxValue_Test()
        {
            //Arrange
            byte minValue;
            byte maxValue;

            //Act
            minValue = 0;
            maxValue = 255;

            //Assert
            Assert.Equal(minValue, byte.MinValue);

            Assert.Equal(maxValue, byte.MaxValue);

        }
    }
}
