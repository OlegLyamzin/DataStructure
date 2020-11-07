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

        private void ShiftToRight(int from, int quantity=1)
        {
            if (_array.Length <= Length)
            {
                IncreaseLenght(quantity);
            }

            for (int i = Length-1; i > from; i--)
            {
                _array[i + quantity] = _array[i];
            }
        }
    }
}
