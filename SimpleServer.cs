using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace TrialNetProgramming1
{
    class Server
    {
        public const int port = 80;
        static void Main(/*string[] args*/)
        {
            try
            {
                IPAddress address = IPAddress.Parse("192.168.0.100");

                TcpListener listener = new TcpListener(address, port);
                listener.Start();

                Console.WriteLine("listening to port ", port);
                Console.WriteLine("local end point is :" + listener.LocalEndpoint);
                Console.WriteLine("waiting for a connection...");

                Socket socket = listener.AcceptSocket();
                Console.WriteLine("connectio accepted from " + socket.RemoteEndPoint);

                byte[] data = new byte[1000];

                int k = socket.Receive(data);
                //Console.WriteLine("Received");
                for (int i = 0; i < k; i++)
                
                {
                    
                    byte[] hashData = null;

                    SHA1 sha = new SHA1CryptoServiceProvider();
                    
                }    
                    

               
                ASCIIEncoding asen = new ASCIIEncoding();
                socket.Send(asen.GetBytes("the string was received from srver : "));
                socket.Send(data);
                Console.WriteLine("Sent ack!\n");
                
                socket.Close();
                listener.Stop();
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("error..." + ex.StackTrace);
            }
        }
    }
}












/*
  static TcpListener listener;
  listener = new TcpListener(80);
            listener.Start();
            Console.WriteLine("listening...");
            Console.ReadLine();

*/
