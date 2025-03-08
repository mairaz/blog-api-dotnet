

using System.Data.SqlClient;
using Blog.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Repositories
{
    public class RoleRepository: Repository<Role>
    {
        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection connection) : base(connection) => _connection = connection;


        
    }
}