using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> mylist;
        private int index;
        public ListyIterator(List<T> mylist)
        {
            this.MyList = mylist;
            this.index = 0;
        }
        public List<T> MyList { get; set; }
        public int Count => this.MyList.Count;
        public void Create(List<T> mylist, T elements)
        {
            if (this.mylist.Count == 0)
            {
                this.MyList = new List<T>();
            }
            else
            {
                this.MyList.Add(elements);
            }
        }
        public bool Move()
        {
            if (this.index < this.Count - 1)
            {
                index++;
                return true;
            }
            else
            {

                return false;
            }
        }
        public void Print()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.MyList[this.index]);
        }
        public bool HasNext()
        {
            if (this.index < this.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in this.MyList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
