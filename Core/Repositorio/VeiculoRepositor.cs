using atividade5pontos.entidades;
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
    public class VeiculoRepositor: IVeiculoRepositor
    {
        private readonly string ConnectionString;
        public VeiculoRepositor(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public void Adicionar(Veiculos veiculos)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Veiculos>(veiculos);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Veiculos veiculos = BuscarPorId(id);
            connection.Delete<Veiculos>(veiculos);
        }
        public List<Veiculos> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Veiculos>().ToList();
        }
        public Veiculos BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Veiculos>(id);
        }
    }
}
