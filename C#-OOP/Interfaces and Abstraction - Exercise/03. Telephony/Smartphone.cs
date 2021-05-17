using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class Smartphone : ISmartphone
    {
        public string Brows(string web)
        {
            var regex = new Regex(@"\d+");
            var macht = regex.Match(web);
            if (macht.Success)
            {
                return "Invalid URL!";
            }

            return $"Browsing: {web}!";
        }

        public string Call(string number)
        {
            var regex = new Regex(@"[\D]+");
            var macht = regex.Match(number);
            if (macht.Success)
            {
                return "Invalid number!";
            }

            return $"Calling... { number}";
        }
    }
}
