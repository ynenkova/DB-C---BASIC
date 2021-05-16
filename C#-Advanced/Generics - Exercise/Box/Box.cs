using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Generic_Box_of_String
{
    public class Box<T> where T: IComparable
    {
        public Box(List<T> value)
        {
            this.Value = value;
        }

        public List<T> Value { get; set; } = new List<T>();

        public void Swap(int first, int second)
        {
            T firstele = this.Value[first];
            this.Value[first] = this.Value[second];
            this.Value[second] = firstele;
        }
        public int Count(T element)
        {
            int count = 0;
            foreach (T value in this.Value)
            {
                if (element.CompareTo(value)<0)
                {
                    count++;
                }
            }
            return count;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (T item in this.Value)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
           return sb.ToString().TrimEnd();
        }
    }
}
