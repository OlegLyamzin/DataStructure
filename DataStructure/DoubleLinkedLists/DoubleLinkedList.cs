using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.DoubleLinkedLists
{
    public class DoubleLinkedList : IList
    {

        public int Length { get; private set; }

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
        public int this[int index]
        {
            get
            {
                return GetNodeByIndex(index).Value;
            }
            set 
            {
                GetNodeByIndex(index).Value = value;
            }
        }

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
            if (Length > 0)
            {
                Node tmp = _tale;
                
                for (int i = 0; i < values.Length; i++)
                {
                    tmp.Next = new Node(values[i]);
                    tmp.Next.Prev = tmp;
                    tmp = tmp.Next;
                }
                _tale = tmp;
                Length += values.Length;
            }
            else if (values.Length > 0)
            {
                AddArrayToEmptyList(values);
            }
        }


        public void AddFirst(int value)
        {
            if (Length > 0)
            {
                Node tmp = _root;
                tmp.Prev = new Node(value);
                tmp.Prev.Next = tmp;
                _root = tmp.Prev;
                Length++;
            }
            else
            {
                _root = new Node(value);
                _tale = _root;
                Length++;
            }
        }

        public void AddFirst(int[] values)
        {
            if (Length > 0)
            {
                Node tmp = _root;

                for (int i = values.Length-1; i >= 0; i--)
                {
                    tmp.Prev = new Node(values[i]);
                    tmp.Prev.Next = tmp;
                    tmp = tmp.Prev;
                }

                _root = tmp;
                Length += values.Length;
            }
            else if (values.Length > 0)
            {
                AddArrayToEmptyList(values);
            }
        }
        public void AddByIndex(int index, int value)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                AddFirst(value);
                return;
            }
            else if (index == Length)
            {
                Add(value);
                return;
            }

            Node current = GetNodeByIndex(index-1);
            Node tmp = current.Next;
            current.Next = new Node(value);
            current.Next.Prev = current;
            current.Next.Next = tmp;
            tmp.Prev = current.Next;
            Length++;
        }

        public void AddByIndex(int index, int[] values)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                AddFirst(values);
                return;
            }
            else if (index == Length)
            {
                Add(values);
                return;
            }

            Node current = GetNodeByIndex(index-1);

            Node tmp = current.Next;
            for (int i = 0; i < values.Length; i++)
            {
                current.Next = new Node(values[i]);
                current.Next.Prev = current;
                current = current.Next;
            }
            current.Next = tmp;
            tmp.Prev = current;
            Length += values.Length;
        }

        public void DeleteEnd(int quantity = 1)
        {
            if (Length - quantity < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Length > 1 && Length - quantity != 0)
            {
                
                for (int i = Length; i > Length - quantity; i--)
                {
                    _tale = _tale.Prev;
                }
                _tale.Next = null;

                Length -= quantity;
            }
            else
            {
                _root = null;
                _tale = null;
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
            if (Length > 1 && Length - quantity != 0)
            {

                for (int i = 0; i < quantity; i++)
                {
                    _root = _root.Next;
                }
                _root.Prev = null;

                Length -= quantity;
            }
            else
            {
                _root = null;
                _tale = null;
                Length -= quantity;
            }
        }
        public void DeleteByIndex(int index, int quantity = 1)
        {
            if (index >= Length || index + quantity > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index == 0)
            {
                DeleteFirst(quantity);
                return;
            }
            if (index == Length - 1 || index + quantity == Length)
            {
                DeleteEnd(quantity);
                return;
            }

            Node current = GetNodeByIndex(index);
            for (int i = 0; i < quantity; i++)
            {
                current.Next.Prev = current.Prev;
                current.Prev.Next = current.Next;
                current = current.Next;
            }
            Length -= quantity;
        }

        public void DeleteByValue(int value)
        {
            if (_root != null)
            {
                Node current = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (current.Value == value)
                    {
                        DeleteByIndex(i);
                        return;
                    }
                    current = current.Next;
                }

            }
        }

        public void DeleteByValueAll(int value)
        {
            if (_root != null)
            {
                Node current = _root;                               
                for (int i = 0; i < Length; i++)
                {
                    if (current.Value == value)
                    {
                        DeleteByIndex(i);                        
                        i--;
                    }                    
                    current = current.Next;
                }

            }
        }

        public int GetIndexByValue(int value)
        {
            if (_root != null)
            {
                Node tmp = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (tmp.Value == value)
                    {
                        return i;
                    }
                    tmp = tmp.Next;
                }
            }
            return -1;
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

        public int GetLength()
        {
            return Length;
        }

        public int GetMaximum()
        {
            if (_root != null)
            {
                Node tmp = _root;
                int maximum = _root.Value;
                for (int i = 1; i < Length; i++)
                {
                    tmp = tmp.Next;
                    if (tmp.Value > maximum)
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

        public int GetValueByIndex(int index)
        {
            return GetNodeByIndex(index).Value;
        }

        public void Reverse()
        {
            if (_root != null && _root.Next != null)
            {
                Node current = _root;
                Node tmp;
                while (current != null) 
                {
                    tmp = current.Next;
                    current.Next = current.Prev;
                    current.Prev = tmp;
                    current = current.Prev;
                } 
                tmp = _root;
                _root = _tale;
                _tale = tmp;
            }
        }

        public void SetValueByIndex(int index, int value)
        {
            GetNodeByIndex(index).Value = value;
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
        private void AddArrayToEmptyList(int[] values)
        {
            _root = new Node(values[0]);
            Node tmp = _root;


            for (int i = 1; i < values.Length; i++)
            {
                tmp.Next = new Node(values[i]);
                tmp.Next.Prev = tmp;
                tmp = tmp.Next;
            }

            _tale = tmp;
            Length += values.Length;
        }

        private Node GetNodeByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            Node current;

            if (index < Length / 2)
            {
                current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
            }
            else
            {
                current = _tale;

                for (int i = Length - 1; i > index; i--)
                {
                    current = current.Prev;
                }
            }
            return current;
        }
    }
}
