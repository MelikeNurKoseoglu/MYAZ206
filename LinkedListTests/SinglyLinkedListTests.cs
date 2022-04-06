using SinglyLinkedList;
using SinglyLinkedListNode;
using System;
using Xunit;

namespace LinkedListTests
{
    public class SinglyLinkedListTests
    {
        private SinglyLinkedList<int> _list;
        public SinglyLinkedListTests()
        {
            // 8 -> 6
            _list = new SinglyLinkedList<int>(new int[] { 6, 8 });
        }
        [Fact]
        public void Count_Test()
        {
            // act
            int count = _list.Count;

            // Assert
            Assert.Equal(2, count);
        }
        [Theory]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(1)]
        [InlineData(9)]
        public void AddFirst_Test(int value)
        {
            // act
            _list.AddFirst(value);

            // Assert
            Assert.Equal(value, _list.Head.Value);//e�itli�in bir taraf� T di�er taraf� singleylinkedList bu y�zden _list.Head.Value olarak yazd�k
            Assert.Collection(_list,
                item => Assert.Equal(item, value),
                item => Assert.Equal(item, 8),
                item => Assert.Equal(item, 6));
        }

        [Fact]
        public void GetEnumerator_Test()
        {
            // Assert
            Assert.Collection(_list,
                item => Assert.Equal(item, 8),
                item => Assert.Equal(item, 6));
        }
        [Fact]
        public void AddLast_Test()
        {
            //act
            _list.AddLast(55);

            //Assert
            Assert.Collection(_list,
                item=>Assert.Equal(item,8),
                item => Assert.Equal(item, 6),
                item => Assert.Equal(item, 55)
                );

        }
        [Theory]
        [InlineData(60)]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(1)]
        [InlineData(9)]
        public void AddBefore_Test(int value)
        {
            //act
            _list.AddBefore(_list.Head.Next,value);

            //assert
            Assert.Collection(_list,
                item=>Assert.Equal(8,item),
                item => Assert.Equal(value, item),
                item => Assert.Equal(6, item)
                );
        }
        [Fact]
        public void AddBefore_ArgumentException()
        {
            // 8 [value] 6
            //act
            var node = new SinglyLinkedListNode<int>(55);

            //assert
            Assert.Throws<ArgumentException>(()=>_list.AddBefore(node,45));

        }
        [Theory]
        [InlineData(60)]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(1)]
        [InlineData(9)]
        public void AddAfter_Test(int value)
        {
            // 8 [value] 6
            //act
            _list.AddAfter(_list.Head,value);

            //assert
            Assert.Collection(_list,
                item=>Assert.Equal(8,item),
                item => Assert.Equal(value, item),
                item => Assert.Equal(6, item));
        }
        [Fact]
        public void AddAfter_ArgumentException()
        {
            // 8 [value] 6
            //act
            var node = new SinglyLinkedListNode<int>(55);

            //assert
            Assert.Throws<ArgumentException>(() => _list.AddAfter(node, 45));
        }
        [Fact]
        public void RemoveFirst_Test()
        {
            // 8  6
            //act
            _list.RemoveFirst();

            //assert
            Assert.Collection(_list,item=>Assert.Equal(6,item));
        }
        [Fact]
        public void RemoveFirst_Exception_Test()
        {
            // 8  6
            //act
            _list.RemoveFirst();
            _list.RemoveFirst();

            //assert
            Assert.Throws<Exception>(()=>_list.RemoveFirst());
        }
        [Fact]
        public void RemoveLast_Test()
        {
            // 8  6
            //act
            var result=_list.RemoveLast();

            //assert
            Assert.Collection(_list, 
                item => Assert.Equal(8,item));
            Assert.Equal(6, result);
        }

        [Theory]
        [InlineData(8)]
        public void Remove_Test(int value)
        {
            //10 8 6
            _list.AddFirst(10);

            //act
             _list.Remove(value);

            //assert
            Assert.Collection(_list,
                item => Assert.Equal(10,item),
                item=>Assert.Equal(6,item));
            
        }

    }
}
