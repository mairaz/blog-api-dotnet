using System.Data.SqlClient;
using Blog.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Repositories
{
    public class UserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) => _connection = connection;

        public IEnumerable<User> Get() => _connection.GetAll<User>();
        public User Get(int id) => _connection.Get<User>(id);
        public void Create(User user) => _connection.Insert(user);
        public void Update(User user) => _connection.Update<User>(user);
        public void Delete(int id){
            var user =_connection.Get<User>(id);
            _connection.Delete<User>(user);
        } 




    }
}