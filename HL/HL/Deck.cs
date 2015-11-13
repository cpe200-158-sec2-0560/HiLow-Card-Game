using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL
{
    class Deck
    {
        private int[] card;
        private Random rnd;
        private int left;

        public Deck()
        {
            card = new int[52];
            rnd = new Random();
            left = 0;
        }

        public void restart()
        {
            left = 0;
        }

        public void shuffle()
        {
            int i;

            bool[] used;
            used = new bool[53];
            for (i = 0; i < 53; i++) {
                used[i] = false;
            }

            for (i = 0; i < 52; i++)
            {
                int temp = rnd.Next(52) + 1;
                while(used[temp] == true)
                {
                    temp = rnd.Next(52) + 1;
                }
                used[temp] = true;
                card[i] = temp;
            }

            left = 52;
            Console.WriteLine("Deck shuffled.");
        }

        public int draw()
        {
            left--;
            return card[left];
        }

        public void add(int n)
        {
            this.card[left] = n;
            left++;
        }

       
        public bool isLeft()
        {
            return !(left == 0);
        }
        public int getCardLeft()
        {
            return left;
        }
    }
}
