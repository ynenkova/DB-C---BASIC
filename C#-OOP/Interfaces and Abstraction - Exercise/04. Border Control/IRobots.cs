using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
   public interface IRobots
    {
        string Model { get; }
        string Id { get; }
    }
}
