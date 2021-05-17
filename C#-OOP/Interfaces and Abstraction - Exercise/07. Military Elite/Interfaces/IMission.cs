using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interface
{
   public interface IMission
    {
        string CodeName { get; }
        string States { get; }
        void CompleteMission();
    }
}
