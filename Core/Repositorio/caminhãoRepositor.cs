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
    public class caminhãoRepositor:Icaminhãorepositor
    {
        private readonly string ConnectionString;
        public caminhãoRepositor(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public long Adicionar(CreateCaminhao caminhao)
        {
            using var connection = new SQLiteConnection(ConnectionString);
          return  connection.Insert<CreateCaminhao>(caminhao);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Caminhao caminhao = BuscarPorId(id);
            connection.Delete<Caminhao>(caminhao);
        }
        public List<Caminhao> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Caminhao>().ToList();
        }
        public Caminhao BuscarPorVeiculoId(int veiculoId)
        {

            using var connection = new SQLiteConnection(ConnectionString);
            string query = "SELECT * FROM Caminhaos WHERE VeiculoId = @VeiculoId";
                return connection.QueryFirstOrDefault<Caminhao>(query, new { VeiculoId = veiculoId });
            
        }
        public Caminhao BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Caminhao>(id);
        }
    }
}
