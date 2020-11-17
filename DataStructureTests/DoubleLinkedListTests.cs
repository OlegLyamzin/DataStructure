using System;
using DataStructure.DoubleLinkedLists;
using NUnit.Framework;

namespace DataStructure.Tests
{
    public class DoubleLinkedListTests
    {
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(0, new int[] { 0 }, 0)]
        [TestCase(5, new int[] { 1, 4, 5, 3, 7, 4 }, 4)]
        public void GetIndexatorTest(int index, int[] array, int expected)
        {
            DoubleLinkedList actualList = new DoubleLinkedList(array);
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
            DoubleLinkedList actualList = new DoubleLinkedList(array);
            int actual;

            Assert.Throws<IndexOutOfRangeException>(() => actual = actualList[index]);
        }

        [TestCase(3, 10, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 10, 5 })]
        [TestCase(0, 1, new int[] { 0 }, new int[] { 1 })]
        [TestCase(5, -1, new int[] { 1, 43, 4, 5, 2, 1 }, new int[] { 1, 43, 4, 5, 2, -1 })]
        public void SetIndexatorTest(int index, int value, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual[index] = value;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, 0, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, 0, new int[] { 0 })]
        [TestCase(43, 0, new int[] { 1, 4, 5, 3, 7, 4 })]
        [TestCase(0, 0, new int[] { })]
        public void SetIndexatorNegativeTest(int index, int value, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual[index] = value);
        }

        [TestCase(6, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(0, new int[] { }, new int[] { 0 })]
        [TestCase(-4, new int[] { 1 }, new int[] { 1, -4 })]
        public void AddTest(int value, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 10, new int[] { }, new int[] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 })]
        [TestCase(0, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0, 0, 0, 0, 0 })]
        [TestCase(-4, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -4, -4, -4 })]
        public void AddFewElementsTest(int value, int quantity, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

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
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 10, new int[] { }, new int[] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 })]
        [TestCase(0, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 0, 0, 0, 0, 1, 2, 3, 4, 5 })]
        [TestCase(-4, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { -4, -4, -4, 1, 2, 3, 4, 5 })]
        public void AddFirstFewElementsTest(int value, int quantity, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            for (int i = 0; i < quantity; i++)
            {
                actual.AddFirst(value);
            }

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 1, 2, 3, 6, 4, 5, 6, 7, 8, 9 })]
        [TestCase(6, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 6, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(6, 1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 1, 6, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(6, 7, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 6, 8, 9 })]
        [TestCase(6, 8, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 6, 9 })]
        [TestCase(6, 9, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 6 })]
        [TestCase(0, 0, new int[] { }, new int[] { 0 })]
        [TestCase(-4, 1, new int[] { 1 }, new int[] { 1, -4 })]
        public void AddByIndexTest(int value, int index, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 10, 0, new int[] { }, new int[] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 })]
        [TestCase(0, 5, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 0, 0, 0, 0, 0, 4, 5 })]
        [TestCase(-4, 3, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -4, -4, -4, })]
        public void AddByIndexFewElementsTest(int value, int quantity, int index, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

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
            DoubleLinkedList actual = new DoubleLinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, value));

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 1, -4 }, new int[] { 1 })]
        public void DeleteEndTest(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.DeleteEnd();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2 })]
        [TestCase(3, new int[] { 0, 1, 2 }, new int[] { })]
        [TestCase(1, new int[] { 1, -4 }, new int[] { 1 })]
        public void DeleteEndFewElementsTest(int quantity, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

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
            DoubleLinkedList actual = new DoubleLinkedList(array);

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
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.DeleteFirst();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(3, new int[] { 0, 1, 2 }, new int[] { })]
        [TestCase(1, new int[] { 1, -4 }, new int[] { -4 })]
        public void DeleteFirstFewElementsTest(int quantity, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

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
            DoubleLinkedList actual = new DoubleLinkedList(array);

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
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.DeleteByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5 })]
        [TestCase(2, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2 })]
        [TestCase(4, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(3, 2, new int[] { 1, -4, 3, 2, 1, 65 }, new int[] { 1, -4, 3, 65 })]
        public void DeleteByIndexFewElementsTest(int index, int quantity, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

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
        [TestCase(4, 2, new int[] { 1, 2, 3, 4, 5 }, "IndexOutOfRangeException")]
        [TestCase(0, 0, new int[] { 0 }, "ArgumentOutOfRangeException")]
        [TestCase(3, 0, new int[] { 1, 2, 3, 4, 5 }, "ArgumentOutOfRangeException")]
        [TestCase(0, -1, new int[] { 1, 2, 3, 4, 5 }, "ArgumentOutOfRangeException")]
        [TestCase(2, -5, new int[] { 1, 2, 3, 4, 5 }, "ArgumentOutOfRangeException")]
        public void DeleteByIndexNegativeTest(int index, int quantity, int[] array, string exception)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
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
            DoubleLinkedList actualArray = new DoubleLinkedList(array);
            int actual = actualArray.GetLength();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(0, new int[] { 0 }, 0)]
        [TestCase(5, new int[] { 1, 4, 5, 3, 7, 4 }, 4)]
        public void GetValueByIndexTest(int index, int[] array, int expected)
        {
            DoubleLinkedList actualArray = new DoubleLinkedList(array);

            int actual = actualArray.GetValueByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 0 })]
        [TestCase(43, new int[] { 1, 4, 5, 3, 7, 4 })]
        [TestCase(0, new int[] { })]
        public void GetValueByIndexNegativeTest(int index, int[] array)
        {
            DoubleLinkedList actualArray = new DoubleLinkedList(array);
            int actual;

            Assert.Throws<IndexOutOfRangeException>(() => actual = actualArray.GetValueByIndex(index));

        }

        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, 3)]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5, 5, 5, 5 }, 4)]
        [TestCase(1, new int[] { 1 }, 0)]
        public void GetIndexByValueTest(int value, int[] array, int expected)
        {
            DoubleLinkedList actualArray = new DoubleLinkedList(array);
            int actual = actualArray.GetIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(3, 10, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 10, 5 })]
        [TestCase(0, 1, new int[] { 0 }, new int[] { 1 })]
        [TestCase(5, -1, new int[] { 1, 43, 4, 5, 2, 1 }, new int[] { 1, 43, 4, 5, 2, -1 })]
        public void SetValueByIndexTest(int index, int value, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.SetValueByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, 0, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, 0, new int[] { 0 })]
        [TestCase(43, 0, new int[] { 1, 4, 5, 3, 7, 4 })]
        [TestCase(0, 0, new int[] { })]
        public void SetValueByIndexNegativeTest(int index, int value, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.SetValueByIndex(index, value));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 0, 1 }, new int[] { 1, 0 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 43, 4, 5, 2, 1 }, new int[] { 1, 2, 5, 4, 43, 1 })]
        public void ReverseTest(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 1, 43, 4, 5, 2, 1 }, 43)]
        public void GetMaximumTest(int[] array, int expected)
        {
            DoubleLinkedList DoubleLinkedList = new DoubleLinkedList(array);

            int actual = DoubleLinkedList.GetMaximum();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMaximumNegativeTest(int[] array)
        {
            DoubleLinkedList DoubleLinkedList = new DoubleLinkedList(array);

            Assert.Throws<InvalidOperationException>(() => DoubleLinkedList.GetMaximum());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 1, 43, 4, 5, 2, 1 }, 1)]
        public void GetMinimumTest(int[] array, int expected)
        {
            DoubleLinkedList DoubleLinkedList = new DoubleLinkedList(array);

            int actual = DoubleLinkedList.GetMinimum();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMinimumNegativeTest(int[] array)
        {
            DoubleLinkedList DoubleLinkedList = new DoubleLinkedList(array);

            Assert.Throws<InvalidOperationException>(() => DoubleLinkedList.GetMinimum());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 1, 43, 4, 5, 2, 1 }, 1)]
        public void GetIndexOfMaximumTest(int[] array, int expected)
        {
            DoubleLinkedList DoubleLinkedList = new DoubleLinkedList(array);

            int actual = DoubleLinkedList.GetIndexOfMaximum();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetIndexOfMaximumNegativeTest(int[] array)
        {
            DoubleLinkedList DoubleLinkedList = new DoubleLinkedList(array);

            Assert.Throws<InvalidOperationException>(() => DoubleLinkedList.GetIndexOfMaximum());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 2, 43, 4, 0, 2, 1 }, 3)]
        public void GetIndexOfMinimumTest(int[] array, int expected)
        {
            DoubleLinkedList DoubleLinkedList = new DoubleLinkedList(array);

            int actual = DoubleLinkedList.GetIndexOfMinimum();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetIndexOfMinimumNegativeTest(int[] array)
        {
            DoubleLinkedList DoubleLinkedList = new DoubleLinkedList(array);

            Assert.Throws<InvalidOperationException>(() => DoubleLinkedList.GetIndexOfMinimum());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 43, 4, 5, 2, 1 }, new int[] { 1, 1, 2, 4, 5, 43 })]
        [TestCase(new int[] { 6, 1, 43, 4, 5, 2, 1 }, new int[] { 1, 1, 2, 4, 5, 6, 43 })]
        [TestCase(new int[] { 465, 6, 1, 43, 4, 5, 2, 1 }, new int[] { 1, 1, 2, 4, 5, 6, 43, 465 })]
        public void SortTest(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.Sort();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortHugeListTest()
        {
            int[] array = new int[30];
            Random random = new Random();

            for (int i = 0; i < 30; i++)
            {
                array[i] = random.Next();
            }

            DoubleLinkedList actual = new DoubleLinkedList(array);

            Array.Sort(array);
            DoubleLinkedList expected = new DoubleLinkedList(array);

            actual.Sort();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 43, 4, 5, 2, 1 }, new int[] { 43, 5, 4, 2, 1, 1 })]
        [TestCase(new int[] { 6, 1, 43, 4, 5, 2, 1 }, new int[] { 43, 6, 5, 4, 2, 1, 1 })]
        [TestCase(new int[] { 465, 6, 1, 43, 4, 5, 2, 1 }, new int[] { 465, 43, 6, 5, 4, 2, 1, 1 })]
        public void SortInversionTest(int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.SortInversion();
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void SortInversionHugeListTest()
        {
            int[] array = new int[100];
            int length = array.Length;

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(1, 1000);
            }

            DoubleLinkedList actual = new DoubleLinkedList(array);

            Array.Sort(array);
            for (int i = 0; i < length / 2; i++)
            {
                int tmp = array[i];
                array[i] = array[length - 1 - i];
                array[length - 1 - i] = tmp;
            }

            DoubleLinkedList expected = new DoubleLinkedList(array);

            actual.SortInversion();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(0, new int[] { 0 }, new int[] { })]
        [TestCase(1, new int[] { 1, -4, 3, 2, 1, 65 }, new int[] { -4, 3, 2, 1, 65 })]
        [TestCase(3, new int[] { 1, -4, 3, 2, 1, 65 }, new int[] { 1, -4, 2, 1, 65 })]
        public void DeleteByValueTest(int value, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.DeleteByValue(value);

            Assert.AreEqual(expected, actual);
        }



        [TestCase(3, new int[] { 1, 2, 3, 4, 3, 5 }, new int[] { 1, 2, 4, 5 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(0, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { })]
        [TestCase(1, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { })]
        [TestCase(1, new int[] { 1, -4, 3, 2, 1, 65 }, new int[] { -4, 3, 2, 65 })]
        public void DeleteByValueAllTest(int value, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.DeleteByValueAll(value);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        [TestCase(new int[] { 6, 7, 8 }, new int[] { }, new int[] { 6, 7, 8 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        public void AddMassiveTest(int[] values, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.Add(values);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 6, 7, 8 }, new int[] { }, new int[] { 6, 7, 8 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        public void AddFirstMassiveTest(int[] values, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);

            actual.AddFirst(values);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 4, 5 })]
        [TestCase(2, new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 3, 4, 5 })]
        [TestCase(1, new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 2, 3, 4, 5 })]
        [TestCase(0, new int[] { 6, 7, 8 }, new int[] { }, new int[] { 6, 7, 8 })]
        [TestCase(2, new int[] { }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(5, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 1, 2, 3 })]
        public void AddByIndexMassiveTest(int index, int[] values, int[] array, int[] expectedArray)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);
            DoubleLinkedList expected = new DoubleLinkedList(expectedArray);
            actual.AddByIndex(index, values);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, new int[] { })]
        [TestCase(-1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(6, new int[] { 1, 2, 3, 4, 5 })]
        public void AddByIndexMassiveNegativeTest(int index, int[] array)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, new int[] { 1, 2, 3 }));
        }

        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        public void IncreaseAndDecreaseTest(int quantity)
        {
            DoubleLinkedList actual = new DoubleLinkedList();
            DoubleLinkedList expected = new DoubleLinkedList(new int[] { });

            for (int i = 0; i < quantity / 2; i++)
            {
                actual.Add(i);
                actual.AddFirst(i);
            }

            for (int i = 0; i < quantity / 2; i++)
            {
                actual.DeleteEnd();
                actual.DeleteFirst();
            }

            Assert.AreEqual(expected, actual);
        }
    }
}
