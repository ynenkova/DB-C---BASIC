using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IMyList
    {
        private List<string> mylist;

        public MyList()
        {
            this.mylist = new List<string>();
        }

        public List<string> Mylist => this.mylist;

        public int AddMyList(string item)
        {
            this.mylist.Insert(0, item);
            return this.mylist.IndexOf(item);
        }

        public string Remove()
        {
            var item = mylist[0];
            this.mylist.RemoveAt(0);
            return item;
        }

        public int Used()
        {
            return this.mylist.Count;
        }
        public string  MyListAdd()
        {
            var sb = new StringBuilder();
            foreach (var item in this.Mylist)
            {
                sb.Append(this.Mylist.IndexOf(item)+" ");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
