using System;
using System.Linq;

namespace MongoBD_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataManager = new DataManager("mongodb://localhost:27017", "seminar");
            //var users = dataManager.GetUsers();
            var users = dataManager.GetUsersByName("c");
            foreach ( var user in users)
            {
                Console.WriteLine(string.Join(',', user.Values));
                /*if (user.Names.Contains("name")) 
                { 
                    Console.WriteLine(user["name"]); 
                }*/
            }
            var typedUsers = dataManager.GetUsersByNameTyped("c");
            foreach (var user in typedUsers)
            {
                Console.WriteLine(user.Name);
            }

            Console.ReadLine();
        }
    }
}
