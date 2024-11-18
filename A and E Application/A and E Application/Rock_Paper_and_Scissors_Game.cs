using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_and_E_Application
{
    public partial class Rock_Paper_and_Scissors_Game : Form
    {

        int rounds = 3;
        int timerPerRound = 4;
        bool gameOver = false;

        string[] CPUchoiceList = { "rock", "paper", "scissor", "paper", "scissor", "rock" };

        int randomNumber = 0;

        Random rnd = new Random();

        string CPUChoice;

        string playerChoice;

        int PlayerScore;
        int CPUScore;


        public Rock_Paper_and_Scissors_Game()
        {
            InitializeComponent();

            countDownTimer.Enabled = true;

            playerChoice = "none";

            txtCountDown.Text = "5";
        }

        private void Rock_Paper_and_Scissors_Game_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PlayerScore = 0;
            CPUScore = 0;
            rounds = 3;

            txtScore.Text = "Player: " + PlayerScore + " - " + "CPU: " + CPUScore;

            playerChoice = "none";

            countDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.QuestionMark1;
            picCPU.Image = Properties.Resources.QuestionMark1;

            gameOver = false;

        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.Rock;
            playerChoice = "rock";
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.Paper;
            playerChoice = "paper";
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.Scissors;
            playerChoice = "scissor";
        }

        private void countDownTimerEvent(object sender, EventArgs e)
        {
            timerPerRound -= 1;

            txtCountDown.Text = timerPerRound.ToString();

            txtRounds.Text = "Rounds: " + rounds;

            if (timerPerRound < 1)
            {
                countDownTimer.Enabled = false;

                timerPerRound = 4;

                randomNumber = rnd.Next(0, CPUchoiceList.Length);

                CPUChoice = CPUchoiceList[randomNumber];

                if (rounds > 0)
                {

                    switch (CPUChoice)
                    {
                        case "rock":
                            picCPU.Image = Properties.Resources.Rock;
                            break;

                        case "paper":
                            picCPU.Image = Properties.Resources.Paper;
                            break;

                        case "scissor":
                            picCPU.Image = Properties.Resources.Scissors;
                            break;
                    }
                }

                if (rounds > 0)
                {
                    checkGame();
                }
                else
                {
                    if (PlayerScore > CPUScore)
                    {
                        MessageBox.Show("Player won the match!");
                    }
                    else
                    {
                        MessageBox.Show("CPU won the match!");
                    }

                    gameOver = true;
                }

            }


        }


        private void checkGame()
        {
            if (playerChoice == "rock" && CPUChoice == "paper")
            {
                CPUScore += 1;

                rounds -= 1;

                MessageBox.Show("CPU Wins, Paper covers Rock.");
            }

            else if (playerChoice == "scissor" && CPUChoice == "rock")
            {
                CPUScore += 1;

                rounds -= 1;

                MessageBox.Show("CPU Wins, Rock breaks Scissor.");
            }

            else if (playerChoice == "paper" && CPUChoice == "scissor")
            {
                CPUScore += 1;

                rounds -= 1;

                MessageBox.Show("CPU Wins, Scissor cuts Paper.");
            }

            else if (playerChoice == "rock" && CPUChoice == "scissor")
            {
                PlayerScore += 1;

                rounds -= 1;

                MessageBox.Show("Player Wins, Rock breaks Scissor.");
            }

            else if (playerChoice == "paper" && CPUChoice == "rock")
            {
                PlayerScore += 1;

                rounds -= 1;

                MessageBox.Show("Player Wins, Paper covers Rock.");
            }

            else if (playerChoice == "scissor" && CPUChoice == "paper")
            {
                PlayerScore += 1;

                rounds -= 1;

                MessageBox.Show("Player Wins, Scissor cuts Paper.");
            }

            else if (playerChoice == "none")
            {
                MessageBox.Show("Make a choice!");
            }

            else
            {
                MessageBox.Show("It is a draw!");
            }

            startNextRound();
        }


        private void startNextRound()
        {
            if (gameOver == true)
            {
                return;
            }
            
                txtScore.Text = "Player: " + PlayerScore + " - " + "CPU: " + CPUScore;

                playerChoice = "none";

                countDownTimer.Enabled = true;

                picPlayer.Image = Properties.Resources.QuestionMark1;
                picCPU.Image = Properties.Resources.QuestionMark1;
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            new main().Show();
            this.Close();
        }
    }
}
