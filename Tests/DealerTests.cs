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
    public class DealerTests
    {
        [TestMethod]
        public void DealWholeDeck()
        {
            var dealer = new Dealer();
            var cards = dealer.Deal(52);
            Assert.AreEqual(cards.Count, 52);
        }

        [TestMethod]
        public void DealsTwoCards()
        {
            var dealer = new Dealer();
            var cards = dealer.Deal(2);
            Assert.AreEqual(cards.Count, 2);
        }

        [TestMethod]
        public void DealsShouldBeRandomCards()
        {
            var dealer = new Dealer();
            var cards = dealer.Deal(2);

            var anotherDealer = new Dealer();
            var otherCards = anotherDealer.Deal(2);

            Assert.IsFalse(cards.SequenceEqual(otherCards));
        }

        [TestMethod]
        public void RemovesDealtCardsFromDeck()
        {
            var dealer = new Dealer();
            var cards = dealer.Deal(2);
            Assert.IsFalse(dealer.Deck.Cards.Contains(cards[0]));
            Assert.IsFalse(dealer.Deck.Cards.Contains(cards[1]));
        }

        [TestMethod]
        public void ToStringReturnsDealerName()
        {
            var dealer = new Dealer();
            Assert.AreEqual(dealer.ToString(), dealer.Name);
        }
    }
}
