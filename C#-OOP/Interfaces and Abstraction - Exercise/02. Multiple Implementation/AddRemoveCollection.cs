using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> addremove;

        public AddRemoveCollection()
        {
            this.addremove = new List<string>();
        }

        public List<string> Addremove => this.addremove;

        public int Add(string item)
        {
            this.addremove.Insert(0, item);
            return this.addremove.IndexOf(item);
        }

        public string Remove()
        {
            var index = this.addremove.Count - 1;
            var item = this.addremove[index];
            this.addremove.RemoveAt(index);
            return item;
        }
    }
}
