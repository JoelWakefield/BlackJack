using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJackLibrary
{
    public class Table
    {
        public List<Player> Players { get; set; } = new List<Player>();

        public List<Card> Deck { get; set; } = new List<Card>();

        public int Bet { get; set; }

        public void TakeBets()
        {
            foreach (var player in Players)
            {
                if (player.IsDealer)
                    continue;

                if (player.Money < Bet)
                {
                    Console.WriteLine($"You're broke {player.Name} - and outta here.");
                    Players.Remove(player);
                }
                else
                {
                    player.Money -= Bet;
                }
            }
        }

        public void DealCards()
        {
            //  First card for each player
            foreach (var player in Players)
            {
                player.Cards.Add(Deck.GetCard());
                if (player.IsDealer)
                    player.Cards.Last().IsHidden = true;
            }

            //  Second card for each player
            foreach (var player in Players)
                player.Cards.Add(Deck.GetCard());
        }

        public void ClearCards()
        {
            //  Remove cards from the table
            foreach (var player in Players)
                player.Cards.Clear();
        }

        public void Round()
        {
            //  Each player gets a turn, ending with dealer
            foreach (var player in Players)
                Turn(player);
        }

        private void Turn(Player player)
        {
            Console.WriteLine($"> {player.Name}'s turn");
            bool playing = true;

            //  reveal dealer card
            if (player.IsDealer)
                foreach (var card in player.Cards)
                    card.IsHidden = false;

            do
            {
                //  evaluate hand
                var score = player.Score();

                //  show hand
                ShowCards();

                //  boot if busted
                if (score > 21)
                {
                    Console.WriteLine("  Bust!");
                    break;
                }

                //  if 21 - end turn
                if (score == 21)
                {
                    Console.WriteLine("  Blackjack!");
                    break;
                }

                //  else hit, pass, or show
                Console.Write($"What does {player.Name} do? (hit or stay)\t");

                //  make decision
                string input;
                if (player.IsDealer)
                {
                    Thread.Sleep(1400);
                    input = score < 17 ? "hit" : "stay";
                    Console.Write($"{input}\n");
                }
                else
                    input = Console.ReadLine();

                //  handle decision
                switch (input.ToLower())
                {
                    case "hit":
                        player.Cards.Add(Deck.GetCard());
                        break;
                    case "stay":
                        playing = false;
                        break;
                    default:
                        Console.WriteLine("That's not an option.");
                        break;
                }
            } while (playing);
        }

        private void ShowCards()
        {
            Console.OutputEncoding = Encoding.UTF8;
            foreach (var player in Players)
            {
                Console.Write($"  {player.Name}'s hand:\t");
                foreach (var card in player.Cards)
                    Console.Write($"{card.Show()}\t");
                Console.WriteLine();
            }
        }

        public void Evaluate()
        {
            //  Evaluate scores and distribute money
            var dealerScore = Players.FirstOrDefault(p => p.IsDealer).Score();

            if (dealerScore > 21)
                Console.WriteLine($"Dealer busted...");
            else
                Console.WriteLine($"Dealer scored {dealerScore}.");

            foreach (var player in Players)
            {
                if (player.IsDealer)
                    continue;

                var playerScore = player.Score();

                string msg = $"{player.Name} ";
                if (playerScore > 21)
                {
                    msg += "busted...";
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    msg += $"scored {playerScore}.";

                    if (dealerScore > 21 || playerScore > dealerScore)
                    {
                        player.Money += Bet * 2;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (playerScore == dealerScore)
                    {
                        player.Money += Bet;
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                }


                Console.WriteLine($"{msg} ${player.Money} left in the wallet.");
                Console.ResetColor();
            }
        }
    }
}
