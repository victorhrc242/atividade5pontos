using Core.DTO;
using Core.Repositorio.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositorio
{
    public class Carrinhorepositor: ICarroRepositor
    {
        private readonly string ConnectionString;
        public Carrinhorepositor(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public long Adicionar(CreateCarroDTO carro)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Insert<CreateCarroDTO>(carro);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Carro carro = BuscarPorId(id);
            connection.Delete<Carro>(carro);
        }
        public Carro BuscarPorVeiculoId(int veiculoId)
        {

            using var connection = new SQLiteConnection(ConnectionString);
            string query = "SELECT * FROM Carros WHERE VeiculoId = @VeiculoId";
            return connection.QueryFirstOrDefault<Carro>(query, new { VeiculoId = veiculoId });

        }
        public List<Carro> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Carro>().ToList();
        }
        public Carro BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Carro>(id);
        }
    }
}
