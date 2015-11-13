using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL
{
    class Player
    {
        private Deck deck;
        private int score;
        
        public Player()
        {
            deck = new Deck();
        }
        public void restart()
        {
            score = 0;
            deck.restart();
        }
        public void add(int n)
        {
            deck.add(n);
        }
        public int draw()
        {
            return deck.draw();
        }
        public void addScore(int n)
        {
            score+=n;
        }
        public bool isLeft()
        {
            return deck.isLeft();
        }
        public int getScore()
        {
            return score;
        }
        public int epicDraw(int n)
        {
            int point=0;
            for(int i=0;i< n; i++)
            {
                if (isLeft())
                {
                    point = draw();
                }
                else break;
            }
            return point;
        }
        public int getCardleft()
        {
            return deck.getCardLeft();
        }
    }
}
