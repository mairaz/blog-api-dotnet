using System;
using System.Data.SqlClient;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;


namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";
        static void Main(string[] args)
        {
            var _connection = new  SqlConnection(CONNECTION_STRING);
            _connection.Open();

            ReadUsers(_connection);
            /* createUser(); */
            _connection.Close();
        }

        public static void ReadUsers(SqlConnection _connection)
        {
            var repository = new UserRepository(_connection);
            var users = repository.Get();

            foreach (var user in users)
              Console.WriteLine(user.Name);
        }
        public static void createUser()
        {
            var user = new User()
            {
                Bio = "'",
                Email = "lost1@lost.com",
                Image = "http://",
                Name = "Srta Lost",
                PasswordHash = "###",
                Slug = "/qlq-coisa"
            };
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user);
                Console.WriteLine(user.Bio);
            }
        }


    }
}
