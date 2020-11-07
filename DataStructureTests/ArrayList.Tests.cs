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