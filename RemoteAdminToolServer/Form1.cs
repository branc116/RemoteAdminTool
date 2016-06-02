using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace RemoteAdminToolServer
{
    public partial class Form1 : Form
    {
        Socket Server;

        byte[] buffer, bufferSend;
        int bufferSize = 1024;
        struct connections
        {
            public Socket s;
            public IPEndPoint EP;
            public string ipadresa;
            public string ime;
            public string IdStr;
        };
        List<connections> activConnections;
        string activeID;
        bool trebaNova = true;


        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            activConnections = new List<connections>();

            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Server.Bind(new IPEndPoint(IPAddress.Any, 5005));
            Server.Listen(54);
            try
            {
                Server.BeginAccept(OnAccepted, new connections());
            }
            catch { }
            new Thread(new ThreadStart(CheckActiveConnectionsLoop)).Start();
            panel1.AutoScroll = true;
            console.MinimumSize = panel1.Size;
            panel1.AutoScrollMargin = console.Size;
        }
        public void AcceptConnections()
        {
            while (true)
            {
                
                Thread.Sleep(5000);
            }
        }
        public void CheckActiveConnectionsLoop()
        {
            while (true)
            {
                //for (int i=0;i<activConnections.Count;i++)
                //{
                //    connections conn = activConnections[i];
                //    if (new TcpClient( conn.EP).Connected)
                //    {
                //        int idInDGW = FindeIDOfConnectionInDataGridView(conn.IdStr);
                //        listOfActiveConnectionDataGrid.Rows.RemoveAt(idInDGW);
                //        activConnections.RemoveAt(i);

                //    }
                       
                //}
                Thread.Sleep(5000);
            }
        }
        private void OnAccepted(IAsyncResult ar)
        {
            CheckForIllegalCrossThreadCalls = false;
            try
            {
                connections state = (connections)ar.AsyncState;
                Socket s = Server.EndAccept(ar);

                string ID = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16);
                state.IdStr = ID;
                state.EP = s.RemoteEndPoint as IPEndPoint;
                state.ipadresa = state.EP.Address.ToString();
                state.s = s;

                activConnections.Add(state);

                showIP.Text = "Spojeno";
                MyLog("Connected" + ID);
                activeID = ID;
                Server.Listen(50);
                Server.BeginAccept(OnAccepted, new connections());

                buffer = new byte[bufferSize];

                s.BeginReceive(buffer, 0, bufferSize, 0, OnBeginReceive, state);

                MySend("Identify", state);
                
                
            }
            catch(Exception ee)
            {
                Console.WriteLine(ee.ToString());
            }
            
        }
        private void OnBeginReceive(IAsyncResult ar)
        {
            CheckForIllegalCrossThreadCalls = false;
            try
            {
                connections state = (connections)ar.AsyncState;
                int size = state.s.EndReceive(ar);
                string mssg = Encoding.ASCII.GetString(buffer);
                string[] msgs = mssg.Split(' ');
                buffer = new byte[bufferSize];
                state.s.BeginReceive(buffer, 0, bufferSize, 0, OnBeginReceive, state);
                if (msgs[0] == "IP")
                {
                    MyAddRow(listOfActiveConnectionDataGrid.Rows[listOfActiveConnectionDataGrid.Rows.Count-1].Cells[0].ToString(), msgs[2], state.IdStr, msgs[1]);
                    connections conn = FindConnectionByID(state.IdStr);
                    conn.ipadresa = msgs[1];
                    conn.ime = msgs[2];
                }

                if  (state.ipadresa!=null)
                    MyLog(state.ipadresa + "( "+ state.ime + " ) -> " + mssg);
                else
                    MyLog(state.IdStr + " -> " + mssg);
                if (mssg.Substring(0, 2) == "ip")
                    state.ipadresa = mssg.Split(' ')[1];
                if (mssg.Substring(0, 4) == "name")
                    state.ime = mssg.Split(' ')[1];

               
            }
            catch
            {
                
            }
            
        }
        private void MyAddRow(string lastId, string deviceName, string sesionId,string ip)
        {
            DataGridViewRow my = new DataGridViewRow();
            if (lastId.Length > 10)
                lastId = "0";
            listOfActiveConnectionDataGrid.Rows.Add(new object[4]
            {
                Convert.ToInt32(lastId)+1,
                deviceName,
                sesionId,
                ip
            });

        }
        private void OnSend(IAsyncResult ar)
        {
            CheckForIllegalCrossThreadCalls = false;
            try
            {
                connections state = (connections)ar.AsyncState;
                state.s.EndSend(ar);
                
            }
            catch
            {

            }
            
        }
        private void dropConnecton_Click(object sender, EventArgs e)
        {
            
        }
        private void sendCommandButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                connections conn = FindConnectionByID(activeID);
                MySend(sendCommand.Text, conn);
            }
            catch { }
        }
        private connections FindConnectionByID(string sesionid)
        {
            for (int i = 0; i < activConnections.Count; i++)
            {
                if (activConnections[i].IdStr == sesionid)
                    return activConnections[i];

            }
            throw new Exception("No Active connection with that ID");
        }
        private void dltLog_Click(object sender, EventArgs e)
        {
            console.Text = string.Empty;
        }
        private void sendFile_Click(object sender, EventArgs e)
        {
            openFiles.ShowDialog();
            if (openFiles.CheckPathExists)
            {
                
            }
        }
        public void MyLog(object obj)
        {
            CheckForIllegalCrossThreadCalls = false;
            console.Text += ("(" + DateTime.UtcNow.ToString() + ")> " + obj.ToString());
            console.Text += Environment.NewLine;
        }
        public int FindeIDOfConnectionInDataGridView(string sesionID)
        {
            for (int i = 0; i < listOfActiveConnectionDataGrid.Rows.Count; i++)
            {
                if (listOfActiveConnectionDataGrid.Rows[i].Cells[2].ToString() == sesionID)
                    return i;
            }
            throw new Exception("No Connection with this sessionID");
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void console_SizeChanged(object sender, EventArgs e)
        {
            tempTextBox.Location = new Point(console.Size.Width, console.Size.Height);
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            console.Size = panel1.Size;
        }

        private void MySend(object msg, connections conn) { 
        
            try
            {
                 conn.s.BeginSendTo(Encoding.ASCII.GetBytes(msg.ToString()), 0, msg.ToString().Length, 0, conn.EP as EndPoint , OnSend, conn);
            }
            catch (Exception ee) { Console.WriteLine(ee.ToString()); }
        }

    }
}
