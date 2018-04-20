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
            disableButtons();
        }

        Socket _client;
        byte[] bdata = new byte[1024];
        string myusername = "";
        private int size = 1024;

        string ReqUser;
        string player_status = "Waiting";//Waiting is default
        string player_game_status = "";//X or O will be assigned when game starts
        string opponent = ""; //will be assigned when game starts
        bool turn = false; //true = X, false = O;
        bool winner = false;
        int count = 0;
        int turn_count = 0;
        int secret_piece_number = 0; //0 by default. The client who requested the game will always be O (0)for now. X = 1, O = 0.
        int wincount = 0;
        int drawcount = 0;
        int losscount = 0;
        int totalcount = 0;
        bool gamedone = false;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            texttotal.Text = "Total Games Played: " + totalcount.ToString();
            textwin.Text = "Wins: " + wincount.ToString();
            textdraw.Text = "Draws: " + drawcount.ToString();
            textloss.Text = "Losses: " + losscount.ToString();

            txtServerIP.Enabled = false;
            //read-in username from user
            //do
            //{
            myusername = Microsoft.VisualBasic.Interaction.InputBox("Enter Username:", "User Login", "");
            Application.DoEvents();
            //while (myusername == "");
            if (myusername == "")
            {
                myusername = "User";
            }
            userName.Text = myusername;
            Application.DoEvents();

            btnConnect.Enabled = false; //disable this button so that the user cannot press it again

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(txtServerIP.Text), 9050);
            _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                _client.Connect(ipep);
            //first action after connectin is sending a user name
            string msg = myusername + ">" + "server" + ">login>";
            byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
            _client.Send(bin_msg);

            Thread.Sleep(100);

            _client.BeginReceive(bdata, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), _client);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                btnConnect.Enabled = true;
                txtServerIP.Enabled = true;

            }
        }


        void ReceiveData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;
            if (remote.Connected == false)
                Environment.Exit(0);
            int recv;
            try {
                recv = remote.EndReceive(iar);
            }
            catch (SocketException ex) {
                _client.Shutdown(SocketShutdown.Both);
                DialogResult shutdown = MessageBox.Show("The server has unexpectadly closed. Please reconnect later.", "Unexpexted Shutdown", MessageBoxButtons.OK);
                _client.Close();
                Application.Exit();
                
                recv = 0;
            }
            string stringData = Encoding.ASCII.GetString(bdata, 0, recv);
            // analyze the string received from server
            string[] msg_rec = stringData.Split('>');

            try {
                switch (msg_rec[2]) {
                    case "msg":
                        textBox1.AppendText(msg_rec[0] + "> " + msg_rec[3] + "\r\n");
                        break;
                    case "user_list":

                        string[] u_list = msg_rec[3].Split('/');
                        this.lstUsers.Items.Clear();
                        for (int i = 0; i < u_list.Length; i++) {
                            this.lstUsers.Items.Add(u_list[i]);
                        }
                        break;
                    case "game_request":
                        // textBox1.AppendText(msg_rec[0] + "> " + msg_rec[3] + "\r\n");

                        DialogResult dialogResult = MessageBox.Show("Do you choose to accept a challenge from " + msg_rec[3] + "?", "Incoming Challenge!!!", MessageBoxButtons.YesNo);
                        player_status = "Playing";
                        string msg = "";
                        if (dialogResult == DialogResult.Yes) {
                            //send back confirmation.
                            //change user status to playing
                            //???
                            //Profit
                            player_status = "Playing";
                            msg = myusername + ">" + "server>" + "accept_game" + ">" + msg_rec[3] + ">";
                            enableButtons();
                            clearButtons();
                            turn_count = 0;
                            totalcount++;

                            secret_piece_number = 1;//player is now X
                        }
                        else if (dialogResult == DialogResult.No) {
                            //send rejection
                            //don't change user status
                            //???
                            //profit
                            player_status = "Waiting";
                            msg = myusername + ">" + "server>" + "reject_game" + ">" + msg_rec[3] + ">";
                        }

                        if (msg != "") {
                            byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
                            _client.Send(bin_msg);
                        }
                        break;
                    case "game_rejection":
                        DialogResult rejectionResult = MessageBox.Show(msg_rec[3] + " has chickened out. Oh well", "Denied", MessageBoxButtons.OK);
                        //do I need to tell the window to close??
                        // player_status = "Waiting";
                        break;
                    case "game_accept":
                        DialogResult acceptResult = MessageBox.Show("Let the games begin", "Accepted", MessageBoxButtons.OK);
                        //player_status = "Playing";
                        //opponent = msg_rec[3];
                        if (myusername == msg_rec[3]) opponent = msg_rec[4];
                        else opponent = msg_rec[3];
                        allenableButtons();

                        break;
                    case "turn_taken":
                        turn_count = int.Parse(msg_rec[3]);
                        switch (msg_rec[4]) {
                            case "TTT_button_0":
                                update_button_text(TTT_button_0);
                                break;
                            case "TTT_button_1":
                                update_button_text(TTT_button_1);
                                break;
                            case "TTT_button_2":
                                update_button_text(TTT_button_2);
                                break;
                            case "TTT_button_3":
                                update_button_text(TTT_button_3);
                                break;
                            case "TTT_button_4":
                                update_button_text(TTT_button_4);
                                break;
                            case "TTT_button_5":
                                update_button_text(TTT_button_5);
                                break;
                            case "TTT_button_6":
                                update_button_text(TTT_button_6);
                                break;
                            case "TTT_button_7":
                                update_button_text(TTT_button_7);
                                break;
                            case "TTT_button_8":
                                update_button_text(TTT_button_8);
                                break;
                        }

                        break;
                    case "shutdown":
                        _client.Shutdown(SocketShutdown.Both);
                        DialogResult shutdown = MessageBox.Show("The server has unexpectadly closed. Please reconnect later.", "Unexpexted Shutdown", MessageBoxButtons.OK);
                        break;
                    case "cheating":
                        DialogResult cheat = MessageBox.Show("You can't take two turns in a row you cheater!", "CHEATER", MessageBoxButtons.OK);
                        break;
                    default:
                        break;
                }
            }
            catch(IndexOutOfRangeException i){
               // _client.Close();
                Application.Exit();
            }
            try
            {
                _client.BeginReceive(bdata, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), _client);
            }
            catch (ObjectDisposedException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtSend.Text == "")
            {
                MessageBox.Show("I can't send nothing...", "PEBCAK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (btnConnect.Enabled == true)
            {
                MessageBox.Show("Dude. Login First...", "PEBCAK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            string msg = myusername + ">" + "server" + ">logout>";
          
            byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
            try
            {
                _client.Send(bin_msg);
            }
            catch (SocketException ex)
            {
                Application.Exit();
            }
            try
            {
                _client.Shutdown(SocketShutdown.Both);
            }
            catch (SocketException ex)
            {
                Application.Exit();
            }
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

        private void button1_Click_1(object sender, EventArgs e) {
            /***************************************************
             * REQUEST TTT GAME WITH A USER SELECTED IN THE BOX
             * 
             *************************************************** */
            allenableButtons();
            clearButtons();
            totalcount++;
            if (myusername == "") return;
            turn_count = 0;
            // if (player_status == "Playing") return;//shouldn't ever happen if the button gets disabled properly
            ReqUser = Microsoft.VisualBasic.Interaction.InputBox("Enter Username: ", "User Login", ""); ;
            //string temp = lstUsers.SelectedItem.ToString().Substring(0, lstUsers.SelectedItem.ToString().Length - 13);
            //player_status = "Playing";
            string msg = myusername + ">" + "server" + ">request_game>" + ReqUser + ">";
            byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
            try
            {
                _client.Send(bin_msg);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button_handeling(Button caller) {
            //if (player_status == "Waiting") return; //return if player is not in game

            
            string msg;
            msg = myusername + ">" + "server" + ">move>" + opponent + ">" + turn_count.ToString() + ">" + caller.Name + ">" + secret_piece_number;
            byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
            _client.Send(bin_msg);
         //   if (wincheck()) return;
        }

        private void update_button_text(Button button) {
            if (button.Text != "") return;
           // if (wincheck()) return;
            if (turn_count % 2 == 0) {
                button.Text = "X";

            }
            else button.Text = "O";
            wincheck(); 
        }
        private void TTT_button_0_Click(object sender, EventArgs e)
        {
            
            button_handeling(TTT_button_0);
            count++;
            
        }

        private void TTT_button_1_Click(object sender, EventArgs e)
        {
            button_handeling(TTT_button_1);
          
            count++;
        }

        private void TTT_button_2_Click(object sender, EventArgs e)
        {
            button_handeling(TTT_button_2);
            
            count++;
        }

        private void TTT_button_3_Click(object sender, EventArgs e)
        {
            button_handeling(TTT_button_3);
            
            count++;
        }

        private void TTT_button_4_Click(object sender, EventArgs e)
        {
            button_handeling(TTT_button_4);
            count++;
        }

        private void TTT_button_5_Click(object sender, EventArgs e)
        {
            button_handeling(TTT_button_5);

            count++;
        }

        private void TTT_button_6_Click(object sender, EventArgs e)
        {
            button_handeling(TTT_button_6);

            count++;
           
        }

        private void TTT_button_7_Click(object sender, EventArgs e)
        {
            button_handeling(TTT_button_7);

            count++;
           
        }

        private void TTT_button_8_Click(object sender, EventArgs e)
        {
            button_handeling(TTT_button_8);
            count++;
         
        }

        private bool wincheck()
        {

            /** 0 1 2
             *  3 4 5 
             *  6 7 8
             *  */
            string winning_piece = "";
            winner = false;
            
            if ((TTT_button_0.Text == TTT_button_1.Text) && (TTT_button_1.Text == TTT_button_2.Text) && (TTT_button_0.Text != "")) {
                winning_piece = TTT_button_0.Text;
                winner = true;
                wincount++;
            }
            else if ((TTT_button_3.Text == TTT_button_4.Text) && (TTT_button_4.Text == TTT_button_5.Text) && (TTT_button_3.Text != "")) {
                winning_piece = TTT_button_3.Text;
                winner = true;
                wincount++;
            }
            else if ((TTT_button_6.Text == TTT_button_7.Text) && (TTT_button_7.Text == TTT_button_8.Text) && (TTT_button_6.Text != "")) {
                winning_piece = TTT_button_6.Text;
                winner = true;
                wincount++;
            }
            else if ((TTT_button_0.Text == TTT_button_4.Text) && (TTT_button_4.Text == TTT_button_8.Text) && (TTT_button_0.Text != "")) {
                winning_piece = TTT_button_0.Text;
                winner = true;
                wincount++;
            }
            else if ((TTT_button_2.Text == TTT_button_4.Text) && (TTT_button_4.Text == TTT_button_6.Text) && (TTT_button_2.Text != "")) {
                winning_piece = TTT_button_2.Text;
                winner = true;
                wincount++;
            }

            else if ((TTT_button_2.Text == TTT_button_5.Text) && (TTT_button_5.Text == TTT_button_8.Text) && (TTT_button_5.Text != "")) {
                winning_piece = TTT_button_2.Text;
                winner = true;
                wincount++;
            }
            else if ((TTT_button_1.Text == TTT_button_4.Text) && (TTT_button_4.Text == TTT_button_7.Text) && (TTT_button_1.Text != "")) {
                winning_piece = TTT_button_1.Text;
                winner = true;
                wincount++;
            }
            else if ((TTT_button_0.Text == TTT_button_3.Text) && (TTT_button_3.Text == TTT_button_6.Text) && (TTT_button_0.Text != "")) {
                winning_piece = TTT_button_0.Text;
                winner = true;
                wincount++;
            }
            else {
                //count++;
                winner = false;
               // return false;
            }
            Console.Write("ARE YOU HERE? \r\n");
            if (winner)
            {
       

                MessageBox.Show(winning_piece + " Wins!", userName.Text);
                disableButtons();
                clearButtons();
                wincount++;
                winner = false;
                count = 0;
                string msg = myusername + ">" + "server" + ">end_game>" + opponent + ">";
                byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
                try {
                    try {
                        _client.Send(bin_msg);
                    }
                    catch (SocketException ex) {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                catch (NullReferenceException ex) {
                    MessageBox.Show(ex.Message.ToString());
                    //Application.Exit();
                }
                return true;
            }
            Console.Write("WHATS UP? \r\n");
            if ((turn_count == 9) && (winner == false))
            {
                Console.Write("NOT YOU \r\n");
                MessageBox.Show("Draw!", userName.Text);
                disableButtons();
                clearButtons();
                drawcount++;
                winner = false;
                count = 0;
                string msg = myusername + ">" + "server" + ">end_game>" + opponent + ">";
                byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
                try {
                    try {
                        _client.Send(bin_msg);
                    }
                    catch (SocketException ex) {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                catch (NullReferenceException ex) {
                    MessageBox.Show(ex.Message.ToString());
                    //Application.Exit();
                }
             
            }
            return false;

        }
        private void disableButtons()
        {
            TTT_button_0.Enabled = false;
            TTT_button_1.Enabled = false;
            TTT_button_2.Enabled = false;
            TTT_button_3.Enabled = false;
            TTT_button_4.Enabled = false;
            TTT_button_5.Enabled = false;
            TTT_button_6.Enabled = false;
            TTT_button_7.Enabled = false;
            TTT_button_8.Enabled = false;
        }

        private void enableButtons()
        {
            if (TTT_button_0.Text == "")
            {
                TTT_button_0.Enabled = true;
            }
            if (TTT_button_1.Text == "")
            {
                TTT_button_1.Enabled = true;
            }
            if (TTT_button_2.Text == "")
            {
                TTT_button_2.Enabled = true;
            }
            if (TTT_button_3.Text == "")
            {
                TTT_button_3.Enabled = true;
            }
            if (TTT_button_4.Text == "")
            {
                TTT_button_4.Enabled = true;
            }
            if (TTT_button_5.Text == "")
            {
                TTT_button_5.Enabled = true;
            }
            if (TTT_button_6.Text == "")
            {
                TTT_button_6.Enabled = true;
            }
            if (TTT_button_7.Text == "")
            {
                TTT_button_7.Enabled = true;
            }
            if (TTT_button_8.Text == "")
            {
                TTT_button_8.Enabled = true;
            }

            else
            {
                wincheck();
            }
        }
        private void allenableButtons()
        {
            TTT_button_0.Enabled = true;
            TTT_button_1.Enabled = true;
            TTT_button_2.Enabled = true;
            TTT_button_3.Enabled = true;
            TTT_button_4.Enabled = true;
            TTT_button_5.Enabled = true;
            TTT_button_6.Enabled = true;
            TTT_button_7.Enabled = true;
            TTT_button_8.Enabled = true;
        }
        private void clearButtons()
        {
            TTT_button_0.Text = "";
            TTT_button_1.Text = "";
            TTT_button_2.Text = "";
            TTT_button_3.Text = "";
            TTT_button_4.Text = "";
            TTT_button_5.Text = "";
            TTT_button_6.Text = "";
            TTT_button_7.Text = "";
            TTT_button_8.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearButtons();
            string msg = myusername + ">" + "server" + ">end_game>" + opponent + ">";
            byte[] bin_msg = Encoding.ASCII.GetBytes(msg);
            try
            {
                try
                {
                    _client.Send(bin_msg);
                }
                catch (SocketException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //Application.Exit();
            }
        }
    }
}
