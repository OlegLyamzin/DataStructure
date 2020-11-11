using DataStructure.LinkedLists;
using System;
using NUnit.Framework;
using System.Text;

namespace DataStructure.Tests
{
    public class LinkedListTest
    {
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(0, new int[] { 0 }, 0)]
        [TestCase(5, new int[] { 1, 4, 5, 3, 7, 4 }, 4)]
        public void GetIndexatorTest(int index, int[] array, int expected)
        {
            LinkedList actualList = new LinkedList(array);
            int actual;

            actual = actualList[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 0 })]
        [TestCase(43, new int[] { 1, 4, 5, 3, 7, 4 })]
        [TestCase(0, new int[] { })]
        public void GetIndexatorNegativeTest(int index, int[] array)
        {
            LinkedList actualList = new LinkedList(array);
            int actual;

            Assert.Throws<IndexOutOfRangeException>(() => actual = actualList[index]);
        }

        [TestCase(3, 10, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 10, 5 })]
        [TestCase(0, 1, new int[] { 0 }, new int[] { 1 })]
        [TestCase(5, -1, new int[] { 1, 43, 4, 5, 2, 1 }, new int[] { 1, 43, 4, 5, 2, -1 })]
        public void SetIndexatorTest(int index, int value, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual[index] = value;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, 0, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, 0, new int[] { 0 })]
        [TestCase(43, 0, new int[] { 1, 4, 5, 3, 7, 4 })]
        [TestCase(0, 0, new int[] { })]
        public void SetIndexatorNegativeTest(int index, int value, int[] array)
        {
            LinkedList actual = new LinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual[index] = value);
        }

        [TestCase(6, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(0, new int[] { }, new int[] { 0 })]
        [TestCase(-4, new int[] { 1 }, new int[] { 1, -4 })]
        public void AddTest(int value, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 10, new int[] { }, new int[] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 })]
        [TestCase(0, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0, 0, 0, 0, 0 })]
        [TestCase(-4, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -4, -4, -4 })]
        public void AddFewElementsTest(int value, int quantity, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            for (int i = 0; i < quantity; i++)
            {
                actual.Add(value);
            }

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 1, 2, 3, 4, 5 })]
        [TestCase(0, new int[] { }, new int[] { 0 })]
        [TestCase(-4, new int[] { 1 }, new int[] { -4, 1 })]
        public void AddFirstTest(int value, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 10, new int[] { }, new int[] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 })]
        [TestCase(0, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 0, 0, 0, 0, 1, 2, 3, 4, 5 })]
        [TestCase(-4, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { -4, -4, -4, 1, 2, 3, 4, 5 })]
        public void AddFirstFewElementsTest(int value, int quantity, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            for (int i = 0; i < quantity; i++)
            {
                actual.AddFirst(value);
            }

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 6, 4, 5 })]
        [TestCase(0, 0, new int[] { }, new int[] { 0 })]
        [TestCase(-4, 1, new int[] { 1 }, new int[] { 1, -4 })]
        public void AddByIndexTest(int value, int index, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 10, 0, new int[] { }, new int[] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 })]
        [TestCase(0, 5, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 0, 0, 0, 0, 0, 4, 5 })]
        [TestCase(-4, 3, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -4, -4, -4, })]
        public void AddByIndexFewElementsTest(int value, int quantity, int index, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            for (int i = 0; i < quantity; i++)
            {
                actual.AddByIndex(index, value);
            }

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 6, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(0, -1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(0, 243, new int[] { 1, 2, 3, 4, 5 })]
        public void AddByIndexNegativeTest(int value, int index, int[] array)
        {
            LinkedList actual = new LinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, value));

        }

    }
}
