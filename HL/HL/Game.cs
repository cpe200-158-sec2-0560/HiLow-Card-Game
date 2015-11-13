using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL
{
    class Game
    {
        private Deck deck;
        private Player p1;
        private Player p2;

        public Game()
        {
            deck = new Deck();
            p1 = new Player();
            p2 = new Player();
            Console.WriteLine("Press space to PLAY.");
            deck.shuffle();
            deal();
            play();        
        }
        public void deal()
        {
            for (int i = 0; i < 26; i++)
            {
                p1.add(deck.draw());
                p2.add(deck.draw());
            }
            Console.WriteLine("Cards dealed.");
        }
        void restart()
        {
            deck.restart();
            p1.restart();
            p2.restart();
            deck.shuffle();
            deal();
        }
        void play()
        {
            while(true)
            {
                
                if (!p1.isLeft())
                {
                    if (p1.getScore() > p2.getScore())
                        Console.WriteLine("P1 WON !!!!!!!!!!!!!!");
                    else if (p1.getScore() < p2.getScore())
                        Console.WriteLine("P2 WON !!!!!!!!!!!!!!");
                    else Console.WriteLine("DRAWN !!!!!!!!!!!!!!!");
                    Console.WriteLine("P1 score : " + p1.getScore() + "   P2 score : " + p2.getScore());
                    Console.WriteLine("Press Enter to RESTART.");
                    Console.ReadLine();
                    restart();
                    continue;
                }
                Console.ReadKey();
                int s1, s2;
                s1 = p1.draw();
                s2 = p2.draw();
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.WriteLine("\nP1 :" + getPoint(s1) + getType(s1) + " VS P2 :" + getPoint(s2) + getType(s2));
                s1 %= 13; s1++;
                s2 %= 13; s2++;

                if (s1 < s2)
                {
                    p1.addScore(1);
                    Console.WriteLine("P1 Scored.\n");
                }
                else if(s2 < s1)
                {
                    p2.addScore(1);
                    Console.WriteLine("P2 Scored.\n");
                }
                else
                {
                    Console.WriteLine("Point drawn, start EPIC FIGHT!");
                    
                    int p = p1.getCardleft();
                    if (p > s1) p = s1; 
                    s1 = p1.epicDraw(s1);
                    s2 = p2.epicDraw(s2);

                    Console.WriteLine("P1 :" + getPoint(s1) + getType(s1) + " VS P2 :" + getPoint(s2) + getType(s2));
                    
                    s1 %= 13; s1++;
                    s2 %= 13; s2++;

                    if (s1 < s2)
                    {
                        p1.addScore(p);
                        Console.WriteLine("P1 Scored x"+p+".");
                    }
                    else if (s2 < s1)
                    {
                        p2.addScore(p);
                        Console.WriteLine("P2 Scored x"+p+".");
                    }
                    else
                    {
                        Console.WriteLine("Point drawn again, restart everything.");
                        restart();
                        continue;
                    }

                }
             }
        }

        string getType(int n)
        {
            int temp = (n - 1)/13;
            return Convert.ToString(Convert.ToChar(temp+3));           
        }

        string getPoint(int n)
        {
            while (n > 13) n -= 13;
            if (n == 1) return "A";
            else if (n == 11) return "J";
            else if (n == 12) return "Q";
            else if (n == 13) return "K";
            else return "" + n;
        }

    }
}
