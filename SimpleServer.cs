using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;


namespace TrialNetProgramming1
{
    class Server
    {
        public const int port = 100;//port used
        static void Main(string[] args)
        {
            try
            {
                IPAddress address = IPAddress.Parse("ipAddr");//server ip

                /*listen for incoming connection - ip and port*/
                TcpListener listener = new TcpListener(address, port);
                listener.Start();

                /*feedback to user*/
                Console.WriteLine("Listening to port ", port);
                Console.WriteLine("Local end point is : " + listener.LocalEndpoint);
                Console.WriteLine("Waiting for a connection...");

                while (true)
                {
                    /*accept request from socket*/
                    Socket socket = listener.AcceptSocket();
                    Console.WriteLine("Connection accepted from " + socket.RemoteEndPoint);

                    Thread socketTherad  = new Thread(() =>
                    {
                        //space  for  data
                        byte[] data = new byte[8012];
                        int k = socket.Receive(data);

                        //working with received data
                        for (int i = 0; i < k; i++)
                        {
                            // Console.WriteLine(Convert.ToChar(data[i]));
                            byte[] dataToHash = ASCIIEncoding.ASCII.GetBytes(data[i].ToString());
                            byte[] hashData = null;

                            SHA1 sha1 = new SHA1CryptoServiceProvider();
                            hashData = sha1.ComputeHash(dataToHash);

                            StringBuilder sb = new StringBuilder();

                            foreach (var item in hashData)
                                sb.Append(item.ToString("x2"));
                            byte[] hashedData = ASCIIEncoding.ASCII.GetBytes(sb.ToString());
                            socket.Send(hashedData);//sending processed data to client  
                        }

                        //send ack 
                        ASCIIEncoding asen = new ASCIIEncoding();
                        socket.Send(asen.GetBytes("Server received : "));
                        Console.WriteLine("Sent ack!\n");
                        socket.Send(data);

                        /*free resources*/
                        socket.Close();
                        listener.Stop();
                        Console.ReadLine();
                    });
                    socketTherad.Start();
                }      
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error..." + ex.Message);
            }
        }
    }
}
