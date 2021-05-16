using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {
        private int tireAge;
        private double tirePress;
        public Tire(double tirePress, int tireAge)
        {
            this.TirePress = tirePress;
            this.TireAge = tireAge;

        }
        public int TireAge
        {
            get
            {
                return this.tireAge;
            }
            set
            {
                this.tireAge = value;
            }
        }
        public double TirePress
        {
            get
            {
                return this.tirePress;
            }
            set
            {
                this.tirePress = value;
            }
        }
    }
}
