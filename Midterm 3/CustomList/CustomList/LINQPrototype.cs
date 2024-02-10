using CustomList.Exceptions;

namespace CustomList
{
    public static class LINQPrototype
    {
        public static T First<T>(this IEnumerable<T> list, T itemToCheck)
        {
            if (list == null || itemToCheck == null)
                throw new InvalidParameterException();

            foreach (var item in list)
                if (itemToCheck.Equals(item))
                    return item;

            throw new InvalidParameterException();
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> list, T itemToCheck)
        {
            if (list == null || itemToCheck == null)
                throw new InvalidParameterException();

            foreach (var item in list)
                if (itemToCheck.Equals(item))
                    return item;

            return default(T);
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            if (list == null || predicate == null)
                throw new InvalidParameterException();

            MyList<T> items = new MyList<T>();

            foreach (var item in list)
                if (predicate(item))
                    items.Add(item);

            return items;
        }

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> list)
        {
            if (list == null)
                throw new InvalidParameterException();

            var result = new MyList<T>();

            foreach (var item in list)
            {
                if (item == null)
                    break;

                if (!result.Contains(item))
                    result.Add(item);
            }

            return result;
        }

        //public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> list, Func<string, string> selector)
        //{
        //    MyList<string> strings = new MyList<string>();

        //    int indexer = 0;

        //    foreach (var item in list)
        //    {
        //        if (item == null)
        //            break;

        //        strings[indexer] = item.ToString();
        //        indexer++;
        //    }

        //    for (int i = 0; i < strings.Count - 1; i++)
        //    {
        //        for (int j = i + 1; j < strings.Count - 1; j++)
        //        {
        //            if (strings[i].ToCharArray()[0] > strings[j].ToCharArray()[0])
        //            {
        //                var temp = strings[i];
        //                strings[i] = strings[j];
        //                strings[j] = temp;
        //            }
        //        }
        //    }

        //    return (IEnumerable<T>)strings;
        //}
    }
}
