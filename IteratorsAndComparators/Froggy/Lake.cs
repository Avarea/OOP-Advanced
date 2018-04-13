using System.Collections;
using System.Collections.Generic;


    public class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(int[] stones)
        {
            this.stones = stones;
        }


        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i+=2)
            {
                yield return this.stones[i];
            }

            int lastIndex = this.stones.Length - 1;
            if (this.stones.Length % 2 == 1)
            {
                lastIndex--;
            }

            for (int i = lastIndex; i > 0; i-=2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
