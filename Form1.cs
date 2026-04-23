using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Project
{
    public partial class Form1 : Form
    {

        Pen pen = new Pen(Color.White, 7);

        int NumberOfMoves = 0;
        bool IsPlayer1Turn = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $"X: {e.X} Y:  {e.Y}";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Tic Tac Toe Game";
            this.BackColor = Color.Black;


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 395, 122, 395, 322);
            e.Graphics.DrawLine(pen, 500, 122, 500, 322);

            e.Graphics.DrawLine(pen, 330, 185, 570, 185);
            e.Graphics.DrawLine(pen, 330, 265, 570, 265);
        }


        private void pictureBox_Click(object sender, EventArgs e)
        {
            Check((PictureBox)sender, e);
        }
        //private void pictureBox1_Click(object sender, EventArgs e)
        //{
        //    Check(sender, e);
        //}

        //private void pictureBox2_Click(object sender, EventArgs e)
        //{
        //    Check(sender, e);
        //}

        //private void pictureBox3_Click(object sender, EventArgs e)
        //{
        //    Check(sender, e);
        //}

        //private void pictureBox4_Click(object sender, EventArgs e)
        //{
        //    Check(sender, e);
        //}

        //private void pictureBox5_Click(object sender, EventArgs e)
        //{
        //    Check(sender, e);
        //}

        //private void pictureBox6_Click(object sender, EventArgs e)
        //{
        //    Check(sender, e);
        //}

        //private void pictureBox7_Click(object sender, EventArgs e)
        //{
        //    Check(sender, e);
        //}

        //private void pictureBox8_Click(object sender, EventArgs e)
        //{
        //    Check(sender, e);
        //}

        //private void pictureBox9_Click(object sender, EventArgs e)
        //{
        //    Check(sender, e);
        //}

        private void Check(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Tag != "?")
            {
                MessageBox.Show("Wrong Choice", "Wirning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {
                if (IsPlayer1Turn)
                {
                    lbTurn.Text = "Turn O";
                    ((PictureBox)sender).Image = Properties.Resources.X;
                    ((PictureBox)sender).Tag = "X";
                }

                else
                {
                    lbTurn.Text = "Turn X";
                    ((PictureBox)sender).Image = Properties.Resources.O;
                    ((PictureBox)sender).Tag = "O";
                }
                IsPlayer1Turn = !IsPlayer1Turn;
            }

            NumberOfMoves++;
            CheckWinner();
        }

        private void CheckWinner()
        {
            if (CheckMatch(pictureBox1 , pictureBox2 , pictureBox3))
            {
                AnnounceWinner(pictureBox1.Tag.ToString());
                return;
            }

            if (CheckMatch(pictureBox4, pictureBox5, pictureBox6))
            {
                AnnounceWinner(pictureBox4.Tag.ToString());
                return;
            }

            if (CheckMatch(pictureBox7, pictureBox8, pictureBox9))
            {
                AnnounceWinner(pictureBox7.Tag.ToString());
                return;
            }

            if (CheckMatch(pictureBox1, pictureBox4, pictureBox7))
            {
                AnnounceWinner(pictureBox1.Tag.ToString());
                return;
            }
            if (CheckMatch(pictureBox2, pictureBox5, pictureBox8))
            {
                AnnounceWinner(pictureBox2.Tag.ToString());
                return;
            }
            if (CheckMatch(pictureBox3, pictureBox6, pictureBox9))
            {
                AnnounceWinner(pictureBox3.Tag.ToString());
                return;
            }
            if (CheckMatch(pictureBox1, pictureBox5, pictureBox9))
            {
                AnnounceWinner(pictureBox1.Tag.ToString());
                return;
            }
            if (CheckMatch(pictureBox3, pictureBox5, pictureBox7))
            {
                AnnounceWinner(pictureBox3.Tag.ToString());
                return;
            }

                if (NumberOfMoves == 9)
                {
                    AnnounceWinner("Draw");
                    return;
            }
        }

        bool CheckMatch(PictureBox p1, PictureBox p2, PictureBox p3)
        {
            if (p1.Tag.ToString() != "?" &&
                p1.Tag.ToString() == p2.Tag.ToString() &&
                p2.Tag.ToString() == p3.Tag.ToString())
            {
                p1.BackColor = p2.BackColor = p3.BackColor = Color.GreenYellow;
                return true;
            }
            return false;
        }

        private void AnnounceWinner(string Winner)
        {
            lbWinner(Winner);
        }

        private void lbWinner(string Winner)
        {
            if (Winner == "X")
            {
                lbWinnerText.Text = "X Wins!";
                MessageBox.Show($"Player {Winner} Wins", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if(Winner == "O")
            {
                lbWinnerText.Text = "O Wins!";
                MessageBox.Show($"Player {Winner} Wins", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                lbWinnerText.Text = "Draw!";
                MessageBox.Show("Game Over");

            }
            Reset();

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            pictureBox1.Image = pictureBox2.Image = pictureBox3.Image =
                pictureBox4.Image = pictureBox5.Image = pictureBox6.Image =
                pictureBox7.Image = pictureBox8.Image = pictureBox9.Image = Properties.Resources.question_mark_96;
            pictureBox1.Tag = pictureBox2.Tag = pictureBox3.Tag =
                pictureBox4.Tag = pictureBox5.Tag = pictureBox6.Tag =
                pictureBox7.Tag = pictureBox8.Tag = pictureBox9.Tag = "?";

                pictureBox1.BackColor = pictureBox2.BackColor = pictureBox3.BackColor =
                pictureBox4.BackColor = pictureBox5.BackColor = 
                pictureBox6.BackColor = pictureBox7.BackColor = 
                pictureBox8.BackColor = pictureBox9.BackColor = Color.Black;


            IsPlayer1Turn = true;
            NumberOfMoves = 0;
            lbTurn.Text = "Turn X";
            lbWinnerText.Text = "in Progress";
        }
    }
}
