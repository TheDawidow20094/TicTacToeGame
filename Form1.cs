using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gra_Dawid_Kaczmarek
{
    public partial class Form1 : Form
    {

        bool turn = true; //turn = true (kolejka X), turn = false (kolejka Y)
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void creatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Twórcą gry jest Dawid Kaczmarek","Twórca");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false; // wyłączenie przycisku by nie zmieniać wartości (X,O)
            turn_count++;

            checkforwinner();
            
        }

        private void checkforwinner()
        {
            
            bool whoisthewinner = false;
            // sprawdzanie poziome
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                whoisthewinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                whoisthewinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                whoisthewinner = true;

            // sprawdzanie pionowe
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                whoisthewinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                whoisthewinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                whoisthewinner = true;

            // sprawdzanie skośne
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                whoisthewinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                whoisthewinner = true;


            if (whoisthewinner)
            {
                disablebuttons();

                string winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";
                MessageBox.Show(winner + " Wygrał","Koniec gry");
            }
            else
            {
                if(turn_count == 9)
                MessageBox.Show("Remis","Koniec gry");
            }
        }

        private void disablebuttons()
        {
            try
            {

                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void newgameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // resetowanie całej rozgrywki
            turn = true;
            turn_count = 0;

            try
            {

                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch
            {

            }

        }
    }
}
