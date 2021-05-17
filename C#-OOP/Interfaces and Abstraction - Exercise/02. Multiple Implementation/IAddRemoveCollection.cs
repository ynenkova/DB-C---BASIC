using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
   public interface IAddRemoveCollection
    {
        int Add(string item);
        string Remove();
    }
}
