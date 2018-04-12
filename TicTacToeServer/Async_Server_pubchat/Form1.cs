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

namespace TTTServer
{
   
    public partial class Form1 : Form
    {

        public List<socketitem> clientSockets { get; set; }
        public List<string> users = new List<string>();
        private Socket server;
        private byte[] bindata = new byte[1024];
        private int size = 1024;
        private List<string> List_msgs = new List<string>();
        private List<string> games = new List<string>(); //contains list of who is playing who in this format "username1#username2"
        private List<string> users_in_game = new List<string>(); //contains list of what users are in a game, singular. Different from above

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            clientSockets = new List<socketitem>();
        }

      
        private void Form1_Shown(object sender, EventArgs e)
        {
            btnStartServer_Click(sender, e);
        }


        private void btnStartServer_Click(object sender, EventArgs e)
        {
            btnStartServer.Enabled = false;

            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipep);
            server.Listen(5);

            server.BeginAccept(new AsyncCallback(AcceptConn), null);
            Application.DoEvents();
        }

        //callback proc for getting connected to client
        void AcceptConn(IAsyncResult iar)
        {
            Socket client = server.EndAccept(iar);
            clientSockets.Add(new socketitem(client));

           lstConnections.Items.Add(client.RemoteEndPoint.ToString());

            client.BeginReceive(bindata, 0, bindata.Length, SocketFlags.None, new AsyncCallback(ReceiveData), client);

            //call it recursively to allow next connection
            server.BeginAccept(new AsyncCallback(AcceptConn), null);

        }


        //Callback for BeginReceive
        void ReceiveData(IAsyncResult iar)
        {

            Socket client = (Socket)iar.AsyncState;
            if (client.Connected == false) return;

            int recv;
            try
            {
                recv = client.EndReceive(iar);
            }
            catch (SocketException ex)
            {
                txt1.AppendText(ex.Message.ToString() + "\r\n");
                client.Close();
                recv = 0;
            }

            if (recv == 0)
            {
                client.Close();
                //  txt1.AppendText( "Waiting for client ..." + "\r\n");
                for (int i = 0; i < clientSockets.Count; i++)
                {
                    if (clientSockets[i].msock.Connected == false)
                    {
                        clientSockets.RemoveAt(i);
                        lstConnections.Items.RemoveAt(i);
                    }
                }
                server.BeginAccept(new AsyncCallback(AcceptConn), server);
                return;
            }

            string receivedData = Encoding.ASCII.GetString(bindata, 0, recv);
            txt1.AppendText(receivedData + "\r\n");


            //handle string received from cient
            string[] msg_fields = receivedData.Split('>');
            string userlist_msg = "";

            switch (msg_fields[2])
            {
                case "login":
                    lstUsers.Items.Add(msg_fields[0]); //add login name in the source field
                    clientSockets.Last().name = msg_fields[0];
                    
                    //send user_list to all clients
                    userlist_msg = get_User_lst();
                    for (int i = 0; i < clientSockets.Count; i++)
                    {
                        send_to_client(clientSockets[i].msock, userlist_msg);
                    }

                    break;

                case "logout":
                    lstUsers.Items.Remove(msg_fields[0]);
                    client.Close();
                    for (int i = 0; i < clientSockets.Count; i++)
                    {
                        if (clientSockets[i].msock.Connected == false)
                        {
                            clientSockets.RemoveAt(i);
                            lstConnections.Items.RemoveAt(i);
                        }
                    }
                    //send user_list to all clients since the server's user_list have changed
                    userlist_msg = get_User_lst();
                    for (int i = 0; i < clientSockets.Count; i++)
                    {
                        send_to_client(clientSockets[i].msock, userlist_msg);
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
                    for (int i = 0; i < clientSockets.Count; i++)
                    {
                        send_to_client(clientSockets[i].msock, receivedData);
                    }

                    break;
                    
                case "move":
                    //msg_fields[3] => opponent username
                    //msg_fields[4] => game turn count (parse to int)
                    //msg_fields[5] => buttonname that was pressed
                    string one = msg_fields[0];
                    string two = msg_fields[3];
                    if (games.Contains(one + "#" + two) || games.Contains(two + "#" + one)) { 
                        //there exissts a game between user one and user two.
                        int turn_number = int.Parse(msg_fields[4]);
                        turn_number++;
                        socketitem one_sock = clientSockets.FirstOrDefault(o => o.name == one);
                        socketitem two_sock = clientSockets.FirstOrDefault(o => o.name == two);
                        
                        string hmmm = "MOVE" + ">" + "server" + ">turn_taken>" + turn_number.ToString() + ">" + msg_fields[5];
                        send_to_client(one_sock.msock, hmmm);
                        send_to_client(two_sock.msock, hmmm);

                    }
                    break;
                case "request_game":
                      //msg_fields[3] => requested opponent
                    if ((games.Contains(msg_fields[0] + "#" + msg_fields[3])) || games.Contains(msg_fields[3] + "#" + msg_fields[0])) { 
                        //users are already 
                    }
                    if (users_in_game.Contains(msg_fields[3])) {
                        //the requested opponent is in a game already

                    }
                    else {
                       // users_in_game.Add(msg_fields[0]);
                        //users_in_game.Add(msg_fields[3]);
                        //games.Add(msg_fields[0] + "#" + msg_fields[3]);//there is now a game between these two users
                        socketitem opp_name = clientSockets.FirstOrDefault(o => o.name == msg_fields[3]);
                        string temp = "GAMEREQUEST" + ">" + "server" + ">game_request" + ">" + msg_fields[0] + ">";
                        send_to_client(opp_name.msock, temp);


                    }

                    break;
                case "accept_game":
                    //msg_fields[3] => username of accepted game
                    users_in_game.Add(msg_fields[0]);
                    users_in_game.Add(msg_fields[3]);
                    games.Add(msg_fields[0] + "#" + msg_fields[3]);
                    socketitem opp = clientSockets.FirstOrDefault(o => o.name == msg_fields[3]);
                    socketitem opp2 = clientSockets.FirstOrDefault(o => o.name == msg_fields[0]);
                    //the previous two lines find the socketitems for the two users playing. 
                    //Later, to get the socket for the two users in a game, follow these steps:
                    //1. parse the list of users_in_game for the two users.
                    //2. create socketitems based on the name field as shown above
                    //3. send the updated game data to them
                    //4. rinse & repeat
                    string message = "ACCEPTED" + ">" + "server" + ">" + "game_accept" + ">" + msg_fields[0] + ">";
                   // lstUsers.Items.Remove(msg_fields[0] + "     " + "Waiting");
                    //lstUsers.Items.Remove(msg_fields[3] + "     " + "Waiting");
                    //lstUsers.Items.Add(msg_fields[0] + "     " + "Playing");
                    //lstUsers.Items.Add(msg_fields[3] + "     " + "Playing");
                    send_to_client(opp.msock, message);
                    send_to_client(opp2.msock, message);
                    break;
                case "reject_game":
                    socketitem a = clientSockets.FirstOrDefault(o => o.name == msg_fields[3]);
                    socketitem b = clientSockets.FirstOrDefault(o => o.name == msg_fields[0]);
                    string message2 = "DENIED" + ">" + "server" + ">" + "game_rejection" + ">";
                    send_to_client(a.msock, message2);
                    send_to_client(b.msock, message2);
                    break;

            } 

            if (client.Connected)
                client.BeginReceive(bindata, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), client);

        }

        private string get_User_lst()
        {
            string user_list = "";
            if (this.lstUsers.Items.Count != 0)
            {
                for (int i = 0; i < this.lstUsers.Items.Count; i++)
                {
                    user_list += this.lstUsers.Items[i] + "/";

                }
                user_list = user_list.Substring(0, user_list.Length - 1);  //remove last "/"
            }

            string userlist_msg = "";
            userlist_msg = "server>all>user_list>" + user_list;

            return userlist_msg;
        }


        // Callback for BeginSend
        void send_to_client(Socket sock, string message)
        {
            byte[] bins = Encoding.ASCII.GetBytes(message);
            sock.BeginSend(bins,0, bins.Length, SocketFlags.None, new AsyncCallback(SendData), sock);

            server.BeginAccept(new AsyncCallback(AcceptConn), null);

            
        }

        private void SendData(IAsyncResult iar)
        {
            Socket soc = (Socket)iar.AsyncState;
            soc.EndSend(iar);
        }

    }

    public class socketitem
    {
        public Socket msock { get; set; }
        public string name { get; set; }
        public socketitem(Socket sock)
        {
            this.msock = sock;
        }
    }
}
