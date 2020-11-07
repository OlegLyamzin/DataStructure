using NUnit.Framework;
using DataStructure;
using System;

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
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}