using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyList mylist = new MyList();
            AddCollection addcoll = new AddCollection();
            AddRemoveCollection addremove = new AddRemoveCollection();
            var items = Console.ReadLine().Split(" ");
            var n = int.Parse(Console.ReadLine());
            ReturnIndex(mylist, addcoll, addremove, items);
            RemoveItem(mylist, addremove, n);
        }

        private static void RemoveItem(MyList mylist, AddRemoveCollection addremove, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(addremove.Remove() + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(mylist.Remove() + " ");
            }
        }

        private static void ReturnIndex(MyList mylist, AddCollection addcoll, AddRemoveCollection addremove, string[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Console.Write(addcoll.AddCollec(items[i]) + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < items.Length; i++)
            {
                Console.Write($"{addremove.Add(items[i])} ");
            }
            Console.WriteLine();
            for (int i = 0; i < items.Length; i++)
            {
                Console.Write(mylist.AddMyList(items[i]) + " ");
            }
            Console.WriteLine();
        }
    }
}
