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
        public const int port = 8001;
        static void Main(/*string[] args*/)
        {
            try
            {
                IPAddress address = IPAddress.Parse("ip address");

                TcpListener listener = new TcpListener(address, port);
                listener.Start();

                Console.WriteLine("listening to port ", port);
                Console.WriteLine("local end point is :" + listener.LocalEndpoint);
                Console.WriteLine("waiting for a connection...");

                Socket socket = listener.AcceptSocket();
                Console.WriteLine("connectio accepted from " + socket.RemoteEndPoint);

                byte[] data = new byte[1000];

                int k = socket.Receive(data);

                for (int i = 0; i < k; i++)
                {
                    // Console.WriteLine(Convert.ToChar(data[i]));
                    byte [] dataToHash = ASCIIEncoding.ASCII.GetBytes(data[i].ToString());
                    byte[] hashData = null;

                    SHA1 sha1 = new SHA1CryptoServiceProvider();
                    hashData = sha1.ComputeHash(dataToHash);
                    
                   StringBuilder sb = new StringBuilder();

                    foreach (var item in hashData)
                        sb.Append(item.ToString("x2"));
                        byte[] dd = ASCIIEncoding.ASCII.GetBytes(sb.ToString());
                        socket.Send(dd);  
                    
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
