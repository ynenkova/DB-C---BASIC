using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Contracts
{
   public class HelloCommand:ICommand
    {
        public string Execute(string[] args)
        {
            string name = args[0];

            return $"Hello, {args[0]}";

        }
    }
}
