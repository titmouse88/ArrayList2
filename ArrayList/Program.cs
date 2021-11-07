using System;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] arr = new int[] { 6, 5, 4, 3, 2, 1 };
            LinkedList list = new LinkedList(arr);
                list.Sort();
            var arr1 = list.ToArray();
            foreach (var item in arr1)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
;        }
    }
}
