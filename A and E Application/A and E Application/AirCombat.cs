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
    public partial class AirCombat : Form
    {

        bool goLeft, goRight, shooting, isGameOver;
        int score;
        int playerSpeed = 12;
        int enemySpeed;
        int rocketSpeed;
        Random rnd = new Random();
    

        public AirCombat()
        {
            InitializeComponent();
            resetGame();
        }

        private void AirCombat_Load(object sender, EventArgs e)
        {

        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {

            txtScore.Text = score.ToString();

            enemyOne.Top += enemySpeed;
            enemyTwo.Top += enemySpeed;
            enemyThree.Top += enemySpeed;

            if(enemyOne.Top > 664 || enemyTwo.Top > 664 || enemyThree.Top > 664)
            {
                gameOver();
            }

            if(goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }

            if(goRight == true && player.Left < 699)
            {
                player.Left += playerSpeed;
            }

            if(shooting == true)
            {
                rocketSpeed = 20;
                rocket.Top -= rocketSpeed;
            }
            else
            {
                rocket.Left = -300;
                rocketSpeed = 0;
            }

            if(rocket.Top < -30)
            {
                shooting = false;
            }

            if(rocket.Bounds.IntersectsWith(enemyOne.Bounds))
            {
                score += 1;
                enemyOne.Top = -450;
                enemyOne.Left = rnd.Next(20, 600);
                shooting = false;
            }

            if (rocket.Bounds.IntersectsWith(enemyTwo.Bounds))
            {
                score += 1;
                enemyTwo.Top = -650;
                enemyTwo.Left = rnd.Next(20, 600);
                shooting = false;
            }

            if (rocket.Bounds.IntersectsWith(enemyThree.Bounds))
            {
                score += 1;
                enemyThree.Top = -750;
                enemyThree.Left = rnd.Next(20, 600);
                shooting = false;
            }

            if (score == 5)
            {
                enemySpeed = 10;
            }

            if(score == 10)
            {
                enemySpeed = 12;
            }

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }

            if(e.KeyCode == Keys.Right)
            {
                goRight = true;
            }

            if (e.KeyCode == Keys.E)
            {
                new main().Show();
                this.Close();
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if(e.KeyCode == Keys.Space && shooting == false)
            {
                shooting = true;
                rocket.Top = player.Top - 59;
                rocket.Left = player.Left + (player.Width / 2);
            }

            if(e.KeyCode == Keys.Enter && isGameOver == true)
            {
                resetGame();
            }
        }

        private void resetGame()
        {
            gameTimer.Start();
            enemySpeed = 6;

            enemyOne.Left = rnd.Next(20, 600);
            enemyTwo.Left = rnd.Next(20, 600);
            enemyThree.Left = rnd.Next(20, 600);

            enemyOne.Top = rnd.Next(0, 200) * -1;
            enemyTwo.Top = rnd.Next(0, 500) * -1;
            enemyThree.Top = rnd.Next(0, 900) * -1;

            score = 0;
            rocketSpeed = 0;
            rocket.Left = -300;
            shooting = false;


            txtScore.Text = score.ToString();
        }

        private void gameOver()
        {
            isGameOver = true;
            gameTimer.Stop();
            txtScore.Text += Environment.NewLine + "Game Over!" + Environment.NewLine + "Press Enter to restart the game." +
                             Environment.NewLine + "Press E if you want to exit the game.";

        }
    }
}
