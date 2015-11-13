using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Octokit;

namespace FunWithGithubAPI
{
    class FunWithGitHubAPI
    {
        static  void Main(string[] args)
        {
            GetUserInfo();
            Console.ReadLine();
        }

        public static async void GetUserInfo()//asynchronous method
        {
            var client = new GitHubClient(new ProductHeaderValue("app"));
            var user = await client.User.Get("cosminpopescu14");//github user

            //getting some information about user
            string UserName = user.Name;
            int Repos = user.PublicRepos;
            int Following = user.Following;
            int UserId = user.Id;
            string Email = user.Email;

            Console.WriteLine(" Usename: {0}\n Number of repos: {1}\n Number of people following: {2}\n User ID: {3}\n User's email address :{4}\n",
                                UserName, Repos, Following,
                                UserId, Email);
        }
    }
}
