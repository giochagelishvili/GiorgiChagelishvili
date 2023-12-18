namespace Generic_Practices.Generics
{
    public class GenericStack<T>
    {
        private T[] stack = new T[5];

        // Indexer is used to keep track of Pushed elements inside an array
        // In order to not confuse them with default values
        private int indexer = 0;

        private T? addedLast { get; set; }

        // Adds element into an array
        public void Push(T element)
        {
            // If array is full increase it's size
            if (indexer == stack.Length - 1)
                IncreaseSize();

            stack[indexer] = element;
            addedLast = element;
            indexer++;
        }

        public T Peek()
        {
            return addedLast;
        }

        public T Pop()
        {
            if (indexer <= 0)
                return default;

            T poppedItem = stack[indexer - 1];

            // Turn array into a list, remove (pop) last added item and turn list back into array
            var tempList = stack.ToList();
            tempList.RemoveAt(indexer - 1);
            stack = tempList.ToArray();

            indexer--;
            addedLast = stack[indexer - 1];

            return poppedItem;
        }

        private void IncreaseSize()
        {
            T[] newArray = new T[stack.Length * 2];

            for (int i = 0; i < indexer; i++)
            {
                newArray[i] = stack[i];
            }

            stack = newArray;
        }
    }
}
