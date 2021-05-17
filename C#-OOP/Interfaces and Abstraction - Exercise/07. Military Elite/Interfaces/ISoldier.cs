using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interface
{
   public interface ISoldier
    {
        string FirstName { get; }
        string LastName { get; }
        string Id { get; }

    }
}
