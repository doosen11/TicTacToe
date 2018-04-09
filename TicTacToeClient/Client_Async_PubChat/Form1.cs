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

namespace TTTClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        Socket _client;
        byte[] bdata = new byte[1024];
        string myusername = "";
        private int size = 1024;
        
        string player_status = "Waiting";//Waiting is default
        string player_game_status = "";//X or O will be assigned when game starts
        string opponent = ""; //will be assigned when game starts
       
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //read-in username from user
            do
            {
                myusername = Microsoft.VisualBasic.Interaction.InputBox("Enter Username:", "User Login", "");
                Application.DoEvents();
            } while (myusername == "");
            textBox2.Text = myusername;
            Application.DoEvents();

            btnConnect.Enabled = false; //disable this button so that the user cannot press it again

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(txtServerIP.Text), 9050);
            _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                _client.Connect(ipep);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Application.Exit();
            }

            //first action after connectin is sending a user name
            string msg = myusername + ">" + "server" + ">login>";
            byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
            _client.Send(bin_msg);

            Thread.Sleep(100);

            _client.BeginReceive(bdata, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), _client);
        }


        void ReceiveData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            if (remote.Connected == false)
                Environment.Exit(0);

            int recv = remote.EndReceive(iar);
            string stringData = Encoding.ASCII.GetString(bdata, 0, recv);
            // analyze the string received from server
            string[] msg_rec = stringData.Split('>');

            switch (msg_rec[2])
            {
                case "msg":
                    textBox1.AppendText(msg_rec[0] + "> " + msg_rec[3] + "\r\n");
                    break;
                case "user_list":
                    
                    string[] u_list = msg_rec[3].Split('/');
                    this.lstUsers.Items.Clear();
                    for (int i = 0; i < u_list.Length; i++)
                    {
                       this.lstUsers.Items.Add(u_list[i]);
                    }
                    break;
                default:
                    break;
            }

            _client.BeginReceive(bdata, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), _client);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtSend.Text == "")
            {
                MessageBox.Show("I can't send nothing...", "User Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (btnConnect.Enabled == true)
            {
                MessageBox.Show("Dude. Login First...", "User Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // pack the client text-data to the "msg" format
            string msg = myusername + ">server>msg>" + txtSend.Text;
       
            byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
            _client.Send(bin_msg);
          
        }


        private void button1_Click(object sender, EventArgs e)  //logout button
        {
            if (_client == null) Environment.Exit(0);

            string msg;
            msg = myusername + ">" + "server" + ">logout>";
            byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
            _client.Send(bin_msg);


            _client.Shutdown(SocketShutdown.Both);
            _client.Close();
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_client != null)
            {
                if (_client.Connected == true)
                {
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

        private void button_handeling(Button caller) {
            if (player_status == "Waiting") return; //return if player is not in game
            string msg;
            msg = myusername + ">" + "server" + ">move>" + opponent + ">" + player_game_status + ">";
            byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
            _client.Send(bin_msg);

                       
        
        }
        private void TTT_button_0_Click(object sender, EventArgs e) {
            button_handeling(TTT_button_0);
        }

        private void TTT_button_1_Click(object sender, EventArgs e) {
            button_handeling(TTT_button_1);
        }

        private void TTT_button_2_Click(object sender, EventArgs e) {
            button_handeling(TTT_button_2);
        }

        private void TTT_button_3_Click(object sender, EventArgs e) {
            button_handeling(TTT_button_3);
        }

        private void TTT_button_4_Click(object sender, EventArgs e) {
            button_handeling(TTT_button_4);
        }

        private void TTT_button_5_Click(object sender, EventArgs e) {
            button_handeling(TTT_button_5);
        }

        private void TTT_button_6_Click(object sender, EventArgs e) {
            button_handeling(TTT_button_6);
        }

        private void TTT_button_7_Click(object sender, EventArgs e) {
            button_handeling(TTT_button_7);
        }

        private void TTT_button_8_Click(object sender, EventArgs e) {
            button_handeling(TTT_button_8);
        }


    }
}
