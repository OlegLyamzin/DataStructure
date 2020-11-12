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

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 1, -4 }, new int[] { 1 })]
        public void DeleteEndTest(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteEnd();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2 })]
        [TestCase(3, new int[] { 0, 1, 2 }, new int[] { })]
        [TestCase(1, new int[] { 1, -4 }, new int[] { 1})]
        public void DeleteEndFewElementsTest(int quantity, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteEnd(quantity);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { }, "IndexOutOfRangeException")]
        [TestCase(4, new int[] { 1, 2, 3 }, "IndexOutOfRangeException")]
        [TestCase(-1, new int[] { 1, 2, 3 }, "ArgumentOutOfRangeException")]
        [TestCase(-7, new int[] { 1, 2, 3 }, "ArgumentOutOfRangeException")]
        [TestCase(0, new int[] { 1, 2, 3 }, "ArgumentOutOfRangeException")]
        public void DeleteEndNegativeTest(int quantity, int[] array, string exception)
        {
            LinkedList actual = new LinkedList(array);

            switch (exception)
            {
                case "ArgumentOutOfRangeException":
                    Assert.Throws<ArgumentOutOfRangeException>(() => actual.DeleteEnd(quantity));
                    break;
                case "IndexOutOfRangeException":
                    Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteEnd(quantity));
                    break;
            }           
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 1, -4 }, new int[] { -4 })]
        public void DeleteFirstTest(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteFirst();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5 })]
        [TestCase(3, new int[] { 0, 1, 2 }, new int[] { })]
        [TestCase(1, new int[] { 1, -4 }, new int[] { -4 })]
        public void DeleteFirstFewElementsTest(int quantity, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteFirst(quantity);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { }, "IndexOutOfRangeException")]
        [TestCase(4, new int[] { 1, 2, 3 }, "IndexOutOfRangeException")]
        [TestCase(-1, new int[] { 1, 2, 3 }, "ArgumentOutOfRangeException")]
        [TestCase(-7, new int[] { 1, 2, 3 }, "ArgumentOutOfRangeException")]
        [TestCase(0, new int[] { 1, 2, 3 }, "ArgumentOutOfRangeException")]
        public void DeleteFirstNegativeTest(int quantity, int[] array, string exception)
        {
            LinkedList actual = new LinkedList(array);

            switch (exception)
            {
                case "ArgumentOutOfRangeException":
                    Assert.Throws<ArgumentOutOfRangeException>(() => actual.DeleteFirst(quantity));
                    break;
                case "IndexOutOfRangeException":
                    Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteFirst(quantity));
                    break;
            }
        }

        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(0, new int[] { 0 }, new int[] { })]
        [TestCase(3, new int[] { 1, -4, 3, 2, 1, 65 }, new int[] { 1, -4, 3, 1, 65 })]
        public void DeleteByIndexTest(int index, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5 })]
        [TestCase(4, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(3, 2, new int[] { 1, -4, 3, 2, 1, 65 }, new int[] { 1, -4, 3, 65 })]
        public void DeleteByIndexFewElementsTest(int index, int quantity, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteByIndex(index, quantity);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, 1, new int[] { 1, 2, 3, 4, 5 }, "IndexOutOfRangeException")]
        [TestCase(-1, 1, new int[] { 1, 2, 3, 4, 5 }, "IndexOutOfRangeException")]
        [TestCase(5, 5, new int[] { 1, 2, 3, 4, 5 }, "IndexOutOfRangeException")]
        [TestCase(0, 6, new int[] { 1, 2, 3, 4, 5 }, "IndexOutOfRangeException")]
        [TestCase(5, -5, new int[] { 1, 2, 3, 4, 5 }, "IndexOutOfRangeException")]
        [TestCase(1, 0, new int[] { 1 }, "IndexOutOfRangeException")]
        [TestCase(0, 0, new int[] { }, "IndexOutOfRangeException")]
        [TestCase(0, 0, new int[] { 0 }, "ArgumentOutOfRangeException")]
        [TestCase(3, 0, new int[] { 1, 2, 3, 4, 5 }, "ArgumentOutOfRangeException")]
        [TestCase(0, -1, new int[] { 1, 2, 3, 4, 5 }, "ArgumentOutOfRangeException")]
        [TestCase(2, -5, new int[] { 1, 2, 3, 4, 5 }, "ArgumentOutOfRangeException")]
        public void DeleteByIndexNegativeTest(int index, int quantity, int[] array, string exception)
        {
            LinkedList actual = new LinkedList(array);
            switch (exception)
            {
                case "IndexOutOfRangeException":
                    Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteByIndex(index, quantity));
                    break;
                case "ArgumentOutOfRangeException":
                    Assert.Throws<ArgumentOutOfRangeException>(() => actual.DeleteByIndex(index, quantity));
                    break;
            }            
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { }, 0)]
        public void GetLengthTest(int[] array, int expected)
        {
            LinkedList actualArray = new LinkedList(array);
            int actual = actualArray.GetLength();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(0, new int[] { 0 }, 0)]
        [TestCase(5, new int[] { 1, 4, 5, 3, 7, 4 }, 4)]
        public void GetValueByIndexTest(int index, int[] array, int expected)
        {
            LinkedList actualArray = new LinkedList(array);

            int actual = actualArray.GetValueByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 0 })]
        [TestCase(43, new int[] { 1, 4, 5, 3, 7, 4 })]
        [TestCase(0, new int[] { })]
        public void GetValueByIndexNegativeTest(int index, int[] array)
        {
            LinkedList actualArray = new LinkedList(array);
            int actual;

            Assert.Throws<IndexOutOfRangeException>(() => actual = actualArray.GetValueByIndex(index));

        }

        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, 3)]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5, 5, 5, 5 }, 4)]
        [TestCase(1, new int[] { 1 }, 0)]
        public void GetIndexByValueTest(int value, int[] array, int expected)
        {
            LinkedList actualArray = new LinkedList(array);
            int actual = actualArray.GetIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-1, new int[] { 1, 2, 3, 4, 5, 5, 5, 5 })]
        [TestCase(0, new int[] { })]
        public void GetIndexByValueNegativeTest(int value, int[] array)
        {
            LinkedList actualArray = new LinkedList(array);
            Assert.Throws<ArgumentException>(() => actualArray.GetIndexByValue(value));
        }

        [TestCase(3, 10, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 10, 5 })]
        [TestCase(0, 1, new int[] { 0 }, new int[] { 1 })]
        [TestCase(5, -1, new int[] { 1, 43, 4, 5, 2, 1 }, new int[] { 1, 43, 4, 5, 2, -1 })]
        public void SetValueByIndexTest(int index, int value, int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.SetValueByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, 0, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, 0, new int[] { 0 })]
        [TestCase(43, 0, new int[] { 1, 4, 5, 3, 7, 4 })]
        [TestCase(0, 0, new int[] { })]
        public void SetValueByIndexNegativeTest(int index, int value, int[] array)
        {
            LinkedList actual = new LinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.SetValueByIndex(index, value));
        }
    }
}
