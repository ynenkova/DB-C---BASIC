using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<TFirst, TSecond,Tthirth>
    {
        private TFirst itemFirst;
        private TSecond itemSecond;
        private Tthirth itemThirth;
        public Tuple(TFirst item1, TSecond item2,Tthirth item3)
        {
            this.ItemFirst = item1;
            this.ItemSecond = item2;
            this.itemThirth = item3;
        }
        public TFirst ItemFirst { get; set; }
        public TSecond ItemSecond { get; set; }
        public Tthirth ItemThirth { get; set; }
        public override string ToString()
        {
            return $"{this.ItemFirst} -> {this.ItemSecond} -> {this.itemThirth}";
        }
    }
}
