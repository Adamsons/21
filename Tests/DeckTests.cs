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
    public class DeckTests
    {
        [TestMethod]
        public void ShouldHave52Cards()
        {
            var deck = new Deck();
            Assert.AreEqual(deck.Cards.Count, 52);
        }

        [TestMethod]
        public void EachSuitShouldHave13Cards()
        {
            var deck = new Deck();
            Assert.AreEqual(deck.Cards.Count(o => o.Suit == CardSuit.Club), 13);
            Assert.AreEqual(deck.Cards.Count(o => o.Suit == CardSuit.Diamond), 13);
            Assert.AreEqual(deck.Cards.Count(o => o.Suit == CardSuit.Heart), 13);
            Assert.AreEqual(deck.Cards.Count(o => o.Suit == CardSuit.Spade), 13);
        }

        [TestMethod]
        public void ShouldContain4OfEachSpecialType()
        {
            var deck = new Deck();
            Assert.AreEqual(deck.Cards.Count(o => o.Type == CardType.Ace), 4);
            Assert.AreEqual(deck.Cards.Count(o => o.Type == CardType.Jack), 4);
            Assert.AreEqual(deck.Cards.Count(o => o.Type == CardType.King), 4);
            Assert.AreEqual(deck.Cards.Count(o => o.Type == CardType.Queen), 4);
        }

        [TestMethod]
        public void ShuffleChangesElementsOrder()
        {
            var deck = new Deck();
            deck.Shuffle();

            var cards = deck.Cards.ToList();
            deck.Shuffle();
            Assert.IsFalse(cards.SequenceEqual(deck.Cards));
        }
    }
}
