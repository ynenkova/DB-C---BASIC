using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> stacks;
        public Stack(List<T> items)
        {
            stacks = new List<T>();
        }

        public int Count => this.stacks.Count;
        public void Push(T item)
        {
            this.stacks.Add(item);

        }
        public T Pop()
        {
            if (this.stacks.Count == 0)
            {
                throw new ArgumentException("No elements");
            }
            T item = this.stacks[this.stacks.Count - 1];
            this.stacks.RemoveAt(this.stacks.Count - 1);
            return item;
        }

        public void Push(IEnumerable<T> elements)
        {
            foreach (var item in elements)
            {
                this.Push(item);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.stacks.Count-1; i >= 0; i--)
            {
                yield return this.stacks[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
