using System.Linq;

namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(4);

            var numbers = new int[4] { 1, 2, 3, 4 };

            list.AddRange(numbers);
            list.Remove(4);
            list.RemoveRange(0, 2);

            MyList<string> strings = new MyList<string>();

            strings.Add("Hello");
            strings.Add("World");
            strings.Add("Gio");
            strings.Add("Gio");
            strings.Add("HP");

            strings.RemoveAt(0);

            strings[0] = "new hello";
            var count = strings.Count;
            var contains = strings.Contains("Hello");
            var first = strings.First("HP");
            var firstOrDefault = strings.FirstOrDefault("nothing");
            var filteredStrings = strings.Where(txt => txt == "Gio");
            var distincts = strings.Distinct();
        }
    }
}
