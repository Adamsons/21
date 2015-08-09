using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack2JudgementDay;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void GetScoreReturnsCorrectValue()
        {
            var player = new Player();

            var cards = new Card()
            {
                Suit = CardSuit.Heart,
                Type = CardType.Ace,
                Value = 1
            };

            player.AddToHand(cards);
            Assert.AreEqual(player.GetScore(), 1);
        }

        [TestMethod]
        public void ToStringReturnsPlayerName()
        {
            var player = new Player();
            Assert.AreEqual(player.ToString(), player.Name);
        }

        [TestMethod]
        public void PlayerIsBust()
        {
            var cards = new List<Card>()
            {
                new Card() { Suit = CardSuit.Diamond, Type = CardType.Queen, Value = 10 },
                new Card() { Suit = CardSuit.Heart, Type = CardType.Number, Value = 7 },
                new Card() { Suit = CardSuit.Spade, Type = CardType.King, Value = 10 }
            };

            var player = new Player();
            player.AddToHand(cards);

            var score = player.GetScore();
            Assert.IsTrue(player.IsBust);
        }

        [TestMethod]
        public void PlayerIsBustButHasAnAceChangeAceValue()
        {
            var cards = new List<Card>()
            {
                new Card() { Suit = CardSuit.Diamond, Type = CardType.Queen, Value = 10 },
                new Card() { Suit = CardSuit.Heart, Type = CardType.Number, Value = 7 },
                new Card() { Suit = CardSuit.Spade, Type = CardType.Ace, Value = 11 }
            };

            var player = new Player();
            player.AddToHand(cards);

            var score = player.GetScore();

            Assert.IsTrue(score < 21);
            Assert.IsFalse(player.IsBust);
        }
    }
}
