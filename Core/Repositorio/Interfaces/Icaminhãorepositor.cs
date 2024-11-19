using atividade5pontos.entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositorio.Interfaces
{
    public interface Icaminhãorepositor
    {
        public void Adicionar(Caminhao caminhao);

        public void Remover(int id);

        public List<Caminhao> Listar();

        public Caminhao BuscarPorId(int id);

    }
}
