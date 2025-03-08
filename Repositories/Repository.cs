using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
namespace Blog.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection) => _connection = connection;

        public IEnumerable<T> Get() => _connection.GetAll<T>();

        public T Get(T value) => _connection.Get<T>(value);

        public void Create(T model) => _connection.Insert(model);
        public void Update(T model) => _connection.Update<T>(model);
        public void Delete(int id)
        {
            var model = _connection.Get<T>(id);
            _connection.Delete<T>(model);

        }
    }
}