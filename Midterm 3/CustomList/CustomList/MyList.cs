using CustomList.Exceptions;
using System.Collections;

namespace CustomList
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] Items { get; set; }
        private int DefaultCapacity { get; set; } = 4;
        private int TakenIndex { get; set; } = 0;
        public int Count
        {
            get
            {
                return TakenIndex;
            }
        }

        public MyList()
        {
            Items = new T[DefaultCapacity];
        }

        public MyList(int capacity)
        {
            if (capacity < 0)
                throw new InvalidCapacityException();
            else if (capacity == 0)
                Items = new T[0];
            else
                Items = new T[capacity];
        }

        public void Add(T item)
        {
            if (TakenIndex == Items.Length)
                IncreaseSize();

            Items[TakenIndex++] = item;
        }

        public void AddRange(T[] items)
        {
            while (items.Length > Items.Length - TakenIndex)
                IncreaseSize();

            foreach (var item in items)
                Items[TakenIndex++] = item;
        }

        public bool Remove(T itemToRemove)
        {
            if (Items.Length == 0)
                throw new InvalidCapacityException("Empty list. Nothing to remove.");

            if (itemToRemove == null)
                throw new InvalidParameterException();

            for (int i = 0; i < TakenIndex; i++)
            {
                if (itemToRemove.Equals(Items[i]))
                {
                    Items[i] = default(T);
                    SortItems(i);
                    TakenIndex--;
                    return true;
                }
            }

            return false;
        }

        private void SortItems(int startIndex)
        {
            for (int j = startIndex; j < TakenIndex - 1; j++)
            {
                var temp = Items[j];
                Items[j] = Items[j + 1];
                Items[j + 1] = temp;
            }
        }

        public void RemoveRange(int startIndex, int endIndex)
        {
            if (Items.Length == 0)
                throw new InvalidCapacityException("Empty list. Nothing to remove.");

            if (startIndex < 0 || endIndex > TakenIndex)
                throw new InvalidParameterException();

            for (int i = startIndex; i <= endIndex; i++)
                Remove(Items[startIndex]);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Items.Length)
                throw new InvalidParameterException();

            Remove(Items[index]);
        }

        public bool Contains(T itemToCheck)
        {
            if (itemToCheck == null)
                throw new InvalidParameterException();

            for (int i = 0; i < TakenIndex; i++)
                if (itemToCheck.Equals(Items[i]))
                    return true;

            return false;
        }

        private void IncreaseSize()
        {
            var temp = Items;
            DefaultCapacity *= 2;
            Items = new T[DefaultCapacity];

            for (int i = 0; i < temp.Length; i++)
                Items[i] = temp[i];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Items.Length)
                    throw new IndexOutOfRangeException();
                else
                    return Items[index];
            }
            set
            {
                if (index < 0 || index >= Items.Length)
                    throw new IndexOutOfRangeException();
                else
                    Items[index] = value;
            }
        }
    }
}
