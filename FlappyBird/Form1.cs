using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 8;
        int score = 0;




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            

            scoreText.Text = "Score: " + score;

            // It is used for changing pipes size
            Random rnd = new Random();
            int pipeTopSize = rnd.Next(180, 250);
            

            if (pipeBottom.Left < -80)
            {
                pipeBottom.Left = 750 ; 
                score++;
            }

            if(pipeTop.Left < -80)
            {
                pipeTop.Left = 750;
                pipeTop.Size = new Size(100, pipeTopSize);
                score++;
            }

            if(flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || 
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25)
            {
                endGame();
            }

            // It is used for upgrade the flappybird's speed
            switch(score)
            {
                case 5:
                    pipeSpeed = 10;
                        break;
                case 8:
                    pipeSpeed = 12;
                    break;
                case 15:
                    pipeSpeed = 15;
                    break;
                case 20:
                    pipeSpeed = 17;
                    break;
                case 25:
                    pipeSpeed = 20;
                    break;
                case 35:
                    pipeSpeed = 23;
                    break;
                case 45:
                    pipeSpeed = 26;
                    break;
                case 60:
                    pipeSpeed = 30;
                    break;
                case 70:
                    pipeSpeed = 35;
                    break;
            }

            //if (score > 5)
            //{
            //    pipeSpeed = 15;
            //}

            

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 8;
            }
            if (e.KeyCode== Keys.Enter)
            {
                startGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -8;
            }
        }

        private void startGame()
        {
            gameTimer.Start();
            pipeSpeed = 8;
            gravity = 8;
            score = 0;
            restartText.Text = "";
            flappyBird.Location = new Point( 63 , 253);
            pipeTop.Location = new Point(841 , -4);
            pipeBottom.Location = new Point(777 , 399);
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!";
            restartText.Text = "press enter to restart";
        }

        private void flappyBird_Click(object sender, EventArgs e)
        {

        }
    }
}
