using NUnit.Framework;
using DataStructure;
using System;
using System.Runtime;

namespace DataStructureTests
{
    public class Tests
    {
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(0, new int[] { 0 }, 0)]
        [TestCase(5, new int[] { 1, 4, 5, 3, 7, 4 }, 4)]
        public void GetIndexatorTest(int index, int[] array, int expected)
        {
            ArrayList actualList = new ArrayList(array);
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
            ArrayList actualList = new ArrayList(array);
            int actual;

            Assert.Throws<IndexOutOfRangeException>(()=>actual = actualList[index]);
        }

        [TestCase(3, 10, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 10, 5 })]
        [TestCase(0, 1, new int[] { 0 }, new int[] { 1 })]
        [TestCase(5, -1, new int[] { 1, 43, 4, 5, 2, 1 }, new int[] { 1, 43, 4, 5, 2, -1 })]
        public void SetIndexatorTest(int index, int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);
            
            actual[index] = value;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1,0, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1,0, new int[] { 0 })]
        [TestCase(43,0, new int[] { 1, 4, 5, 3, 7, 4 })]
        [TestCase(0,0, new int[] { })]
        public void SetIndexatorNegativeTest(int index,int value, int[] array)
        {
            ArrayList actual = new ArrayList(array);
            
            Assert.Throws<IndexOutOfRangeException>(() => actual[index] = value);
        }

        [TestCase(6, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(0, new int[] { }, new int[] { 0 })]
        [TestCase(-4, new int[] { 1 }, new int[] { 1, -4 })]
        public void AddTest(int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 10, new int[] { }, new int[] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 })]
        [TestCase(0, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0, 0, 0, 0, 0 })]
        [TestCase(-4, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -4, -4, -4 })]
        public void AddFewElementsTest(int value, int quantity, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

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
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 10, new int[] { }, new int[] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 })]
        [TestCase(0, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 0, 0, 0, 0, 1, 2, 3, 4, 5 })]
        [TestCase(-4, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { -4, -4, -4, 1, 2, 3, 4, 5 })]
        public void AddFirstFewElementsTest(int value, int quantity, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

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
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.AddByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 10, 0, new int[] { }, new int[] { 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 })]
        [TestCase(0, 5, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 0, 0, 0, 0, 0, 4, 5 })]
        [TestCase(-4, 3, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -4, -4, -4, })]
        public void AddByIndexFewElementsTest(int value, int quantity, int index, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            for (int i = 0; i < quantity; i++)
            {
                actual.AddByIndex(value, index);
            }

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 6, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(0, -1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(0, 243, new int[] { 1, 2, 3, 4, 5 })]
        public void AddByIndexNegativeTest(int value, int index, int[] array)
        {
            ArrayList actual = new ArrayList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(value, index));

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 1, -4 }, new int[] { 1 })]
        public void DeleteEndTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteEnd();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2 })]
        [TestCase(3, new int[] { 0, 1, 2 }, new int[] { })]
        [TestCase(0, new int[] { 1, -4 }, new int[] { 1, -4 })]
        public void DeleteEndFewElementsTest(int quantity, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteEnd(quantity);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { })]
        [TestCase(4, new int[] { 1, 2, 3 })]
        [TestCase(-1, new int[] { 1, 2, 3 })]
        [TestCase(-7, new int[] { 1, 2, 3 })]
        public void DeleteEndNegativeTest(int quantity, int[] array)
        {
            ArrayList actual = new ArrayList(array);

            if (quantity >= 0)
            {
                Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteEnd(quantity));
            }
            else if (quantity < 0)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => actual.DeleteEnd(quantity));
            }
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { 1, -4 }, new int[] { -4 })]
        public void DeleteFirstTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteFirst();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5 })]
        [TestCase(3, new int[] { 0, 1, 2 }, new int[] { })]
        [TestCase(0, new int[] { 1, -4 }, new int[] { 1, -4 })]
        public void DeleteFirstFewElementsTest(int quantity, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteFirst(quantity);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { })]
        [TestCase(4, new int[] { 1, 2, 3 })]
        [TestCase(-1, new int[] { 1, 2, 3 })]
        [TestCase(-7, new int[] { 1, 2, 3 })]
        public void DeleteFirstNegativeTest(int quantity, int[] array)
        {
            ArrayList actual = new ArrayList(array);

            if (quantity >= 0)
            {
                Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteFirst(quantity));
            }
            else if (quantity < 0)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => actual.DeleteFirst(quantity));
            }
        }

        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(0, new int[] { 0 }, new int[] { })]
        [TestCase(3, new int[] { 1, -4, 3, 2, 1, 65 }, new int[] { 1, -4, 3, 1, 65 })]
        public void DeleteByIndexTest(int index, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0,3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5 })]
        [TestCase(4, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(0,0, new int[] { 0 }, new int[] { 0})]
        [TestCase(3, 2, new int[] { 1, -4, 3, 2, 1, 65 }, new int[] { 1, -4, 3, 65 })]
        public void DeleteByIndexFewElementsTest(int index, int quantity, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.DeleteByIndex(index, quantity);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, 1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-1, 1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(5, 5, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(0, 6, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(5, -5, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, 0, new int[] { 1 })]
        [TestCase(0, 0, new int[] {  })]
        public void DeleteByIndexNegativeTest(int index, int quantity, int[] array)
        {
            ArrayList actual = new ArrayList(array);            
            if (quantity >= 0)
            {

                Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteByIndex(index, quantity));
            }
            else if (quantity < 0)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => actual.DeleteByIndex(index, quantity));
            }
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { }, 0)]
        public void GetLengthTest(int[] array, int expected)
        {
            ArrayList actualArray = new ArrayList(array);
            int actual = actualArray.GetLength();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(0, new int[] { 0 }, 0)]
        [TestCase(5, new int[] { 1, 4, 5, 3, 7, 4 }, 4)]
        public void GetValueByIndexTest(int index, int[] array, int expected)
        {
            ArrayList actualArray = new ArrayList(array);

            int actual = actualArray.GetValueByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 0 })]
        [TestCase(43, new int[] { 1, 4, 5, 3, 7, 4 })]
        [TestCase(0, new int[] { })]
        public void GetValueByIndexNegativeTest(int index, int[] array)
        {
            ArrayList actualArray = new ArrayList(array);
            int actual;

            Assert.Throws<IndexOutOfRangeException>(() => actual = actualArray.GetValueByIndex(index));
           
        }

        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, 3)]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5, 5, 5, 5 }, 4)]
        [TestCase(1, new int[] { 1 }, 0)]
        public void GetIndexByValueTest(int value, int[] array, int expected)
        {
            ArrayList actualArray = new ArrayList(array);
            int actual = actualArray.GetIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(-1, new int[] { 1, 2, 3, 4, 5, 5, 5, 5 })]
        [TestCase(0, new int[] {  })]
        public void GetIndexByValueNegativeTest(int value, int[] array)
        {
            ArrayList actualArray = new ArrayList(array);
            Assert.Throws<ArgumentException>(() => actualArray.GetIndexByValue(value));
        }

        [TestCase(3, 10, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 10, 5 })]
        [TestCase(0, 1, new int[] { 0 }, new int[] { 1 })]
        [TestCase(5, -1, new int[] { 1, 43, 4, 5, 2, 1 }, new int[] { 1, 43, 4, 5, 2, -1 })]
        public void SetValueByIndexTest(int index, int value, int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.SetValueByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, 0, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, 0, new int[] { 0 })]
        [TestCase(43, 0, new int[] { 1, 4, 5, 3, 7, 4 })]
        [TestCase(0, 0, new int[] { })]
        public void SetValueByIndexNegativeTest(int index, int value, int[] array)
        {
            ArrayList actual = new ArrayList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.SetValueByIndex(index,value));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5,4,3,2,1 })]
        [TestCase(new int[] { 0 }, new int[] { 0})]
        [TestCase(new int[] {  }, new int[] {  })]
        [TestCase(new int[] { 1, 43, 4, 5, 2, 1 }, new int[] { 1,2,5,4,43,1 })]
        public void ReverseTest(int[] array, int[] expectedArray)
        {
            ArrayList actual = new ArrayList(array);
            ArrayList expected = new ArrayList(expectedArray);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 0 }, 0)]        
        [TestCase(new int[] { 1, 43, 4, 5, 2, 1 }, 43)]
        public void GetMaximumTest(int[] array, int expected)
        {
            ArrayList actualArray = new ArrayList(array);
            
            int actual = actualArray.GetMaximum();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMaximumNegativeTest(int[] array)
        {
            ArrayList actualArray = new ArrayList(array);

            Assert.Throws<Exception>(() => actualArray.GetMaximum());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 1, 43, 4, 5, 2, 1 }, 1)]
        public void GetMinimumTest(int[] array, int expected)
        {
            ArrayList actualArray = new ArrayList(array);

            int actual = actualArray.GetMinimum();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMinimumNegativeTest(int[] array)
        {
            ArrayList actualArray = new ArrayList(array);

            Assert.Throws<Exception>(() => actualArray.GetMaximum());
        }

        [TestCase("FirstActualMock", 4)]
        public void GetIndexOfMaximumTest(string nArrayListMock, int expected)
        {
            ArrayList actualArray = GetActualArrayListMock(nArrayListMock);
            int actual = actualArray.GetIndexOfMaximum();
            Assert.AreEqual(expected, actual);
        }

        [TestCase("FirstActualMock", 0)]
        public void GetIndexOfMinimumTest(string nArrayListMock, int expected)
        {
            ArrayList actualArray = GetActualArrayListMock(nArrayListMock);
            int actual = actualArray.GetIndexOfMinimum();
            Assert.AreEqual(expected, actual);
        }

        [TestCase("SecondActualMock", "SecondExpectedMockForSort")]
        public void SortTest(string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.Sort();
            Assert.AreEqual(expected, actual);
        }

        [TestCase("FirstActualMock", "FirstExpectedMockForSortInversion")]
        [TestCase("SecondActualMock", "SecondExpectedMockForSortInversion")]
        public void SortInversionTest(string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.SortInversion();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "FirstActualMock", "FirstExpectedMockForDeleteByValue")]
        [TestCase(23, "SecondActualMock", "SecondExpectedMockForDeleteByValue")]
        public void DeleteByValueTest(int value, string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.DeleteByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "FirstActualMock")]
        [TestCase(-1, "FirstActualMock")]
        public void DeleteByValueNegativeTest(int value, string nArrayListMock)
        {
            try
            {
                ArrayList actual = GetActualArrayListMock(nArrayListMock);
                actual.DeleteByValue(value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(3, "FirstActualMock", "FirstExpectedMockForDeleteByValueAll")]
        [TestCase(23, "SecondActualMock", "SecondExpectedMockForDeleteByValueAll")]
        public void DeleteByValueAllTest(int value, string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.DeleteByValueAll(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "FirstActualMock")]
        [TestCase(-1, "FirstActualMock")]
        public void DeleteByValueAllNegativeTest(int value, string nArrayListMock)
        {
            try
            {
                ArrayList actual = GetActualArrayListMock(nArrayListMock);
                actual.DeleteByValueAll(value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 6, 7, 8 }, "FirstActualMock", "FirstExpectedMockForAddMassive")]
        public void AddMassiveTest(int[] values, string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.Add(values);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 55, 43, 23 }, "FirstActualMock", "FirstExpectedMockForAddFirstMassive")]
        public void AddFirstMassiveTest(int[] values, string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.AddFirst(values);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 5, 7 }, 3, "FirstActualMock", "FirstExpectedMockForAddByIndexMassive")]
        public void AddByIndexMassiveTest(int[] values, int index, string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.AddByIndex(values, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, "FirstActualMock")]
        [TestCase(-1, "FirstActualMock")]
        public void AddByIndexMassiveNegativeTest(int index, string nArrayListMock)
        {
            try
            {
                ArrayList actual = GetActualArrayListMock(nArrayListMock);
                actual.AddByIndex(new int[] { 1, 2, 3 }, index);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }


        private ArrayList GetExpectedArrayListMock(string nExpectedMock)
        {
            int[] array;
            switch (nExpectedMock)
            {
                case "FirstExpectedMockForAdd":
                    array = new int[] { 1, 2, 3, 4, 5, 6 };
                    return new ArrayList(array);
                case "FirstExpectedMockForAddFirst":
                    array = new int[] { 6, 1, 2, 3, 4, 5 };
                    return new ArrayList(array);
                case "FirstExpectedMockForAddByIndex":
                    array = new int[] { 1, 2, 3, 6, 4, 5 };
                    return new ArrayList(array);
                case "FirstExpectedMockForDeleteEnd":
                    array = new int[] { 1, 2, 3, 4 };
                    return new ArrayList(array);
                case "FirstExpectedMockForDeleteFirst":
                    array = new int[] { 2, 3, 4, 5 };
                    return new ArrayList(array);
                case "FirstExpectedMockForDeleteByIndex":
                    array = new int[] { 1, 2, 3, 5 };
                    return new ArrayList(array);
                case "FirstExpectedMockForSetValueByIndex":
                    array = new int[] { 1, 2, 8, 4, 5 };
                    return new ArrayList(array);
                case "FirstExpectedMockForReverse":
                    array = new int[] { 5, 4, 3, 2, 1 };
                    return new ArrayList(array);
                case "SecondExpectedMockForSort":
                    array = new int[] { 2, 23, 23, 43, 54, 546, 657 };
                    return new ArrayList(array);
                case "FirstExpectedMockForSortInversion":
                    array = new int[] { 5, 4, 3, 2, 1 };
                    return new ArrayList(array);
                case "SecondExpectedMockForSortInversion":
                    array = new int[] { 657, 546, 54, 43, 23, 23, 2 };
                    return new ArrayList(array);
                case "FirstExpectedMockForDeleteByValue":
                    array = new int[] { 1, 2, 4, 5 };
                    return new ArrayList(array);
                case "SecondExpectedMockForDeleteByValue":
                    array = new int[] { 54, 43, 657, 546, 23, 2 };
                    return new ArrayList(array);
                case "FirstExpectedMockForDeleteByValueAll":
                    array = new int[] { 1, 2, 4, 5 };
                    return new ArrayList(array);
                case "SecondExpectedMockForDeleteByValueAll":
                    array = new int[] { 54, 43, 657, 546, 2 };
                    return new ArrayList(array);
                case "FirstExpectedMockForAddMassive":
                    array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                    return new ArrayList(array);
                case "FirstExpectedMockForAddFirstMassive":
                    array = new int[] { 55, 43, 23, 1, 2, 3, 4, 5 };
                    return new ArrayList(array);
                case "FirstExpectedMockForAddByIndexMassive":
                    array = new int[] { 1, 2, 3, 2, 5, 7, 4, 5 };
                    return new ArrayList(array);
                case "FirstExpectedMockForDeleteEndSeveral":
                    array = new int[] { 1, 2, 3 };
                    return new ArrayList(array);
                case "FirstExpectedMockForDeleteFirstSeveral":
                    array = new int[] { 3, 4, 5 };
                    return new ArrayList(array);
                case "FirstExpectedMockForDeleteByIndexSeveral":
                    array = new int[] { 1, 2, 5 };
                    return new ArrayList(array);
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private ArrayList GetActualArrayListMock(string nArrayListMock)
        {
            int[] array;
            switch (nArrayListMock)
            {
                case "FirstActualMock":
                    array = new int[] { 1, 2, 3, 4, 5 };
                    return new ArrayList(array);
                case "SecondActualMock":
                    array = new int[] { 54, 43, 23, 657, 546, 23, 2 };
                    return new ArrayList(array);
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}