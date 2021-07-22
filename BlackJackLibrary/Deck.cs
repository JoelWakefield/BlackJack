using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLibrary
{
    public static class Deck
    {
        public static List<Card> BuildDeck(int numberOfDecks)
        {
            List<Card> decks = new List<Card>();
            for (int i = 0; i < numberOfDecks; i++)
                decks.AddRange(BuildADeck().ToArray());
            return decks;
        }

        public static List<Card> Shuffle(this List<Card> deck)
        {
            List<Card> newDeck = new List<Card>();

            while (deck.Count > 0) {
                var rand = new Random();
                var i = rand.Next(deck.Count);
                newDeck.Add(deck[i]);
                deck.RemoveAt(i);
            }

            return newDeck;
        }

        public static Card GetCard(this List<Card> deck)
        {
            var rand = new Random();
            var i = rand.Next(deck.Count);
            var card = deck[i];
            deck.RemoveAt(i);
            return card;
        }

        private static List<Card> BuildADeck()
        {
            return new List<Card>() {
                new Card { Value = 11, Emoji = "U+1F0A1", Name="Ace", Suit = "♠" },
                new Card { Value = 11, Emoji = "U+1F0B1", Name="Ace", Suit = "♥" },
                new Card { Value = 11, Emoji = "U+1F0C1", Name="Ace", Suit = "♦" },
                new Card { Value = 11, Emoji = "U+1F0D1", Name="Ace", Suit = "♣" },

                new Card { Value = 2, Emoji = "U+1F0A2", Name="Two", Suit = "♠" },
                new Card { Value = 2, Emoji = "U+1F0B2", Name="Two", Suit = "♥" },
                new Card { Value = 2, Emoji = "U+1F0C2", Name="Two", Suit = "♦" },
                new Card { Value = 2, Emoji = "U+1F0D2", Name="Two", Suit = "♣" },

                new Card { Value = 3, Emoji = "U+1F0A3", Name="Three", Suit = "♠" },
                new Card { Value = 3, Emoji = "U+1F0B3", Name="Three", Suit = "♥" },
                new Card { Value = 3, Emoji = "U+1F0C3", Name="Three", Suit = "♦" },
                new Card { Value = 3, Emoji = "U+1F0D3", Name="Three", Suit = "♣" },

                new Card { Value = 4, Emoji = "U+1F0A4", Name="Four", Suit = "♠" },
                new Card { Value = 4, Emoji = "U+1F0B4", Name="Four", Suit = "♥" },
                new Card { Value = 4, Emoji = "U+1F0C4", Name="Four", Suit = "♦" },
                new Card { Value = 4, Emoji = "U+1F0D4", Name="Four", Suit = "♣" },

                new Card { Value = 5, Emoji = "U+1F0A5", Name="Five", Suit = "♠" },
                new Card { Value = 5, Emoji = "U+1F0B5", Name="Five", Suit = "♥" },
                new Card { Value = 5, Emoji = "U+1F0C5", Name="Five", Suit = "♦" },
                new Card { Value = 5, Emoji = "U+1F0D5", Name="Five", Suit = "♣" },

                new Card { Value = 6, Emoji = "U+1F0A6", Name="Six", Suit = "♠" },
                new Card { Value = 6, Emoji = "U+1F0B6", Name="Six", Suit = "♥" },
                new Card { Value = 6, Emoji = "U+1F0C6", Name="Six", Suit = "♦" },
                new Card { Value = 6, Emoji = "U+1F0D6", Name="Six", Suit = "♣" },

                new Card { Value = 7, Emoji = "U+1F0A7", Name="Seven", Suit = "♠" },
                new Card { Value = 7, Emoji = "U+1F0B7", Name="Seven", Suit = "♥" },
                new Card { Value = 7, Emoji = "U+1F0C7", Name="Seven", Suit = "♦" },
                new Card { Value = 7, Emoji = "U+1F0D7", Name="Seven", Suit = "♣" },

                new Card { Value = 8, Emoji = "U+1F0A8", Name="Eigth", Suit = "♠" },
                new Card { Value = 8, Emoji = "U+1F0B8", Name="Eigth", Suit = "♥" },
                new Card { Value = 8, Emoji = "U+1F0C8", Name="Eigth", Suit = "♦" },
                new Card { Value = 8, Emoji = "U+1F0D8", Name="Eigth", Suit = "♣" },

                new Card { Value = 9, Emoji = "U+1F0A9", Name="Nine", Suit = "♠" },
                new Card { Value = 9, Emoji = "U+1F0B9", Name="Nine", Suit = "♥" },
                new Card { Value = 9, Emoji = "U+1F0C9", Name="Nine", Suit = "♦" },
                new Card { Value = 9, Emoji = "U+1F0D9", Name="Nine", Suit = "♣" },

                new Card { Value = 10, Emoji = "U+1F0AA", Name="Ten", Suit = "♠" },
                new Card { Value = 10, Emoji = "U+1F0BA", Name="Ten", Suit = "♥" },
                new Card { Value = 10, Emoji = "U+1F0CA", Name="Ten", Suit = "♦" },
                new Card { Value = 10, Emoji = "U+1F0DA", Name="Ten", Suit = "♣" },
                                                          
                new Card { Value = 10, Emoji = "U+1F0AB", Name="Jack", Suit = "♠" },
                new Card { Value = 10, Emoji = "U+1F0BB", Name="Jack", Suit = "♥" },
                new Card { Value = 10, Emoji = "U+1F0CB", Name="Jack", Suit = "♦" },
                new Card { Value = 10, Emoji = "U+1F0DB", Name="Jack", Suit = "♣" },

                new Card { Value = 10, Emoji = "U+1F0AD", Name="Queen", Suit = "♠" },
                new Card { Value = 10, Emoji = "U+1F0BD", Name="Queen", Suit = "♥" },
                new Card { Value = 10, Emoji = "U+1F0CD", Name="Queen", Suit = "♦" },
                new Card { Value = 10, Emoji = "U+1F0DD", Name="Queen", Suit = "♣" },

                new Card { Value = 10, Emoji = "U+1F0AC", Name="King", Suit = "♠" },
                new Card { Value = 10, Emoji = "U+1F0BC", Name="King", Suit = "♥" },
                new Card { Value = 10, Emoji = "U+1F0CC", Name="King", Suit = "♦" },
                new Card { Value = 10, Emoji = "U+1F0DC", Name="King", Suit = "♣" }
            };
        }
    }
}
