using Core.Repositorio.Interfaces;
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
        public void Adicionar(Caminhao caminhao)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Caminhao>(caminhao);
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
        public Caminhao BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Caminhao>(id);
        }
    }
}
