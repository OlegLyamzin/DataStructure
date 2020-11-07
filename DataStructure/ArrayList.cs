using System;

namespace DataStructure
{
    public class ArrayList
    {

        public int Length { get; private set; }

        private int[] _array;

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

        public void AddByIndex(int value, int index)
        {
            if (_array.Length <= Length)
            {
                IncreaseLenght();
            }

            ShiftToRight(index);
            _array[index] = value;
            Length++;
        }

        public void DeleteEnd(int quantity = 1)
        {
            Length -= quantity;

            if (Length < _array.Length / 2)
            {
                DecreaseLenghth();
            }
        }

        public void DeleteFirst(int quantity=1)
        {
            ShiftToLeft(0, quantity);
            Length -= quantity;

            if (Length < _array.Length / 2)
            {
                DecreaseLenghth();
            }
        }


        private void DecreaseLenghth()
        {
            int newLenght = _array.Length;
            while (newLenght / 2 >= Length)
            {
                newLenght -= (int)(newLenght * 0.33);
            }

            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, _array.Length);

            _array = newArray;
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
            for (int i = from; i < Length-1; i++)
            {
                _array[i] = _array[i+quantity];
            }
        }
    }
}
