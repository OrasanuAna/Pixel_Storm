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
    public partial class SpaceRunner : Form
    {
        bool jumping = false;
        int jumpSpeed;
        int force = 12;
        int score = 0;
        int obstacleSpeed = 15;
        Random rand = new Random();
        int position;
        bool isGameOver = false;


        public SpaceRunner()
        {
            InitializeComponent();

            GameReset();
        }

        private void SpaceRunner_Load(object sender, EventArgs e)
        {

        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            SpaceRunnerCharacter.Top += jumpSpeed;

            txtScore.Text = "Score: " + score;

            if(jumping == true && force < 0)
            {
                jumping = false;
            }

            if(jumping == true)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }

            if(SpaceRunnerCharacter.Top > 366 && jumping == false)
            {
                force = 12;
                SpaceRunnerCharacter.Top = 367;
                jumpSpeed = 0;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed;

                    if(x.Left < - 100)
                    {
                        x.Left = this.ClientSize.Width + rand.Next(200, 500) + (x.Width * 15);
                        score = score + 1;
                    }

                    if(SpaceRunnerCharacter.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameTimer.Stop();
                        SpaceRunnerCharacter.Image = Properties.Resources.SpaceRunnerCharacterDead;
                        txtScore.Text += " Press R to restart the game!";
                        isGameOver = true;
                    }
                }
            }

            if(score == 10)
            {
                obstacleSpeed = 20;
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if(jumping == true)
            {
                jumping = false;
            }

            if(e.KeyCode == Keys.R && isGameOver == true)
            {
                GameReset();
            }

            if (e.KeyCode == Keys.E)
            {
                new main().Show();
                this.Close();
            }
        }

        private void GameReset()
        {
            force = 12;
            jumpSpeed = 0;
            jumping = false;
            score = 0;
            obstacleSpeed = 10;
            txtScore.Text = "Score: " + score;
            SpaceRunnerCharacter.Image = Properties.Resources.SpaceRunnerCharacter;
            isGameOver = false;
            SpaceRunnerCharacter.Top = 367;

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "obstacle")
                {
                    position = this.ClientSize.Width + rand.Next(100, 2000) + (x.Width * 10);

                    x.Left = position;
                }
            }

            gameTimer.Start();

        }
    }
}
