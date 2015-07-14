using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Academy_Arcade_console
{
   

    class players
    {
        private int[] cards = new int [2];
        private string[] suit = new string [2];


        public void assign(int x, int y)
        {
            cards[0] = x;
            cards[1] = y;
        }

        public void assignSuit(string x, string y)
        {
            suit[0] =  x;
            suit[1] =  y;
        }

        public int reveal1()
        {
            return cards[0];
        }
        public int reveal2()
        {
            return cards[1];
        }


    }

    class write
    {

        private string intro1 = "Welcome to the Academy Casino!\n\n";
        private string intro2 = "As a guest at our casino we will allot you some money to play with.\n\n";
        private string intro3 = "We will start you off with $3000.\n\n";
        private string intro4 = "It will be based on your performance how much you are rewarded with.\n\n";
        private string intro5 = "All the money that you are left with is yours by the end.\n";
        private string intro6 = "Please don\'t lose it all...\n\n\n";


        public void welcome()
        {
            for (int i = 0; i < intro1.Length; ++i)
            {
                Console.Write("{0}", intro1[i]);
                Thread.Sleep(15);
            }
            Thread.Sleep(2250);

            for (int i = 0; i < intro2.Length; ++i)
            {
                Console.Write("{0}", intro2[i]);
                Thread.Sleep(15);
            }
            Thread.Sleep(2500);

            for (int i = 0; i < intro3.Length; ++i)
            {
                Console.Write("{0}", intro3[i]);
                Thread.Sleep(15);
            }
            Thread.Sleep(2750);

            for (int i = 0; i < intro4.Length; ++i)
            {
                Console.Write("{0}", intro4[i]);
                Thread.Sleep(15);
            }
            Thread.Sleep(2750);

            for (int i = 0; i < intro5.Length; ++i)
            {
                Console.Write("{0}", intro5[i]);
                Thread.Sleep(15);
            }
            Thread.Sleep(2750);

            for (int i = 0; i < intro6.Length; ++i)
            {
                Console.Write("{0}", intro6[i]);
                Thread.Sleep(15);
            }
            Thread.Sleep(750);
        }

        public void pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

    }

    class Bank
    {
        static private int money = 3000;
        static private int poker = 0;
        private int pot = 0;
        private int[] cards = new int[6];
        private int round = 0;
        private int blind = 1;

        Random rnd = new Random();

        public int [] draw()
        {
            cards[0] = rnd.Next(1, 14);
            cards[1] = rnd.Next(1, 14);
            cards[2] = rnd.Next(1, 14);
            cards[3] = rnd.Next(1, 14);
            cards[4] = rnd.Next(1, 14);
           // Console.WriteLine("{0},{1},{2},{3},{4}", cards[0], cards[1], cards[2], cards[3], cards[4]);

            return cards;
        }

   
        public void smallBlind()
        {
           
            money -= blind;
            pot += blind;
        }

        public void bet(int bet)
        {
            money -= bet;
            pot += bet;
        }

        public void won()
        {
            money += pot;
        }

        public void displayBank()
        {
            Console.WriteLine("You currently have ${0} in your bank.", money);
        }

        public int pokerPlay()
        {
            poker++;
            return poker;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            write author = new write();
            Random rnd = new Random();

           // author.welcome();
            author.pause();
            Console.Clear();

            while (true)
            {
                Bank bank = new Bank();

                string[] choice = new string[] { "Texas Hold\'em", "BlackJack" };



                Console.WriteLine("Please select what you would like to do by line number:");

                for (int i = 0; i < 50; ++i)
                {
                    Console.Write("*");
                }
                Console.WriteLine("\n");
                int count = 0;
                foreach (string game in choice)
                {
                    count++;
                    Console.Write("{0}\t", count);
                    Console.WriteLine("{0}", choice[count - 1]);
                }
                Console.WriteLine("\nTo exit, press \'x\'");
                Console.WriteLine("\n");

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }

                string cardGame;
                cardGame = Console.ReadLine();
                Console.Clear();
                if (cardGame == "x")
                    break;

                if (cardGame == "1" || cardGame == "t")
                {
                    Console.WriteLine("Welcome to the game of Texas Hold\'em!");
                    Thread.Sleep(1500);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(false);
                    }
                    bank.displayBank();
                    author.pause();
                  

                    if (bank.pokerPlay() == 1)
                    {
                        string input;
                        Console.Clear();
                        Console.WriteLine("Dealer: So I see this is your first time playing with me at the Academy Casino.");
                        Thread.Sleep(2500);
                        while (true)
                        {
                            Console.WriteLine("Would you like a tutorial on how to play? (y/n)");
                            while (Console.KeyAvailable)
                            {
                                Console.ReadKey(false);
                            }
                            input = Console.ReadLine();
                            if (input == "Y" || input == "y") ;
                            else if (input == "N" || input == "n")
                                break;
                            else
                            {
                                Console.Clear();
                                continue;
                            }


                            Console.Clear();
                            Console.WriteLine("So you really want to play, hmm?");
                            Thread.Sleep(2000);
                            Console.WriteLine("");
                            Thread.Sleep(2000);




                            break;
                        }
                    }
                        Console.Clear();
                        int player;

                        while(true){
                        Console.WriteLine("Please select the amount of players(2-8): ");
                        string playersss;
                        playersss = Console.ReadLine();
                        Console.Clear();

                        
                        Int32.TryParse(playersss, out player);
                        
                        //Console.WriteLine("{0}", player);

                            if(player > 1 && player <= 8)
                            {
                                break;
                            }
                        }

                        players player1 = new players();
                    List<players>playerList = new List<players>();

                    while(true){
                        int x, y;

                        x = rnd.Next(1, 14);
                        y = rnd.Next(1, 14);

                        player1.assign(x,y);

                        for (int i = 1; i != player; ++i)
                        {
                            playerList.Add(new players());  
                        }


                        foreach (var players in playerList)
                        {

                            x = rnd.Next(1, 14);
                            y = rnd.Next(1, 14);

                            players.assign(x,y);
                        }

                    string playerCard1;
                     if(player1.reveal1() == 11)
                         playerCard1 = "Jack";
                     else if(player1.reveal1() == 12)
                         playerCard1 = "Queen";
                     else if(player1.reveal1() == 13)
                         playerCard1 = "King";
                     else if(player1.reveal1() == 1)
                         playerCard1 = "Ace";
                     else
                         playerCard1 = player1.reveal1().ToString();

                    string playerCard2;
                     if(player1.reveal2() == 11)
                         playerCard2 = "Jack";
                     else if(player1.reveal2() == 12)
                         playerCard2 = "Queen";
                     else if(player1.reveal2() == 13)
                         playerCard2 = "King";
                         else if(player1.reveal2() == 1)
                         playerCard2 = "Ace";
                     else
                         playerCard2 = player1.reveal2().ToString();
                         
                    Console.WriteLine("Your cards are: {0}, {1}\n\n", playerCard1, playerCard2);

                    author.pause();
                     Console.Clear();
                     Console.WriteLine("Your cards are:\n\n {0},\t{1}\n\n", playerCard1, playerCard2);

                    int[] dealer;
                    dealer = bank.draw();
                    //Console.WriteLine("{0},{1},{2},{3},{4}", dealer[0], dealer[1], dealer[2], dealer[3], dealer[4]);

                    string [] dealerRevision = new string[10];


                    for(int i = 0; i < 5; ++i){
                        switch(dealer[i]){
                            case 11:
                                dealerRevision[i] = "Jack";
                                break;
                            case 12:
                                dealerRevision[i] = "Queen";
                                break;
                            case 13:
                                dealerRevision[i] = "King";
                                break;
                            case 1:
                                dealerRevision[i] = "Ace";
                                break;
                            default:
                                dealerRevision[i] = dealer[i].ToString();
                                break;
                        }
                    }

                    Console.WriteLine("The flop cards are:\n\n\t{0},\t{1}\t{2}",dealerRevision[0], dealerRevision[1], dealerRevision[2] );


                        //start betting
                        Console.WriteLine("The small blind is: {0}")
                        

                    break;
                }

                        author.pause();
                        Console.Clear();
                    }
                    else if (cardGame == "2")
                    {
                        Console.WriteLine("2");
                    }
                    else
                    {
                        continue;
                        Console.Clear();
                    }

                }
            }
        }
    }

