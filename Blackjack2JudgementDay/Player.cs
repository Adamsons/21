using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack2JudgementDay
{
    public class Player
    {
        private List<Card> Hand { get; set; }
        public bool IsBust { get; set; }
        public bool Stand { get; set; }

        public string Name { get; set; }

        public Player()
        {
            Hand = new List<Card>();
            Name = "Player";
        }

        public Player(string name)
        {
            Name = name;
        }

        public List<Card> GetHand()
        {
            return Hand;
        } 

        public void AddToHand(Card card)
        {
            Hand.Add(card);
        }

        public void AddToHand(List<Card> cards)
        {
            Hand.AddRange(cards);
        }

        public int GetScore()
        {
            var score = Hand.Sum(o => o.Value);

            if (PlayerIsBustButHasAnAce(score))
            {
                ChangeAceValueToOne();
                score = Hand.Sum(o => o.Value);
            }
            else if (PlayerIsBust(score))
            {
                IsBust = true;
            }

            return score;
        }

        private bool PlayerIsBustButHasAnAce(int score)
        {
            return PlayerIsBust(score) && Hand.Any(o => o.Type == CardType.Ace);
        }

        private bool PlayerIsBust(int score)
        {
            return score > 21;
        }

        private void ChangeAceValueToOne()
        {
            Hand.First(o => o.Type == CardType.Ace).Value = 1;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
