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
            Console.WriteLine("Write something...");
            string text = Console.ReadLine();
            var result = getSha1(text);

            Console.WriteLine("sha1 output: {0 : x2} ", result);
            Console.ReadLine();    
        }

        //method getSha1 receive a text as a parameter and compute sha1 function fot received text
        //exemple : cosmin - ff89d6092ac5f4531ddd8242921f086fbf421ed1
        public static string getSha1(string text)
        {
            byte [] data = ASCIIEncoding.ASCII.GetBytes(text);//encode all the  chars from my text into bytes
            byte [] hash_data = null; //the result of function

            SHA1 sha = new SHA1CryptoServiceProvider();
            hash_data = sha.ComputeHash(data);//computing SHA1 function

            StringBuilder strBldr = new StringBuilder();

            foreach (var b in hash_data) 
                      strBldr.Append(b.ToString("x2")); 
                
            return strBldr.ToString();
        }
    }

   
}
