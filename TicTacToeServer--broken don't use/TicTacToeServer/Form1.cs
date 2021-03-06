﻿//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Net;
//using System.Net.Sockets;
//using System.IO;

//namespace TicTacToeServer {
//    public partial class Form1 : Form {

//        public List<socketitem> clientSockets { get; set; }
//        public List<string> users = new List<string>();
//        private Socket server;
//        private byte[] bindata = new byte[1024];

//        private List<string> List_msgs = new List<string>();
        
//        public Form1() {
//            InitializeComponent();
//            CheckForIllegalCrossThreadCalls = false;
//            clientSockets = new List<socketitem>();
//        }
//        public void Form1_Shown(object sender, EventArgs e) {
//            start_server(sender, e);
//        }

//        private void start_server(object sender, EventArgs e) {
//            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
//            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//            server.Bind(ipep);
//            server.Listen(5);
//            server.BeginAccept(new AsyncCallback(AcceptConn), null);
//            Application.DoEvents();
//        }

//        void AcceptConn(IAsyncResult iar) {
//            Socket client = server.EndAccept(iar);
//            clientSockets.Add(new socketitem(client));
//            lst_connections.Items.Add(client.RemoteEndPoint.ToString());
//            client.BeginReceive(bindata, 0, bindata.Length, SocketFlags.None, new AsyncCallback(ReceiveData), client);

//            server.BeginAccept(new AsyncCallback(AcceptConn), null);
//        }

//        void ReceiveData(IAsyncResult iar) {
//            Socket client = (Socket)iar.AsyncState;
//            if (client.Connected == false) return;
//            int recv;
//            try {
//                recv = client.EndReceive(iar);
//            }
//            catch (SocketException ex) {
//                textBox1.AppendText(ex.Message.ToString() + "\r\n");
//                client.Close();
//                recv = 0;
//            }
//            if (recv == 0) {
//                client.Close();
//                for (int i = 0; i < clientSockets.Count; i++) {
//                    if (clientSockets[i].msock.Connected == false) {
//                        clientSockets.RemoveAt(i);
//                        lst_connections.Items.RemoveAt(i);
//                    }
//                }
//                server.BeginAccept(new AsyncCallback(AcceptConn), server);
//                return;
//            }

//            string received_data = Encoding.ASCII.GetString(bindata, 0, recv);
//            textBox1.AppendText(received_data + "\r\n");

//            //handle string received from client
//            string[] msg_fields = received_data.Split('>');
//            string userlist_msg = "";

//            switch (msg_fields[2]) { 
//                case "login":
//                    lst_users.Items.Add(msg_fields[0]);//add username
//                    clientSockets.Last().name = msg_fields[0];
//                    userlist_msg = get_User_lst();
//                    for (int i = 0; i < clientSockets.Count; i++) {
//                        send_to_client(clientSockets[i].msock, userlist_msg);
//                    }
//                    break;
//                case "logout":
//                    lst_users.Items.Remove(msg_fields[0]);
//                    client.Close();
//                    for (int i = 0; i < clientSockets.Count; i++) {
//                        if (clientSockets[i].msock.Connected == false) {
//                            clientSockets.RemoveAt(i);
//                            lst_connections.Items.RemoveAt(i);
//                        }
//                    }
//                    //send user_list to all clients since the server's user_list have changed
//                    userlist_msg = get_User_lst();
//                    for (int i = 0; i < clientSockets.Count; i++) {
//                        send_to_client(clientSockets[i].msock, userlist_msg);
//                    }
//                    server.BeginAccept(new AsyncCallback(AcceptConn), server);
//                    break;
//                case "user_list":
//                    userlist_msg = get_User_lst();
//                    byte[] msg3 = Encoding.ASCII.GetBytes(userlist_msg);
//                    client.Send(msg3);
//                    break;
//                case "msg":
//                    List_msgs.Add(received_data);
//                    //echo the received data back to all clients
//                    for (int i = 0; i < clientSockets.Count; i++) {
//                        send_to_client(clientSockets[i].msock, received_data);
//                    }

//                    break;
            
//            }
//            if (client.Connected)
//                client.BeginReceive(bindata, 0, 1024, SocketFlags.None, new AsyncCallback(ReceiveData), client);
//        }

//        private string get_User_lst(){
//            string user_list = "";
//            if(this.lst_users.Items.Count != 0){
//                for (int i = 0; i < this.lst_users.Items.Count; i++) {

//                    user_list += this.lst_users.Items[i] + "/";
//                }
//                user_list = user_list.Substring(0, user_list.Length - 1);
//            }
//            string user_listmsg = "server>all>user_list>" + user_list;
//            return user_listmsg;

//        }

//        void send_to_client(Socket sock, string message) {
//            byte[] bins = Encoding.ASCII.GetBytes(message);
//            sock.BeginSend(bins, 0, bins.Length, SocketFlags.None, new AsyncCallback(SendData), sock);
//            server.BeginAccept(new AsyncCallback(AcceptConn), null);
//        }
//        private void SendData(IAsyncResult iar) {
//            Socket soc = (Socket)iar.AsyncState;
//            soc.EndSend(iar);
//        }
      

//    }
//    public class socketitem {
//        public Socket msock { get; set; }
//        public string name { get; set; }
//        public socketitem(Socket sock) {
//            this.msock = sock;
//        }
//    }
//}

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

namespace TicTacToeServer {

    public partial class Form1 : Form {

        public List<socketitem> clientSockets { get; set; }
        public List<string> users = new List<string>();
        private Socket server;
        private byte[] bindata = new byte[1024];
        private int size = 1024;
        private List<string> List_msgs = new List<string>();

        public Form1() {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            clientSockets = new List<socketitem>();
        }


        private void Form1_Shown(object sender, EventArgs e) {
            start_server(sender, e);
        }


        private void start_server(object sender, EventArgs e) {
           // btnStartServer.Enabled = false;

            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipep);
            server.Listen(5);

            server.BeginAccept(new AsyncCallback(AcceptConn), null);
            Application.DoEvents();
        }

        //callback proc for getting connected to client
        void AcceptConn(IAsyncResult iar) {
            Socket client = server.EndAccept(iar);
            clientSockets.Add(new socketitem(client));

            lst_connections.Items.Add(client.RemoteEndPoint.ToString());

            client.BeginReceive(bindata, 0, bindata.Length, SocketFlags.None, new AsyncCallback(ReceiveData), client);

            //call it recursively to allow next connection
            server.BeginAccept(new AsyncCallback(AcceptConn), null);

        }


        //Callback for BeginReceive
        void ReceiveData(IAsyncResult iar) {

            Socket client = (Socket)iar.AsyncState;
            if (client.Connected == false) return;

            int recv;
            try {
                recv = client.EndReceive(iar);
            }
            catch (SocketException ex) {
                textBox1.AppendText(ex.Message.ToString() + "\r\n");
                client.Close();
                recv = 0;
            }

            if (recv == 0) {
                client.Close();
                //  txt1.AppendText( "Waiting for client ..." + "\r\n");
                for (int i = 0; i < clientSockets.Count; i++) {
                    if (clientSockets[i].msock.Connected == false) {
                        clientSockets.RemoveAt(i);
                        lst_connections.Items.RemoveAt(i);
                    }
                }
                server.BeginAccept(new AsyncCallback(AcceptConn), server);
                return;
            }

            string receivedData = Encoding.ASCII.GetString(bindata, 0, recv);
            textBox1.AppendText(receivedData + "\r\n");


            //handle string received from cient
            string[] msg_fields = receivedData.Split('>');
            string userlist_msg = "";

            switch (msg_fields[2]) {
                case "login":
                    lst_users.Items.Add(msg_fields[0]); //add login name in the source field
                    clientSockets.Last().name = msg_fields[0];

                    //send user_list to all clients
                    userlist_msg = get_User_lst();
                    for (int i = 0; i < clientSockets.Count; i++) {
                        Send2Client(clientSockets[i].msock, userlist_msg);
                    }

                    break;

                case "logout":
                    lst_users.Items.Remove(msg_fields[0]);
                    client.Close();
                    for (int i = 0; i < clientSockets.Count; i++) {
                        if (clientSockets[i].msock.Connected == false) {
                            clientSockets.RemoveAt(i);
                            lst_connections.Items.RemoveAt(i);
                        }
                    }
                    //send user_list to all clients since the server's user_list have changed
                    userlist_msg = get_User_lst();
                    for (int i = 0; i < clientSockets.Count; i++) {
                        Send2Client(clientSockets[i].msock, userlist_msg);
                    }
                    server.BeginAccept(new AsyncCallback(AcceptConn), server);
                    break;
                case "user_list":
                    userlist_msg = get_User_lst();
                    byte[] msg3 = Encoding.ASCII.GetBytes(userlist_msg);
                    client.Send(msg3);
                    break;
                case "msg":
                    List_msgs.Add(receivedData);
                    //echo the received data back to all clients
                    for (int i = 0; i < clientSockets.Count; i++) {
                        Send2Client(clientSockets[i].msock, receivedData);
                    }

                    break;

            } //end of switch

            if (client.Connected)
                client.BeginReceive(bindata, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), client);

        }

        private string get_User_lst() {
            string user_list = "";
            if (this.lst_users.Items.Count != 0) {
                for (int i = 0; i < this.lst_users.Items.Count; i++) {
                    user_list += this.lst_users.Items[i] + "/";

                }
                user_list = user_list.Substring(0, user_list.Length - 1);  //remove last "/"
            }

            string userlist_msg = "";
            userlist_msg = "server>all>user_list>" + user_list;

            return userlist_msg;
        }


        // Callback for BeginSend
        void Send2Client(Socket sock, string message) {
            byte[] bins = Encoding.ASCII.GetBytes(message);
            sock.BeginSend(bins, 0, bins.Length, SocketFlags.None, new AsyncCallback(SendData), sock);

            server.BeginAccept(new AsyncCallback(AcceptConn), null);
        }

        private void SendData(IAsyncResult iar) {
            Socket soc = (Socket)iar.AsyncState;
            soc.EndSend(iar);
        }

    }

    public class socketitem {
        public Socket msock { get; set; }
        public string name { get; set; }
        public socketitem(Socket sock) {
            this.msock = sock;
        }
    }
}
