using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.DoubleLinkedLists
{
    public class DoubleLinkedList : IList
    {

        public int Length { get; set; }

        private Node _root;
        private Node _tale;

        public DoubleLinkedList(int[] array)
        {
            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;

                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp.Next.Prev = tmp;
                    tmp = tmp.Next;
                }
                _tale = tmp;
                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
            }
        }

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tale = null;
        }
        public int this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(int value)
        {
            if (Length > 0)
            {
                Node tmp = _tale;                                
                tmp.Next = new Node(value);
                tmp.Next.Prev = tmp;
                _tale = tmp.Next;
                Length++;
            }
            else
            {
                _root = new Node(value);
                _tale = _root;
                Length++;
            }
        }

        public void Add(int[] values)
        {
            throw new NotImplementedException();
        }

        public void AddByIndex(int index, int value)
        {
            throw new NotImplementedException();
        }

        public void AddByIndex(int index, int[] values)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(int value)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(int[] values)
        {
            throw new NotImplementedException();
        }

        public void DeleteByIndex(int index, int quantity = 1)
        {
            throw new NotImplementedException();
        }

        public void DeleteByValue(int value)
        {
            throw new NotImplementedException();
        }

        public void DeleteByValueAll(int value)
        {
            throw new NotImplementedException();
        }

        public void DeleteEnd(int quantity = 1)
        {
            throw new NotImplementedException();
        }

        public void DeleteFirst(int quantity = 1)
        {
            throw new NotImplementedException();
        }

        public int GetIndexByValue(int value)
        {
            throw new NotImplementedException();
        }

        public int GetIndexOfMaximum()
        {
            throw new NotImplementedException();
        }

        public int GetIndexOfMinimum()
        {
            throw new NotImplementedException();
        }

        public int GetLength()
        {
            throw new NotImplementedException();
        }

        public int GetMaximum()
        {
            throw new NotImplementedException();
        }

        public int GetMinimum()
        {
            throw new NotImplementedException();
        }

        public int GetValueByIndex(int index)
        {
            throw new NotImplementedException();
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }

        public void SetValueByIndex(int index, int value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public void SortInversion()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            DoubleLinkedList doubleLinkedList = (DoubleLinkedList)obj;

            if (Length != doubleLinkedList.Length)
            {
                return false;
            }
            if (Length != 0)
            {
                Node tmp1 = _root;
                Node tmp2 = doubleLinkedList._root;

                while (tmp1 != null || tmp2 != null)
                {
                    if (tmp1.Value != tmp2.Value)
                    {
                        return false;
                    }
                    tmp1 = tmp1.Next;
                    tmp2 = tmp2.Next;
                }

                 tmp1 = _tale;
                 tmp2 = doubleLinkedList._tale;

                while (tmp1 != null || tmp2 != null)
                {
                    if (tmp1.Value != tmp2.Value)
                    {
                        return false;
                    }
                    tmp1 = tmp1.Prev;
                    tmp2 = tmp2.Prev;
                }
            }
            return true;
        }

        public override string ToString()
        {
            string str = "";
            if (Length != 0)
            {
                Node tmp = _root;                

                while (tmp != null)
                {
                    str += tmp.Value + ";";
                    tmp = tmp.Next;
                    
                }
                str += " Rev: ";
                tmp = _tale;
                
                while (tmp != null)
                {
                    str += tmp.Value + ";";
                    tmp = tmp.Prev;
                }
            }
            return str;
        }
    }
}
