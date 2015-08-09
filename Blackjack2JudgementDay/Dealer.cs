using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack2JudgementDay
{
    public class Dealer : Player
    {
        public Deck Deck { get; set; }

        public Dealer()
        {
            Deck = new Deck();
            Name = "Dealer";
        }

        public List<Card> Deal(int amount)
        {
            var random = new Random();
            var cardsToDeal = new List<Card>();

            for (int i = 0; i < amount; i++)
            {
                var card = Deck.Cards[random.Next(0, Deck.Cards.Count)];

                cardsToDeal.Add(card);
                Deck.Cards.Remove(card);
            }

            return cardsToDeal;
        }

        public override string ToString()
        {
            return "Dealer";
        }

        public bool HasSoftSeventeen()
        {
            return Deck.Cards.Any(o => o.Type == CardType.Ace) && GetScore() == 17;
        }
    }
}
