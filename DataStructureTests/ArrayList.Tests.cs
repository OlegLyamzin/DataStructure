using NUnit.Framework;
using DataStructure;
using System;

namespace DataStructureTests
{
    public class Tests
    {
        
        [TestCase(1,1)]
        public void AddTest(int nArrayListMock, int nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.Add(6);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1,2)]
        public void AddFirstTest(int nArrayListMock, int nExpectedMock)
        {
            ArrayList actual = GetActualArrayListMock(nArrayListMock);
            ArrayList expected = GetExpectedArrayListMock(nExpectedMock);
            actual.AddFirst(6);
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
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private ArrayList GetActualArrayListMock(int nArrayListMock)
        {
            switch (nArrayListMock)
            {
                case 1:
                    int[] array = new int[] { 1, 2, 3, 4, 5 };
                    return new ArrayList(array);                    
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}