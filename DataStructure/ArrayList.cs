using System;
using System.Linq;

namespace DataStructure
{
    public class ArrayList
    {

        public int Length { get; private set; }

        private int[] _array;

        public int this[int index] {
            get
            {
                if(index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[index];
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[index] = value;
            }
        }

        public ArrayList()
        {
            _array = new int[9];
            Length = 0;
        }

        public ArrayList(int[] array)
        {
            _array = new int[(int)(array.Length * 1.33 + 1)];
            Array.Copy(array, _array, array.Length);
            Length = array.Length;
        }

        public void Add(int value)
        {
            if (_array.Length <= Length)
            {
                IncreaseLenght();
            }

            _array[Length] = value;
            Length++;
        }

        public void Add(int[] values)
        {
            if(_array.Length <= Length + values.Length)
            {
                IncreaseLenght(values.Length);
            }

            for(int i = 0; i < values.Length; i++)
            {
                _array[Length] = values[i];
                Length++;
            }
        }

        public void AddFirst(int value)
        {
            if (_array.Length <= Length)
            {
                IncreaseLenght();
            }

            ShiftToRight(0);
            _array[0] = value;
            Length++;
        }

        public void AddFirst(int[] values)
        {
            if (_array.Length <= Length + values.Length)
            {
                IncreaseLenght(values.Length);
            }

            ShiftToRight(0, values.Length);

            for (int i = 0; i < values.Length; i++)
            {
                _array[i] = values[i];
                Length++;
            }
        }

        public void AddByIndex(int value, int index)
        {
            if(index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (_array.Length <= Length)
            {
                IncreaseLenght();
            }

            ShiftToRight(index);
            _array[index] = value;
            Length++;
        }

        public void AddByIndex(int[] values, int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (_array.Length <= Length + values.Length)
            {
                IncreaseLenght(values.Length);
            }

            ShiftToRight(index, values.Length);

            for (int i = 0; i < values.Length; i++)
            {
                _array[index + i] = values[i];
                Length++;
            }
        }

        public void DeleteEnd(int quantity = 1)
        {
            if(quantity < 0)
            {
                throw new ArgumentOutOfRangeException("Parameter quantity can't be negative");
            }
            if(0> Length - quantity)
            {
                throw new IndexOutOfRangeException();
            }
            Length -= quantity;

            if (Length < _array.Length / 2 && Length > 0)
            {
                DecreaseLenghth();
            }
        }

        public void DeleteFirst(int quantity=1)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException("Parameter quantity can't be negative");
            }
            if (0 > Length - quantity)
            {
                throw new IndexOutOfRangeException();
            }

            ShiftToLeft(0, quantity);
            Length -= quantity;

            if (Length < _array.Length / 2 && Length > 0)
            {
                DecreaseLenghth();
            }
        }

        public void DeleteByIndex(int index, int quantity = 1)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException("Parameter quantity can't be negative");
            }
            if (index >= Length ||
                index < 0 ||
                index + quantity > Length
                )
            {
                throw new IndexOutOfRangeException();
            }

            ShiftToLeft(index, quantity);
            Length -= quantity;

            if (Length < _array.Length / 2 && Length > 0)
            {
                DecreaseLenghth();
            }
        }

        public int GetLength()
        {
            return Length;
        }

        public int GetValueByIndex(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return _array[index];
        }

        public int GetIndexByValue(int value)
        {
            
            for(int i = 0; i < Length; i++)
            {
                if(_array[i] == value)
                {
                    return i;
                }
            }
            throw new ArgumentException("Value is not exist");
        }

        public void SetValueByIndex(int value, int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            _array[index] = value;
        }

        public void Reverse()
        {
            for (int i = 0; i < (Length / 2); i++)
            {
                int indexFromEnd = Length - i - 1;
                int tmp = _array[i];
                _array[i] = _array[indexFromEnd];
                _array[indexFromEnd] = tmp;
            }
        }

        public int GetMaximum()
        {
            int max = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }

            return max;
        }

        public int GetMinimum()
        {
            int min = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }

            return min;
        }

        public int GetIndexOfMinimum()
        {
            int minIndex = 0;
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < _array[minIndex])
                {
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public int GetIndexOfMaximum()
        {
            int maxIndex = 0;
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > _array[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public void Sort()
        {            
            for (int i = 1; i < Length; i++)
            {
                int j;
                int key = _array[i];
                for (j = i; j > 0 && _array[j - 1] > key; j--)
                {                    
                    _array[j] = _array[j - 1];                    
                }
                _array[j] = key;
            }
            
        }

        public void SortInversion()
        {
            for (int i = 1; i < Length; i++)
            {
                int j;
                int key = _array[i];
                for (j = i; j > 0 && _array[j - 1] < key; j--)
                {
                    _array[j] = _array[j - 1];
                }
                _array[j] = key;
            }
        }

        public void DeleteByValue(int value)
        {
            int i;
            for(i = 0; i < Length && _array[i] != value; i++)
            {

            }

            if(i == Length)
            {
                throw new Exception("Value is not exist");
            }

            DeleteByIndex(i);
        }

        public void DeleteByValueAll(int value)
        {
            bool isExist = false;
            for (int i = 0; i < Length; i++)
            {
                if(_array[i] == value)
                {
                    DeleteByIndex(i);
                    isExist = true;
                }
            }

            if (!isExist)
            {
                throw new Exception("Value is not exist");
            }

        }


        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] != arrayList._array[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return string.Join(";", _array.Take(Length));
        }

        private void DecreaseLenghth()
        {
            int newLenght = _array.Length;
            while (newLenght / 2 >= Length)
            {
                newLenght -= (int)(newLenght * 0.33);
            }

            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, Length);

            _array = newArray;
        }

        private void IncreaseLenght(int number = 1)
        {
            int newLenght = Length;
            while (newLenght <= Length + number)
            {
                newLenght = (int)(newLenght * 1.33 + 1);
            }

            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, _array.Length);

            _array = newArray;
        }

        private void ShiftToRight(int from, int quantity = 1)
        {
            if (_array.Length <= Length)
            {
                IncreaseLenght(quantity);
            }

            for (int i = Length - 1; i >= from; i--)
            {
                _array[i + quantity] = _array[i];
            }
        }
        private void ShiftToLeft(int from, int quantity=1)
        {
            for (int i = from; i < Length-quantity; i++)
            {
                _array[i] = _array[i+quantity];
            }
        }
    }
}
