using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLibrary
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();
        public int Money { get; set; }
        public bool IsDealer { get; set; }
        
        public int Score()
        {
            int score = 0;
            foreach (var card in Cards)
                score += card.Value;

            if (score > 21) {
                var card = Cards.FirstOrDefault(c => c.Value == 11);

                if (card == null)
                    return score;
                else
                {
                    card.Value = 1;
                    return Score();
                }
            }
            else
                return score;
        }
    }
}
