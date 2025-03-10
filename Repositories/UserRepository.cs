using System.Data.SqlClient;
using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Blog.Repositories
{
    public class UserRepository :Repository<User>
    {
        private readonly SqlConnection _connection;
        public UserRepository(SqlConnection connection) : base(connection) => _connection = connection;

        public List<User> GetWithRoles()
        {
            var query = @"
                SELECT [USER].*, [ROLE].*
                FROM 
                [USER]
                LEFT JOIN [userRole] on [userRole].[UserId] =[USER].[Id]
                LEFT JOIN [ROLE] ON [userRole].[RoleId] = ROLE.Id
                ";
            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(u => u.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);
                        
                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);
                    return user;
                }, splitOn: "Id");
            return users;
        }

      




    }
}