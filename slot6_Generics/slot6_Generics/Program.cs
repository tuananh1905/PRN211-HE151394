using System;
using System.Collections;

namespace slot6_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = 0, number;
            IntCollection collection = new IntCollection();
            collection.AddInt(10);
            collection.AddInt(20);
            collection.AddInt(30);
            for(int i = 0; i < collection.Count; i++)
            {
                number = collection.GetInt(i);
                s += number;
                Console.Write($"{number}" + $"{(i == collection.Count - 1 ? " = " : " + ")}");
            }
            Console.WriteLine($"{s}");
        }
    }

    public class IntCollection
    {
        private ArrayList arInts = new ArrayList();
        public int GetInt(int pos) => (int)arInts[pos];
        public void AddInt(int n) => arInts.Add(n);
        public void ClearInts() => arInts.Clear();
        public int Count => arInts.Count;
    }
}
