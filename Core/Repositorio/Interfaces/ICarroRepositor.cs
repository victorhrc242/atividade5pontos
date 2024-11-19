using atividade5pontos.entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositorio.Interfaces
{
    public interface ICarroRepositor
    {
        public void Adicionar(Carro carro);

        public void Remover(int id);

        public List<Carro> Listar();

        public Carro BuscarPorId(int id);
     
    }
}
