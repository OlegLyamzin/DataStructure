using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.LinkedLists
{
    public class LinkedList
    {
        public int Length { get; set; }

        private Node _root;

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        public LinkedList(int[] array)
        {
            if(array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;

                for(int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp = tmp.Next;
                }

                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
            }
        }

        public LinkedList(int value)
        {
            _root = new Node(value);
            Length = 1;
        }

        public LinkedList()
        {
            _root = null;
            Length = 0;
        }

        public void Add(int value)
        {
            if (Length > 0)
            {
                Node tmp = _root;

                for (int i = 0; i < Length - 1; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = new Node(value);
                Length++;
            }
            else
            {
                _root = new Node(value);
                Length++;
            }
            
        }

        public void Add(int[] values)
        {
            if (Length > 0)
            {
                Node tmp = _root;

                for (int i = 0; i < Length - 1; i++)
                {
                    tmp = tmp.Next;
                }
                for (int i = 0; i < values.Length; i++)
                {
                    tmp.Next = new Node(values[i]);
                    tmp = tmp.Next;
                }
                Length+=values.Length;
            }
            else if(values.Length > 0)
            {
                AddArrayToEmptyList(values);
            }

        }

        public void AddFirst(int value)
        {
            if(Length > 0)
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;
                Length++;
            }
            else
            {
                _root = new Node(value);
                Length++;
            }
        }

        public void AddFirst(int[] values)
        {
            if (Length > 0)
            {
                
                for(int i = values.Length-1; i >= 0; i--)
                {
                    Node tmp = _root;
                    _root = new Node(values[i]);
                    _root.Next = tmp;
                }
                
                Length+=values.Length;
            }
            else if(values.Length > 0)
            {
                AddArrayToEmptyList(values);
            }
        }

        public void AddByIndex(int index, int value)
        {
            if(index <0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (Length > 0)
            {
                Node current = _root;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                Node tmp = current.Next;
                current.Next = new Node(value);
                current.Next.Next = tmp;
                Length++;
                
            }
            else
            {
                _root = new Node(value);
                Length++;
            }
        }

        public void AddByIndex(int index, int[] values)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (Length > 0)
            {
                Node current = _root;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                Node tmp = current.Next;
                for (int i = 0; i < values.Length; i++)
                {
                    current.Next = new Node(values[i]);
                    current = current.Next;
                }
                current.Next = tmp;
                Length+=values.Length;

            }
            else
            {
                AddArrayToEmptyList(values);
            }
        }

        public void DeleteEnd(int quantity=1)
        {
            if (Length -quantity < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Length > 1)
            {
                Node current = _root;

                for (int i = 1; i < Length - quantity; i++)
                {
                    current = current.Next;
                }


                current.Next = null;

                Length -= quantity;
            }
            else
            {
                _root = null;
                Length -= quantity;
            }
        }

        public void DeleteFirst(int quantity = 1)
        {
            if (Length - quantity < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Length > 1)
            {
                Node current = _root;

                for (int i = 1; i <= quantity; i++)
                {
                    current = current.Next;
                }

                _root = current;

                Length -= quantity;
            }
            else
            {
                _root = null;
                Length -= quantity;
            }

        }

        public void DeleteByIndex(int index, int quantity = 1)
        {
            
            if (index >= Length||index + quantity > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Length > 1 && index !=0)
            {
                Node current = _root;
                Node tmp = current;

                for (int i = 1; i <= index + quantity; i++)
                {
                    if(i == index)
                    {
                        tmp = current;
                    }
                    current = current.Next;
                }
                
                tmp.Next = current;
                Length -= quantity;
            }
            else if (Length > 0 && index == 0)
            {
                DeleteFirst(quantity);
            }
            else
            {
                _root = null;
                Length -= quantity;
            }
        }

        

        public int GetLength()
        {
            return Length;
        }

        public int GetValueByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = _root;
            for (int i = 1; i <= index; i++)
            {
                tmp = tmp.Next;
            }
            return tmp.Value;
        }

        public int GetIndexByValue(int value)
        {
            if(_root != null)
            {
                Node tmp = _root;
                for(int i = 0; i < Length; i++)
                {
                    if(tmp.Value == value)
                    {
                        return i;
                    }
                    tmp = tmp.Next;
                }
            }
            throw new ArgumentException("Value is not exist");
        }

        public void SetValueByIndex(int index, int value)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = _root;
            for (int i = 1; i <= index; i++)
            {
                tmp = tmp.Next;
            }
            tmp.Value = value;
        }

        public void Reverse()
        {
            if (_root != null && _root.Next != null)
            {
                Node first = _root;
                Node prev = _root;
                Node current = _root;

                while(_root.Next!= null)
                {
                    prev = _root;
                    _root = _root.Next;
                }
                _root.Next = prev;
                
                for (int i = 1; i < Length; i++)
                {
                    current = first;
                    prev = current;
                    for(int j = 1; j < Length - i; j++)
                    {
                        prev = current;
                        current = current.Next;
                    }
                    current.Next = prev;
                }
                current.Next = null;
            }
        }

        public int GetMaximum()
        {
            if(_root != null)
            {
                Node tmp = _root;
                int maximum = _root.Value;
                for (int i = 1; i < Length; i++)
                {
                    tmp = tmp.Next;
                    if(tmp.Value > maximum)
                    {
                        maximum = tmp.Value;
                    }
                }
                return maximum;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public int GetMinimum()
        {
            if (_root != null)
            {
                Node tmp = _root;
                int minimum = _root.Value;
                for (int i = 1; i < Length; i++)
                {
                    tmp = tmp.Next;
                    if (tmp.Value < minimum)
                    {
                        minimum = tmp.Value;
                    }
                }
                return minimum;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public int GetIndexOfMaximum()
        {
            if (_root != null)
            {
                Node tmp = _root;
                int maximum = _root.Value;
                int index = 0;
                for (int i = 1; i < Length; i++)
                {
                    tmp = tmp.Next;
                    if (tmp.Value > maximum)
                    {
                        maximum = tmp.Value;
                        index = i;
                    }
                }
                return index;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public int GetIndexOfMinimum()
        {
            if (_root != null)
            {
                Node tmp = _root;
                int minimum = _root.Value;
                int index = 0;
                for (int i = 1; i < Length; i++)
                {
                    tmp = tmp.Next;
                    if (tmp.Value < minimum)
                    {
                        minimum = tmp.Value;
                        index = i;
                    }
                }
                return index;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Sort()
        {
            if (_root != null && _root.Next != null)
            {
                Node next = _root.Next;
                Node key;
                Node current;
                while (next.Next != null)
                {
                    key = next.Next;
                    next.Next = next.Next.Next;
                    next = next.Next;
                    current = _root;

                    while (current.Next != null && current.Next.Value < key.Value)
                    {
                        current = current.Next;
                    }
                    Node tmp = current.Next;
                    current.Next = key;
                    key.Next = tmp;

                    Node prev = _root;
                    while (prev.Next != next)
                    {
                        prev = prev.Next;
                    }
                    next = prev;
                }
                if (_root.Value > _root.Next.Value)
                {
                    key = _root;
                    _root = key.Next;
                    current = _root;
                    while (current.Next != null && current.Next.Value < key.Value)
                    {
                        current = current.Next;
                    }
                    Node tmp = current.Next;
                    current.Next = key;
                    key.Next = tmp;
                }
            }
        }

        public void SortInversion()
        {
            if (_root != null && _root.Next != null)
            {
                Node next = _root.Next;
                Node key;
                Node current;
                while (next.Next != null)
                {
                    key = next.Next;
                    next.Next = next.Next.Next;
                    next = next.Next;
                    current = _root;

                    while (current.Next != null && current.Next.Value > key.Value)
                    {
                        current = current.Next;
                    }
                    Node tmp = current.Next;
                    current.Next = key;
                    key.Next = tmp;

                    Node prev = _root;
                    while (prev.Next != next)
                    {
                        prev = prev.Next;
                    }
                    next = prev;
                }
                if (_root.Value < _root.Next.Value)
                {
                    key = _root;
                    _root = key.Next;
                    current = _root;
                    while (current.Next != null && current.Next.Value > key.Value)
                    {
                        current = current.Next;
                    }
                    Node tmp = current.Next;
                    current.Next = key;
                    key.Next = tmp;
                }
            }
        }

        public void DeleteByValue(int value)
        {
            if(_root != null)
            {
                Node current = _root;
                int i;
                for (i = 0;i < Length ; i++)
                {                    
                    if(current.Value == value)
                    {
                        DeleteByIndex(i);
                        
                        return;

                    }
                    current = current.Next;
                }
                
            }
            throw new ArgumentException("Value is not exist");
        }

        public void DeleteByValueAll(int value)
        {
            bool isExist = false;
            if (_root != null)
            {
                Node current = _root;
                Node prev =current;
                int i;
                for (i = 0; i < Length; i++)
                {
                    if (current.Value == value)
                    {
                        DeleteByIndex(i);
                        isExist = true;
                        current = prev;
                        i--;                        
                    }
                    prev = current;
                    current = current.Next;
                }

            }
            if (!isExist)
            {
                throw new ArgumentException("Value is not exist");
            }
        }               

        public override string ToString()
        {
            string str = "";
            Node tmp = _root;

            while (tmp != null)
            {
                str += tmp.Value + ";";
                tmp = tmp.Next;
            }
            return str;
        }

        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

            if (Length != linkedList.Length)
            {
                return false;
            }
            if (Length != 0)
            {
                Node tmp1 = _root;
                Node tmp2 = linkedList._root;

                while (tmp1 != null || tmp2 != null)
                {
                    if (tmp1.Value != tmp2.Value)
                    {
                        return false;
                    }
                    tmp1 = tmp1.Next;
                    tmp2 = tmp2.Next;
                }
            }
            return true;
        }
        private void AddArrayToEmptyList(int[] values)
        {
            _root = new Node(values[0]);
            Node tmp = _root;
            for (int i = 1; i < values.Length; i++)
            {
                tmp.Next = new Node(values[i]);
                tmp = tmp.Next;
            }
            Length += values.Length;
        }
    }
}
