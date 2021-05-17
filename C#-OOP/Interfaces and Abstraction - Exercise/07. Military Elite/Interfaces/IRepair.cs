using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interface
{
   public interface IRepair
    {
        string PartName { get; }
        int Hours { get; }
    }
}
