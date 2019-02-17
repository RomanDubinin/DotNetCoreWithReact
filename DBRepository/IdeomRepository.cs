using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Models;
using Npgsql;

namespace DBRepository
{
    public class IdeomRepository
    {
        private string connectionString { get; }

        public IdeomRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task SaveAsync(Ideom ideom, CancellationToken cancellation)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync(cancellation);
                await connection.ExecuteAsync(SaveSql,
                    new
                    {
                        ideom.Id,
                        ideom.EnglishText,
                        ideom.RussianText
                    }).ConfigureAwait(false);
            }
        }

        public async Task<List<Ideom>> SelectAsync()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var ideoms = await connection
                    .QueryAsync<Ideom>(SelectSql)
                    .ConfigureAwait(false);
                return ideoms.ToList();
            }
        }

        private readonly string SaveSql = @"
            insert into ideom
            (id, english_text, russian_text)
            values
            (@Id, @EnglishText, @RussianText);";

        private readonly string SelectSql = @"
            select id Id, english_text EnglishText, russian_text RussianText from ideom;";
    }
}