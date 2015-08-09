using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack2JudgementDay
{
    public class Card
    {
        public CardSuit Suit { get; set; }
        public CardType Type { get; set; }
        public int Value { get; set; }
        
        public override string ToString()
        {
            string cardFace = "";

            if (Type == CardType.Number)
                cardFace = Value.ToString();
            else
                cardFace = Type.ToString();

            return String.Format("{0} of {1}s", cardFace, Suit.ToString());
        }
    }

    public enum CardType
    {
        Ace,
        King,
        Queen,
        Jack,
        Number
    }

    public enum CardSuit
    {
        Heart,
        Diamond,
        Club,
        Spade
    }
}
