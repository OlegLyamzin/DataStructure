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

            if(Length != linkedList.Length)
            {
                return false;
            }
            Node tmp1 = _root;
            Node tmp2 = linkedList._root;

            while (tmp1 != null || tmp2 != null)
            {
                if(tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }

            return true;
        }
    }
}
