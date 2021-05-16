using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> stones;
        public Lake(params int[] stone)
        {
           this.stones =stone.ToList();
        }
        public IEnumerator<int> GetEnumerator()
        {
            var count = this.stones.Count();
            for (int i = 0; i < count; i+=2)
            {
                yield return this.stones[i];
            }
            var lastIndex = count- 1;
            if (lastIndex%2==0)
            {
                lastIndex--;
            }
            for (int i = lastIndex; i >= 0; i-=2)
            {
                    yield return this.stones[i];
               
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
