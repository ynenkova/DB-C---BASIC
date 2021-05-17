using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public string Dialing(string number)
        {
            var regex = new Regex(@"\d+");
            var macht = regex.Match(number);
            if (macht.Success)
            {
                return $"Dialing... { number}";
            }
            return "Invalid number!";
        }
    }
}
