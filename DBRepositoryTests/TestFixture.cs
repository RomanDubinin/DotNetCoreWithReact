using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestFixture
    {
        protected static string ConnectionString = "Host=127.0.0.1;User Id=postgres;Password=evrika;Database=testdb;";

        private string DbInitSql = @"
          create table if not exists ideom(
          id uuid unique not null,
          english_text text,
          russian_text text);";

        private string DbCleanSql = @"
          drop table if exists ideom;";

        [SetUp]
        public async Task Setup()
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                await connection.OpenAsync(CancellationToken.None);
                await connection.ExecuteAsync(DbCleanSql).ConfigureAwait(false);
                await connection.ExecuteAsync(DbInitSql).ConfigureAwait(false);
            }
        }

        [TearDown]
        public async Task TearDown()
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                await connection.OpenAsync(CancellationToken.None);
                await connection.ExecuteAsync(DbCleanSql).ConfigureAwait(false);
            }
        }
    }
}