using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack2JudgementDay
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = CreateDeck();
            Shuffle();
        }

        public void Shuffle()
        {
            var random = new Random();

            for (int n = 0; n < Cards.Count; n++)
            {
                var i = random.Next(Cards.Count);

                var card = Cards[n];
                Cards[n] = Cards[i];
                Cards[i] = card;
            }
        }

        private List<Card> CreateDeck()
        {
            var cards = new List<Card>();

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                cards.AddRange(CreateSuit(suit));

            return cards;
        }

        private List<Card> CreateSuit(CardSuit suit)
        {
            var cards = new List<Card>();

            for (int i = 1; i < 14; i++)
            {
                if (i == 1)
                    cards.Add(CreateCard(11, suit, CardType.Ace));

                if (i > 1 && i < 11)
                    cards.Add(CreateCard(i, suit, CardType.Number));

                if (i == 11)
                    cards.Add(CreateCard(10, suit, CardType.Jack));

                if (i == 12)
                    cards.Add(CreateCard(10, suit, CardType.Queen));

                if (i == 13)
                    cards.Add(CreateCard(10, suit, CardType.King));
            }

            return cards;
        }

        private Card CreateCard(int value, CardSuit suit, CardType type)
        {
            return new Card()
            {
                Value = value,
                Suit = suit,
                Type = type
            };
        }
    }
}
