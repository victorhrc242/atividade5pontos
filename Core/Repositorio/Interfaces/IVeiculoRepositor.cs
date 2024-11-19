using atividade5pontos.entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositorio.Interfaces
{
    public interface IVeiculoRepositor
    {
        public void Adicionar(Veiculos veiculos);

        public void Remover(int id);

        public List<Veiculos> Listar();

        public Veiculos BuscarPorId(int id);
      
    }
}
