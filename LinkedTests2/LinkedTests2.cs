using NUnit.Framework;
using ArrayList;

namespace LinkedTests2
{
    public class LinkedTests2
    {
        
        
            private LinkedList _linkedlist;

        [SetUp]
        public void Setup()
        {
            _linkedlist = new LinkedList();
        }

        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { }, 0)]
        public void GetLengthTest(int[] array, int exception)
        {
            //arrange           
            LinkedList temp = new LinkedList(array);
            //act            
            int actual = temp.GetLength();
            //assert
            Assert.AreEqual(exception, actual);
        }
        [TestCase(new int[] { 9, 9, 2, 3 }, new int[] { 1, 2, 3 }, 9)]
        [TestCase(new int[] { 0 }, new int[] { }, 0)]
        public void AddFirstTest(int[] array, int[] array2, int value)
        {
            //arrange
            LinkedList temp2 = new LinkedList(array);
            LinkedList temp = new LinkedList(array2);
            //act
            temp.AddFirst(value);
            int[] exception = temp2.ToArray();
            int[] actual = temp.ToArray();
            //assert
            Assert.AreEqual(exception, actual);
        }
       }
}