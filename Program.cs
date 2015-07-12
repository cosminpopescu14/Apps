using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace textToSha1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scrie ceva");
            string text = Console.ReadLine();
            var result = getSha1(text);

            Console.WriteLine("sha1 output: {0 : x2} ", result);
            Console.ReadLine();
        }

        public  static string getSha1(string text)
        {
            byte[] data = ASCIIEncoding.ASCII.GetBytes(text);//transformam toate caracterele textului in bytes necesar pt calcularea sha1
            byte [] hash_data;

            SHA1 sha = new SHA1CryptoServiceProvider();
            hash_data = sha.ComputeHash(data);
            StringBuilder strBldr = new StringBuilder();//clasa string builder

            foreach (var b in hash_data) // iteram prin hash_data
                      strBldr.Append(b.ToString("x2")); 
                
            return strBldr.ToString();
        }
    }

   
}
