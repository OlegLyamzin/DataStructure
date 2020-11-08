using NUnit.Framework;
using DataStructure;
using System;
using System.Runtime;

namespace DataStructureTests
{
    public class Tests
    {
        
        [TestCase(6,"FirstActualMock", "FirstExpectedMockForAdd")]
        public void AddTest(int value, string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "FirstActualMock", "FirstExpectedMockForAddFirst")]
        public void AddFirstTest(int value, string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.AddFirst(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6,3, "FirstActualMock", "FirstExpectedMockForAddByIndex")]
        public void AddByIndexTest(int value,int index, string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.AddByIndex(value,index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("FirstActualMock", "FirstExpectedMockForDeleteEnd")]
        public void DeleteEndTest( string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.DeleteEnd();
            Assert.AreEqual(expected, actual);
        }

        [TestCase("FirstActualMock", "FirstExpectedMockForDeleteFirst")]
        public void DeleteFirstTest(string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.DeleteFirst();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3,"FirstActualMock", "FirstExpectedMockForDeleteByIndex")]
        public void DeleteByIndexTest(int index, string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.DeleteByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, "FirstActualMock")]
        [TestCase(-1, "FirstActualMock")]
        public void DeleteByIndexNegativeTest(int index, string nArrayListMock)
        {
            try
            {
                ArrayList actual = GetActualArrayListMock(nArrayListMock);
                actual.DeleteByIndex(index);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(5, "FirstActualMock")]
        [TestCase(-1, "FirstActualMock")]
        public void AddByIndexNegativeTest(int index, string nArrayListMock)
        {
            try
            {
                ArrayList actual = GetActualArrayListMock(nArrayListMock);
                actual.AddByIndex(6,index);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase("FirstActualMock", 5)]
        public void GetLengthTest(string nArrayListMock, int expected)
        {
            ArrayList actualArray = GetActualArrayListMock(nArrayListMock);
            int actual = actualArray.GetLength();
            Assert.AreEqual(expected, actual);
        }

        [TestCase("FirstActualMock",3, 4)]
        public void GetValueByIndexTest(string nArrayListMock,int index, int expected)
        {
            ArrayList actualArray = GetActualArrayListMock(nArrayListMock);
            int actual = actualArray.GetValueByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("FirstActualMock", 5)]
        [TestCase("FirstActualMock", -1)]
        public void GetValueByIndexNegativeTest(string nArrayListMock, int index)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            try
            {
                
                actual.GetValueByIndex(index);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase("FirstActualMock", 3, 2)]
        public void GetIndexByValueTest(string nArrayListMock, int value, int expected)
        {
            ArrayList actualArray = GetActualArrayListMock(nArrayListMock);
            int actual = actualArray.GetIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("FirstActualMock", 6)]
        [TestCase("FirstActualMock", 0)]
        public void GetIndexByValueNegativeTest(string nArrayListMock, int value)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            try
            {

                actual.GetIndexByValue(value);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(8,2,"FirstActualMock", "FirstExpectedMockForSetValueByIndex")]
        public void SetValueByIndexTest(int value, int index, string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.SetValueByIndex(value,index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("FirstActualMock", 5)]
        [TestCase("FirstActualMock", -1)]
        public void SetValueByIndexNegativeTest(string nArrayListMock, int index)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            try
            {

                actual.SetValueByIndex(3,index);
            }
            catch
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase("FirstActualMock", "FirstExpectedMockForReverse")]
        public void ReverseTest(string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        [TestCase("FirstActualMock",5)]
        public void GetMaximumTest(string nArrayListMock, int expected)
        {
            ArrayList actualArray = GetActualArrayListMock(nArrayListMock);            
            int actual = actualArray.GetMaximum();
            Assert.AreEqual(expected, actual);
        }

        [TestCase("FirstActualMock", 1)]
        public void GetMinimumTest(string nArrayListMock, int expected)
        {
            ArrayList actualArray = GetActualArrayListMock(nArrayListMock);
            int actual = actualArray.GetMinimum();
            Assert.AreEqual(expected, actual);
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

        [TestCase(new int[] { 6,7,8}, "FirstActualMock", "FirstExpectedMockForAddMassive")]
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

        [TestCase(2,"FirstActualMock", "FirstExpectedMockForDeleteEndSeveral")]
        public void DeleteEndSeveralTest(int quantity, string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.DeleteEnd(quantity);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2,"FirstActualMock", "FirstExpectedMockForDeleteFirstSeveral")]
        public void DeleteFirstSeveralTest(int quantity,string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.DeleteFirst(quantity);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2,2, "FirstActualMock", "FirstExpectedMockForDeleteByIndexSeveral")]
        public void DeleteByIndexSeveralTest(int index,int quantity, string nArrayListMock, string nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.DeleteByIndex(index,quantity);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5,1, "FirstActualMock")]
        [TestCase(-1,1, "FirstActualMock")]
        [TestCase(4, 3, "FirstActualMock")]
        [TestCase(3, 3, "FirstActualMock")]
        public void DeleteByIndexSveralNegativeTest(int index,int quantity, string nArrayListMock)
        {
            try
            {
                ArrayList actual = GetActualArrayListMock(nArrayListMock);
                actual.DeleteByIndex(index,quantity);
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
                    array = new int[] { 6, 1, 2, 3, 4, 5};
                    return new ArrayList(array);
                case "FirstExpectedMockForAddByIndex":
                    array = new int[] {1, 2, 3, 6, 4, 5 };
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
                    array = new int[] { 1, 2, 8,4, 5 };
                    return new ArrayList(array);
                case "FirstExpectedMockForReverse":
                    array = new int[] { 5,4,3,2,1 };
                    return new ArrayList(array);
                case "SecondExpectedMockForSort":
                    array = new int[] { 2,23,23,43,54,546,657 };
                    return new ArrayList(array);
                case "FirstExpectedMockForSortInversion":
                    array = new int[] { 5, 4, 3, 2, 1 };
                    return new ArrayList(array);
                case "SecondExpectedMockForSortInversion":
                    array = new int[] { 657,546,54,43,23,23,2};
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
                    array = new int[] { 1, 2, 3, 4, 5,6,7,8 };
                    return new ArrayList(array);
                case "FirstExpectedMockForAddFirstMassive":
                    array = new int[] { 55,43,23,1, 2, 3, 4, 5 };
                    return new ArrayList(array);
                case "FirstExpectedMockForAddByIndexMassive":
                    array = new int[] { 1, 2, 3,2,5,7, 4, 5 };
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
                    array = new int[] { 54,43,23,657,546,23,2};
                    return new ArrayList(array);
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}