using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;



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

        string myusername = "";

        Socket _client;
        byte[] bdata = new byte[1024];
        public void Form1_Load(object sender, EventArgs e) {
            msg_box.ReadOnly = true;
            msg_box.Cursor = null;


        }

        
        private void button_handling(Button caller,String curr){

            if (caller.Text != "") {
                return;
            }
            if (game_over) {
                return;
            }
           // else if(){}

        
        }

        void ReceiveData(IAsyncResult iar) {
            Socket remote = (Socket)iar.AsyncState;
            if (remote.Connected == false) {
                Environment.Exit(0);
            }

            int recv = remote.EndReceive(iar);
            string stringData = Encoding.ASCII.GetString(bdata, 0, recv);

            string[] msg_rec = stringData.Split('>');

            switch (msg_rec[2]) { 
                case "msg":
                    msg_box.AppendText(msg_rec[0] + "> " + msg_rec[3] + "\r\n");
                    break;
                case "user_list":
                    string[] u_list = msg_rec[3].Split('/');
                    this.lst_users.Items.Clear();
                    for (int i = 0; i < u_list.Length; i++) {
                        this.lst_users.Items.Add(u_list[i]);
                    }
                    break;
                default:
                    break;
            }
        }
        private void login_button_Click(object sender, EventArgs e) {
            do {
                myusername = Microsoft.VisualBasic.Interaction.InputBox("Enter Username:", "User Login", "");
                Application.DoEvents();
            } while (myusername == "");
            Application.DoEvents();

            login_button.Enabled = false;

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try {
                _client.Connect(ipep);
            }
            catch (SocketException ex) {
                MessageBox.Show(ex.Message.ToString());
                Application.Exit();
            }

            //send username
            string msg = myusername + ">" + "server" + ">login>";
            byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
            _client.Send(bin_msg);
            Thread.Sleep(100);
            _client.BeginReceive(bdata, 0, 1024, SocketFlags.None, new AsyncCallback(ReceiveData), _client);

        }

        private void logout_button_Click(object sender, EventArgs e) {
            string msg;
            msg = myusername + ">" + "server" + ">logout>";
            byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
            _client.Send(bin_msg);


            _client.Shutdown(SocketShutdown.Both);
            _client.Close();
            Application.Exit();
        }

        private void request_game_button_Click(object sender, EventArgs e) {

        }

        private void end_game_button_Click(object sender, EventArgs e) {

        }
        private void send_button_Click(object sender, EventArgs e) {
            if (txtSend.Text == "") {
                MessageBox.Show("Dude... Enter a message. I can't send a blank","User Error");
                return;
            }
            if (login_button.Enabled == true) {
                MessageBox.Show("What even...? Login first.", "User Error");
            }

            string msg = myusername + ">server>msg>" + txtSend.Text;
            byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
            _client.Send(bin_msg);
        }

        private void label1_Click_1(object sender, EventArgs e) {

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (_client != null) {
                if (_client.Connected == true) {
                    string msg;
                    msg = myusername + ">" + "server" + ">logout>";
                    byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
                    _client.Send(bin_msg);

                    _client.Shutdown(SocketShutdown.Both);
                    _client.Close();
                }
            }
            // Application.Exit();
        }
    }
}
