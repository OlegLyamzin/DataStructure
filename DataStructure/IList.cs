using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    interface IList
    {
        public int Length { get; }
        public int this[int index] { get; set; }
        public void Add(int value);
        public void Add(int[] values);
        public void AddFirst(int value);
        public void AddFirst(int[] values);
        public void AddByIndex(int index, int value);
        public void AddByIndex(int index, int[] values);
        public void DeleteEnd(int quantity = 1);
        public void DeleteFirst(int quantity = 1);
        public void DeleteByIndex(int index, int quantity = 1);
        public int GetLength();
        public int GetValueByIndex(int index);
        public int GetIndexByValue(int value);
        public void SetValueByIndex(int index, int value);
        public void Reverse();
        public int GetMaximum();
        public int GetMinimum();
        public int GetIndexOfMinimum();
        public int GetIndexOfMaximum();
        public void Sort();
        public void SortInversion();
        public void DeleteByValue(int value);
        public void DeleteByValueAll(int value);
    }
}
