using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack2JudgementDay
{
    public class Game
    {
        private Dealer Dealer { get; set; }
        private Player Player { get; set; }

        public void Init()
        {
            Dealer = new Dealer();
            Player = new Player();

            Player.AddToHand(Dealer.Deal(2));
            Dealer.AddToHand(Dealer.Deal(1));

            WritePlayersState(Player);
            WritePlayersState(Dealer);

            HitOrStand();
        }

        public void HitOrStand()
        {
            WriteHitOrStandToConsole();

            var userChoice = Console.ReadLine();

            if (userChoice != null && !String.IsNullOrEmpty(userChoice))
            {
                switch (userChoice.ToLower())
                {
                    case "hit": PlayerHits(Player); break;
                    case "stand": PlayerStands(Player); break;
                }
            }
        }

        public void PlayerHits(Player player)
        {
            Hit(player);

            if (!player.IsBust)
                HitOrStand();
            else
                PlayDealer();
        }

        public void PlayerStands(Player player)
        {
            Stand(player);
            PlayDealer();
        }

        public void PlayDealer()
        {
            if (Dealer.GetScore() >= 17 && !Dealer.HasSoftSeventeen()) 
            {
                Stand(Dealer);
                ScoreGame();
            }
            else
            {
                Hit(Dealer);
                PlayDealer();
            }
        }

        public void ScoreGame()
        {
            var playerScore = Player.GetScore();
            var dealerScore = Dealer.GetScore();

            if (Player.IsBust)
                WriteWins(Dealer);
            else if (Dealer.IsBust)
                WriteWins(Player);
            else if (playerScore == dealerScore)
                WriteLine("The game ends in a draw!");
            else
                WriteWins(Player.GetScore() > Dealer.GetScore() ? Player : Dealer);

            Console.ReadLine();
        }

        public void Hit(Player player)
        {
            player.AddToHand(Dealer.Deal(1));
            WritePlayersState(player);
        }

        public void Stand(Player player)
        {
            player.Stand = true;
            WriteLine(player.ToString() + " has finished with " + player.GetScore());
        }

        private void WriteWins(Player player)
        {
            WriteLine(String.Format("{0} wins!", player.ToString()));
        }

        private void WritePlayersState(Player player)
        {
            WritePlayerHasMessageToConsole(player);
            WriteHandToConsole(player.GetHand());
            WriteScoreToConsole(player, player.GetScore());

            if (player.IsBust)
            {
                WriteIsBust(player);
            }
        }

        public void WriteIsBust(Player player)
        {
            WriteLine(String.Format("{0} is Bust!", player.ToString()));
        }

        private void WritePlayerHasMessageToConsole(Player player)
        {
            LineBreak();
            WriteLine(String.Format("{0} has: ", player.ToString()));
        }

        private void WriteHandToConsole(List<Card> hand)
        {
            foreach (var card in hand)
                WriteLine(card.ToString());
        }

        private void WriteScoreToConsole(Player player, int score)
        {
            WriteLine(String.Format("{0}s score is: {1}", player.ToString(), score));
            LineBreak();
        }

        private void WriteHitOrStandToConsole()
        {
            WriteLine("Hit or stand?");
            LineBreak();
        }

        private void LineBreak()
        {
            Console.WriteLine();
        }

        private void WriteLine(string line)
        {
            Console.WriteLine(" " + line);
        }
    }
}
