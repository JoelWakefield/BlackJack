using System;
using System.Collections.Generic;
using System.Text;
using BlackJackLibrary;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("♥ WELCOME ♦ TO ♣ BLACKJACK ♠");
            Run();
            Console.WriteLine("The house always wins... ;)");
            Console.ReadLine();
        }

        public static void Run()
        {
            //  Set constants
            const int BUY_IN = 5;
            
            //  Build deck
            var deck = Deck.BuildDeck(1);

            //  Make players
            var player = new Player
            {
                Name = "me",
                Money = 100
            };

            var dealer = new Player
            {
                Name = "dealer",
                IsDealer = true
            };

            //  Create table
            Table table = new Table
            {
                Players =
                {
                    player,
                    dealer
                },
                Deck = deck,
                Bet = BUY_IN
            };

            bool first = true;

            do
            {
                //  Prompt
                Console.WriteLine($"How bout a{(first ? "" : "nother")} round? (Press the (q) key to quit)");
                first = false;

                //  Exit?
                var input = Console.ReadLine();
                if (input.ToLower() == "q")
                    break;

                //  Check money
                Console.Write("Taking bets... ");
                table.TakeBets();

                //  Randomize deck
                Console.Write("Shuffling deck... ");
                table.Deck = table.Deck.Shuffle();

                //  Deal cards
                Console.Write("Dealing cards... ");
                table.DealCards();

                //  Play a round
                Console.WriteLine();
                table.Round();

                //  Settle the score
                table.Evaluate();

                //  Clear cards
                Console.WriteLine("Clearing the table...");
                table.ClearCards();
            } while (true);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"You walk away with ${player.Money}.\n");
            Console.ResetColor();
        }
    }
}
