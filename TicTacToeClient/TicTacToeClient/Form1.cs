using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeClient {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public bool game_over;

        public class PLAYER {
            string username;
            int status;
            int player;
        }
        
        enum player { 
            one,
            two
        };
        enum status { 
            Waiting,
            Playing
        };

        public void Form1_Load(object sender, EventArgs e) {
            textBox1.ReadOnly = true;
            textBox1.Cursor = null;

        }
        private void button_handling(Button caller,String curr){

            if (caller.Text != "") {
                return;
            }
            if (game_over) {
                return;
            }
            else if(){}

        
        }
        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {

        }

        private void button3_Click(object sender, EventArgs e) {

        }

        private void button4_Click(object sender, EventArgs e) {

        }

        private void button5_Click(object sender, EventArgs e) {

        }

        private void button6_Click(object sender, EventArgs e) {

        }

        private void button7_Click(object sender, EventArgs e) {

        }

        private void button8_Click(object sender, EventArgs e) {

        }

        private void button9_Click(object sender, EventArgs e) {

        }
    }
}
