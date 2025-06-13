using Microsoft.Data.Sqlite;

namespace SistemaMarmoreGranito;

public static class Database
{
    private const string ConnectionString = "Data Source=sistema.db";

    public static void Initialize()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Usuarios (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                Login TEXT NOT NULL,
                Senha TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Blocos (
                Codigo TEXT PRIMARY KEY NOT NULL,
                PedreiraOrigem TEXT NOT NULL,
                Metragem REAL NOT NULL,
                TipoMaterial TEXT NOT NULL,
                ValorCompra REAL NOT NULL,
                NotaFiscalEntrada TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Chapas (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                BlocoCodigo TEXT NOT NULL,
                TipoMaterial TEXT NOT NULL,
                Comprimento REAL NOT NULL,
                Largura REAL NOT NULL,
                Valor REAL NOT NULL,
                FOREIGN KEY (BlocoCodigo) REFERENCES Blocos(Codigo)
            );
        ";

        command.ExecuteNonQuery();
    }

    public static SqliteConnection GetConnection()
    {
        return new SqliteConnection(ConnectionString);
    }
}
