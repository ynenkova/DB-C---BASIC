using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        private List<string> addcoll;

        public AddCollection()
        {
            this.addcoll = new List<string>();
        }

        public List<string> Addcoll => this.addcoll;

        public int AddCollec(string item)
        {
            this.addcoll.Add(item);
            return this.addcoll.IndexOf(item);
        }
    }
}
