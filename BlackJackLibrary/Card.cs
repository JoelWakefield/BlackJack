using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLibrary
{
    public class Card
    {
        public int Value { get; set; }
        public string Emoji { get; set; }
        public string Name { get; set; }
        public string Suit { get; set; }
        public bool IsHidden { get; set; }

        public string Show() => $"{(IsHidden ? "? of ?" : $"{Name} of {Suit} ({Value})")}";
    }
}
