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

            /* createUser(); 
            ReadUsers(_connection);
            AddRoles(_connection);
            ReadRoles(_connection);
            ReadUsersWithRoles(_connection);
            */
            
        
            _connection.Close();
        }

        public static void ReadUsers(SqlConnection _connection)
        {
            var repository = new UserRepository(_connection);
            var users = repository.Get();

            foreach (var user in users)
              Console.WriteLine(user.Name);
        }

        public static void ReadRoles (SqlConnection _connection)
        {
            var repository = new Repository<Role>(_connection);
            var roles = repository.Get();
            foreach (var role in roles)
                Console.WriteLine(role.Name);
        }
        
        public static void AddRoles (SqlConnection _connection)
        {
            var repository = new Repository<Role>(_connection);
            var newRole = new Role(){Name = "User", Slug = "user"};
            repository.Create(newRole);
      
        }
        

        public static void ReadUsersWithRoles(SqlConnection _connection)
        {
            var repository = new UserRepository(_connection);
            var users = repository.GetWithRoles();
            foreach (var user in users)
            {
                foreach (var role in user.Roles)
                {
                    Console.WriteLine(role.Name);
                }
            }
        }
        
        

    }
}
