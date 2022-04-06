using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CollectionListTest
{
    public class CollectionListTest
    {
        private List<int> leftList;
        private List<int> rigthList;
        public CollectionListTest()
        {
            leftList = new List<int> { 1, 2, 3, 4, 4, 5 };
            rigthList=new List<int> {4,5,6,6,7};
        }

        [Fact]
        public void Add_Test()
        {
            //arrange
            leftList.Add(10);

            //act
            Assert.Equal(7, leftList.Count);
        }

        [Fact]
        public void AddRange_Test()
        {
            //arrange
            leftList.AddRange(new int[] { 7,8});

            //act
            Assert.Collection(leftList,
                item=>Assert.Equal(item,leftList[0]),
                item => Assert.Equal(item, leftList[1]),
                item => Assert.Equal(item, leftList[2]),
                item => Assert.Equal(item, leftList[3]),
                item => Assert.Equal(item, leftList[4]),
                item => Assert.Equal(item, leftList[5]),
                item => Assert.Equal(item, leftList[6]),
                item => Assert.Equal(item, leftList[7])
                );
        }

        [Fact]
        public void InterSection_Test()
        {
            //Act
            var interSectionTest = leftList.Intersect(rigthList);

            //Assert
            Assert.Collection(interSectionTest,
                item=>Assert.Equal(item,4),
                item => Assert.Equal(item, 5));
        }
        [Fact]
        public void Union_Test()
        {
            //act
            var unionSet=leftList.Union(rigthList);

            //Assert
            Assert.Collection(unionSet,
                item => Assert.Equal(item, 1),
                item => Assert.Equal(item, 2),
                item => Assert.Equal(item, 3),
                item => Assert.Equal(item, 4),
                item => Assert.Equal(item, 5),
                item => Assert.Equal(item, 6),
                item => Assert.Equal(item, 7)
                );
        }

    }
}
