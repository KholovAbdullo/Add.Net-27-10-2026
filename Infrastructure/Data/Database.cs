using Npgsql;

namespace Infrastructure.Data;

public class Database
{
    private static string ConnectionString="Host=localhost;Port=5432;Database=HomeTask;Username=postgres;Password=1234";
     public static NpgsqlConnection Connection()=>new NpgsqlConnection(ConnectionString);
}
