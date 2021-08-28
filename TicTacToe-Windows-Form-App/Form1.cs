using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_Windows_Form_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String[] gameBoard = new string[9];
        bool[] boardActive = new bool[9];
        int currentMove = 0;

        public String returnSymbol(int move)
        {
            if (move % 2 == 0) return "O";
            else return "X";
        }

        public Color btnColorChange(String symbol)
        {
            if (symbol.Equals("O")) return Color.LightGoldenrodYellow;
            else if (symbol.Equals("X")) return Color.LightGreen;

            return System.Drawing.Color.White;
        }

        public void result()
        {
            for (int i = 0; i < 8; i++)
            {
                String comb = "";
                int x = 0, y = 0, z = 0;

                if (i == 0)
                {
                    comb = gameBoard[0] + gameBoard[4] + gameBoard[8];
                    x = 0;
                    y = 4;
                    z = 8;
                }
                else if (i == 1)
                {
                    comb = gameBoard[2] + gameBoard[4] + gameBoard[6];
                    x = 2;
                    y = 4;
                    z = 6;
                }
                else if (i == 2)
                {
                    comb = gameBoard[0] + gameBoard[1] + gameBoard[2];
                    x = 0;
                    y = 1;
                    z = 2;
                }
                else if (i == 3)
                {
                    comb = gameBoard[3] + gameBoard[4] + gameBoard[5];
                    x = 3;
                    y = 4;
                    z = 5;
                }
                else if (i == 4)
                {
                    comb = gameBoard[6] + gameBoard[7] + gameBoard[8];
                    x = 6;
                    y = 7;
                    z = 8;
                }
                else if (i == 5)
                {
                    comb = gameBoard[0] + gameBoard[3] + gameBoard[6];
                    x = 0;
                    y = 3;
                    z = 6;
                }
                else if (i == 6)
                {
                    comb = gameBoard[1] + gameBoard[4] + gameBoard[7];
                    x = 1;
                    y = 4;
                    z = 7;
                }
                else if (i == 7)
                {
                    comb = gameBoard[2] + gameBoard[5] + gameBoard[8];
                    x = 2;
                    y = 5;
                    z = 8;
                }

                if (comb.Equals("OOO"))
                {
                    changeColor(x);
                    changeColor(y);
                    changeColor(z);

                    for (int j = 0; j < 9; j++)
                        if (!boardActive[j]) buttonDisable(j + 1);

                    MessageBox.Show("O has won the game!", "Congratulations to the winner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (comb.Equals("XXX"))
                {
                    changeColor(x);
                    changeColor(y);
                    changeColor(z);

                    for (int j = 0; j < 9; j++)
                        if (!boardActive[j]) buttonDisable(j + 1);

                    MessageBox.Show("X has won the game!", "Congratulations to the winner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else isDraw();
            }
        }

        public void buttonDisable(int buttonNumber)
        {
            if (buttonNumber == 1) button1.Enabled = false;
            else if (buttonNumber == 2) button2.Enabled = false;
            else if (buttonNumber == 3) button3.Enabled = false;
            else if (buttonNumber == 4) button4.Enabled = false;
            else if (buttonNumber == 5) button5.Enabled = false;
            else if (buttonNumber == 6) button6.Enabled = false;
            else if (buttonNumber == 7) button7.Enabled = false;
            else if (buttonNumber == 8) button8.Enabled = false;
            else if (buttonNumber == 9) button9.Enabled = false;
        }

        public void isDraw()
        {
            int count = 0;
            foreach (String str in gameBoard)
            {
                if (str != null) count++;
                if (count == 9)
                {
                    resetGame();
                    MessageBox.Show("This is a draw!", "No winner found!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public void resetGame()
        {
            for (int i = 0; i < 9; i++) boardActive[i] = false;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;

            gameBoard = new string[9];
            currentMove = 0;
        }

        public void changeColor(int number)
        {
            if (number == 0) button1.BackColor = Color.Red;
            else if (number == 1) button2.BackColor = Color.Red;
            else if (number == 2) button3.BackColor = Color.Red;
            else if (number == 3) button4.BackColor = Color.Red;
            else if (number == 4) button5.BackColor = Color.Red;
            else if (number == 5) button6.BackColor = Color.Red;
            else if (number == 6) button7.BackColor = Color.Red;
            else if (number == 7) button8.BackColor = Color.Red;
            else if (number == 8) button9.BackColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentMove++;
            gameBoard[0] = returnSymbol(currentMove);
            Color btnColor = btnColorChange(gameBoard[0]);
            button1.BackColor = btnColor;
            button1.Text = gameBoard[0];
            button1.Enabled = false;
            boardActive[0] = true;
            result();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentMove++;
            gameBoard[1] = returnSymbol(currentMove);
            Color btnColor = btnColorChange(gameBoard[1]);
            button2.BackColor = btnColor;
            button2.Text = gameBoard[1];
            button2.Enabled = false;
            boardActive[1] = true;
            result();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentMove++;
            gameBoard[2] = returnSymbol(currentMove);
            Color btnColor = btnColorChange(gameBoard[2]);
            button3.BackColor = btnColor;
            button3.Text = gameBoard[2];
            button3.Enabled = false;
            boardActive[2] = true;
            result();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentMove++;
            gameBoard[3] = returnSymbol(currentMove);
            Color btnColor = btnColorChange(gameBoard[3]);
            button4.BackColor = btnColor;
            button4.Text = gameBoard[3];
            button4.Enabled = false;
            boardActive[3] = true;
            result();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentMove++;
            gameBoard[4] = returnSymbol(currentMove);
            Color btnColor = btnColorChange(gameBoard[4]);
            button5.BackColor = btnColor;
            button5.Text = gameBoard[4];
            button5.Enabled = false;
            boardActive[4] = true;
            result();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentMove++;
            gameBoard[5] = returnSymbol(currentMove);
            Color btnColor = btnColorChange(gameBoard[5]);
            button6.BackColor = btnColor;
            button6.Text = gameBoard[5];
            button6.Enabled = false;
            boardActive[5] = true;
            result();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentMove++;
            gameBoard[6] = returnSymbol(currentMove);
            Color btnColor = btnColorChange(gameBoard[6]);
            button7.BackColor = btnColor;
            button7.Text = gameBoard[6];
            button7.Enabled = false;
            boardActive[6] = true;
            result();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentMove++;
            gameBoard[7] = returnSymbol(currentMove);
            Color btnColor = btnColorChange(gameBoard[7]);
            button8.BackColor = btnColor;
            button8.Text = gameBoard[7];
            button8.Enabled = false;
            boardActive[7] = true;
            result();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentMove++;
            gameBoard[8] = returnSymbol(currentMove);
            Color btnColor = btnColorChange(gameBoard[8]);
            button9.BackColor = btnColor;
            button9.Text = gameBoard[8];
            button9.Enabled = false;
            boardActive[8] = true;
            result();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            resetGame();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes) Environment.Exit(0);
            else if (dialog == DialogResult.No) e.Cancel = true;
        }
    }
}
