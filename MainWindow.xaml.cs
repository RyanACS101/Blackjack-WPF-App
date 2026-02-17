using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackjackApp
{

    public partial class MainWindow : Window
    {
        // Variables for game
        Deck deck;
        Hand playerHand;
        Hand dealerHand;

        int playerWins = 0;
        int dealerWins = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        // Add Button
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

            deck = new Deck();
            playerHand = new Hand();
            dealerHand = new Hand();

            playerHand.AddCard(deck.Draw());
            playerHand.AddCard(deck.Draw());

            dealerHand.AddCard(deck.Draw());
            dealerHand.AddCard(deck.Draw());

            PlayerScoreText.Text = "Player: " + playerHand.GetScore();
            DealerScoreText.Text = "Dealer: " + dealerHand.GetScore();

            //
            StartButton.Visibility = Visibility.Collapsed;
            HitButton.Visibility = Visibility.Visible;
            StandButton.Visibility = Visibility.Visible;
            RestartButton.Visibility = Visibility.Collapsed;

         

        }

        // for hit button
        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            playerHand.AddCard(deck.Draw());

            int playerScore = playerHand.GetScore();

            PlayerScoreText.Text = "Player: " + playerScore;
            PlayerCardsText.Text = "Player Cards:\n" + GetCardsText(playerHand);

            PlayerCardsText.Text = "Player Cards:\n" + GetCardsText(playerHand);

            if (playerScore > 21)
            {
                MessageBox.Show("Bust! Dealer Wins");
                dealerWins++;
                LossText.Text = "Losses: " + dealerWins;


                //
                RestartButton.Visibility = Visibility.Visible;
                HitButton.Visibility = Visibility.Collapsed;
                StandButton.Visibility = Visibility.Collapsed;
            }

            

        }

        // for stand button
        private void StandButton_Click(object sender, RoutedEventArgs e)
        {
            // Dealer draws until 17 or more
            while (dealerHand.GetScore() < 17)
            {
                dealerHand.AddCard(deck.Draw());
            }

            int playerScore = playerHand.GetScore();
            int dealerScore = dealerHand.GetScore();

            PlayerCardsText.Text = "Player Cards:\n" + GetCardsText(playerHand);
            DealerScoreText.Text = "Dealer: " + dealerScore;
            if (playerScore > 21)
            {
                dealerWins++;
                MessageBox.Show("You Bust! Dealer Wins");
            }
            else if (dealerScore > 21)
            {
                playerWins++;
                MessageBox.Show("Dealer Busts! You Win");
            }
            else if (playerScore > dealerScore)
            {
                playerWins++;
                MessageBox.Show("You Win!");
            }
            else if (dealerScore > playerScore)
            {
                dealerWins++;
                MessageBox.Show("Dealer Wins!");
            }
            else
            {
                MessageBox.Show("Tie!");
            }

            WinText.Text = "Wins: " + playerWins;
            LossText.Text = "Losses: " + dealerWins;
            //
            RestartButton.Visibility = Visibility.Visible;
            HitButton.Visibility = Visibility.Collapsed;
            StandButton.Visibility = Visibility.Collapsed;

        }

        //
        private string GetCardsText(Hand hand)
        {
            string result = "";

            foreach (var card in hand.Cards)
            {
                result += card.ToString() + "\n";
            }

            return result;
        }

        //
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset UI
            PlayerScoreText.Text = "Player: 0";
            DealerScoreText.Text = "Dealer: 0";
            PlayerCardsText.Text = "Player Cards:";

            // Show start screen again
            StartButton.Visibility = Visibility.Visible;
            HitButton.Visibility = Visibility.Collapsed;
            StandButton.Visibility = Visibility.Collapsed;
            RestartButton.Visibility = Visibility.Collapsed;
        }



    }




}
