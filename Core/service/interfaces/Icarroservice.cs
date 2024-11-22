using Core.Repositorio;
using Core.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.service.interfaces
{
    public interface Icarroservice
    {
        public void Adicionar(Carro carro);

        public void Remover(int id);

        public List<Carro> Listar();

        public List<Carro> BuscarPorVeiculoId(int id);

        public Carro BuscarPorId(int id);

    }
}
