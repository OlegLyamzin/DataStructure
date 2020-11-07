using NUnit.Framework;
using DataStructure;
using System;

namespace DataStructureTests
{
    public class Tests
    {
        
        [TestCase(6,1,1)]
        public void AddTest(int value, int nArrayListMock, int nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6,1,2)]
        public void AddFirstTest(int value, int nArrayListMock, int nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.AddFirst(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6,3,1,3)]
        public void AddByIndexTest(int value,int index, int nArrayListMock, int nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.AddByIndex(value,index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 4)]
        public void DeleteEndTest( int nArrayListMock, int nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.DeleteEnd();
            Assert.AreEqual(expected, actual);
        }

        private ArrayList GetExpectedArrayListMock(int nExpectedMock)
        {
            int[] array;
            switch (nExpectedMock)
            {
                case 1:
                    array = new int[] { 1, 2, 3, 4, 5, 6 };
                    return new ArrayList(array);
                case 2:
                    array = new int[] { 6, 1, 2, 3, 4, 5};
                    return new ArrayList(array);
                case 3:
                    array = new int[] {1, 2, 3, 6, 4, 5 };
                    return new ArrayList(array);
                case 4:
                    array = new int[] { 1, 2, 3, 4 };
                    return new ArrayList(array);
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private ArrayList GetActualArrayListMock(int nArrayListMock)
        {
            int[] array;
            switch (nArrayListMock)
            {
                case 1:
                    array = new int[] { 1, 2, 3, 4, 5 };
                    return new ArrayList(array);                    
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}