namespace Generic_Practices.Generics
{
    public class GenericQueue<T>
    {
        private T[] queue = new T[5];

        // indexer is used to keep track of enqueued elements
        // in order to not confuse them with default values
        private int indexer = 0;

        private T? addedEarliest { get; set; }

        // Adds element into array and increments indexer by one
        public void Enqueue(T element)
        {
            // If array is full increase it's size
            if (indexer == queue.Length - 1)
                IncreaseArraySize();

            if (indexer == 0)
                addedEarliest = element;

            queue[indexer] = element;
            indexer++;
        }
        
        public T Peek()
        {
            return addedEarliest;
        }

        // Removes and returns 0th element from the array
        public T Dequeue()
        {
            if (indexer == 0)
                return default;

            T dequeuedItem = queue[0];

            queue = queue.Skip(1).ToArray();
            addedEarliest = queue[0];

            return dequeuedItem;
        }

        private void IncreaseArraySize()
        {
            T[] newArray = new T[queue.Length * 2];

            for (int i = 0; i < indexer; i++)
                newArray[i] = queue[i];

            queue = newArray;
        }
    }
}