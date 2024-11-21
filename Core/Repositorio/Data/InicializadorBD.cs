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
            CREATE TABLE IF NOT EXISTS Carros (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                VeiculoId INTEGER NOT NULL,  -- Relacionamento com a tabela Veiculos
                Tipo TEXT NOT NULL,
                FOREIGN KEY (VeiculoId) REFERENCES Veiculos(Id)
            );";

                connection.Execute(commandoSQL);

                commandoSQL = @"
            CREATE TABLE IF NOT EXISTS Caminhaos (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                VeiculoId INTEGER NOT NULL,  -- Relacionamento com a tabela Veiculos
                CapacidadeCarga DOUBLE NOT NULL,
                FOREIGN KEY (VeiculoId) REFERENCES Veiculos(Id)
            );";

                connection.Execute(commandoSQL);
            }
        }

    }
}
