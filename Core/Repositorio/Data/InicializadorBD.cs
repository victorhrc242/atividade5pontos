using Dapper;
using System;
using System.Data.SQLite;

namespace Core.Repositorio.Data
{
    public static class InicializadorBD
    {
        private const string ConnectionString = "Data Source=CalcularKM.db";

        public static void Inicializar()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS Veiculoss (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        modelo TEXT NOT NULL,
                        Ano INT NOT NULL,
                        CapacidadeDeTanque DOUBLE NOT NULL,
                        ConsumaPorKM DOUBLE NOT NULL
                    );";

                connection.Execute(commandoSQL);

                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS Carrinhos (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Tipo TEXT NOT NULL,
                        modelo TEXT NOT NULL,
                        Ano INT NOT NULL,
                        CapacidadeDeTanque DOUBLE NOT NULL,
                        ConsumaPorKM DOUBLE NOT NULL
                    );";

                connection.Execute(commandoSQL);

                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS Caminhaos (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        CapacidadeCarga DOUBLE NOT NULL,
                        modelo TEXT NOT NULL,
                        Ano INT NOT NULL,
                        CapacidadeDeTanque DOUBLE NOT NULL,
                        ConsumaPorKM DOUBLE NOT NULL
                    );";

                connection.Execute(commandoSQL);
            }
        }
    }
}
