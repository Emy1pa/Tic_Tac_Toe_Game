using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class mainForm : Form
    {
        stGameStatus GameStatus;

        enPlayer PlayerTurn = enPlayer.Player1;

        enum enPlayer { Player1, Player2 };

        enum enWinner { Player1, Player2, Draw, GameInProgress };

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        }

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            lblTitle.ForeColor = Color.FromArgb(57, 13, 130);
            lblTitle.BackColor = Color.FromArgb(249, 213, 94);

            gbTurn.BackColor = Color.FromArgb(249, 213, 94);
            lblPlayer.ForeColor = Color.FromArgb(57, 13, 130);

            gbWinner.BackColor = Color.FromArgb(249, 213, 94);
            lblCheckWinner.ForeColor = Color.FromArgb(57, 13, 130);

            btnRestartGame.ForeColor = Color.FromArgb(57, 13, 130);
            btnRestartGame.BackColor = Color.FromArgb(249, 213, 94);



            button1.BackColor = Color.FromArgb(57, 13, 130);
            button2.BackColor = Color.FromArgb(57, 13, 130);
            button3.BackColor = Color.FromArgb(57, 13, 130);
            button4.BackColor = Color.FromArgb(57, 13, 130);
            button5.BackColor = Color.FromArgb(57, 13, 130);
            button6.BackColor = Color.FromArgb(57, 13, 130);
            button7.BackColor = Color.FromArgb(57, 13, 130);
            button8.BackColor = Color.FromArgb(57, 13, 130);
            button9.BackColor = Color.FromArgb(57, 13, 130);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Color Black = Color.FromArgb(249, 213, 94);
            Pen pen = new Pen(Black);
            pen.Width = 10;


            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 342, 241, 1077, 241);
            e.Graphics.DrawLine(pen, 342, 400, 1077, 400);

            e.Graphics.DrawLine(pen, 587, 120, 587, 520);
            e.Graphics.DrawLine(pen, 832, 120, 832, 520);




        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //this.Text = "X: " + e.X + " Y: " + e.Y;
        }

        void EndGame()
        {
            lblPlayer.Text = "Game Over!";
            switch (GameStatus.Winner) { 

                case enWinner.Player1:
                    lblCheckWinner.Text = "Player 1 Wins";
                    break;
                case enWinner.Player2:
                    lblCheckWinner.Text = "Player 2 Wins";
                    break;
                default:
                    lblCheckWinner.Text = "Draw!";
                    break;

            }

            MessageBox.Show("Game Over! " , "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool CheckButtonsValues(Button btn1, Button btn2, Button btn3) { 
        
            if(btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if(btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                } else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }

            GameStatus.GameOver = false;
            return false;
        }

        public void CheckWinner()
        {
            if (CheckButtonsValues(button1, button2, button3))
                return;
            if (CheckButtonsValues(button4, button5, button6))
                return;
            if (CheckButtonsValues(button7, button8, button9))
                return;
            if (CheckButtonsValues(button1, button4, button7))
                return;
            if (CheckButtonsValues(button2, button5, button8))
                return;
            if (CheckButtonsValues(button3, button6, button9))
                return;
            if (CheckButtonsValues(button1, button5, button9))
                return;
            if (CheckButtonsValues(button3, button5, button7))
                return;
        }

        public void ChangeImage(Button btn) {
            if(btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Properties.Resources.X2;
                        PlayerTurn = enPlayer.Player2;
                        lblPlayer.Text = "Player 2";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Properties.Resources.O2;
                        PlayerTurn = enPlayer.Player1;
                        lblPlayer.Text = "Player 1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;

                }
            } else
            {
                MessageBox.Show("Invalid Move! Try Again.", "Wrong Choice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(GameStatus.PlayCount == 9 && !GameStatus.GameOver)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeImage(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeImage(button2);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeImage(button3);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeImage(button4);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangeImage(button5);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeImage(button6);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeImage(button7);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeImage(button8);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangeImage(button9);

        }

        private void ResetButtons(Button btn) {
            btn.Image = Properties.Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.FromArgb(57, 13, 130);
        }

        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            ResetButtons(button1);
            ResetButtons(button2);
            ResetButtons(button3);
            ResetButtons(button4);
            ResetButtons(button5);
            ResetButtons(button6);
            ResetButtons(button7);
            ResetButtons(button8);
            ResetButtons(button9);

            PlayerTurn = enPlayer.Player1;
            lblPlayer.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lblCheckWinner.Text = "In Progress";
        }

       
    }
}
