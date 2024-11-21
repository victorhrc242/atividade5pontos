using atividade5pontos.entidades;
using Core.DTO;
using Core.Repositorio.Interfaces;
using Core.service.interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.service
{
    public class carrinhoservice:Icarroservice
    {
        private readonly ICarroRepositor _carroRepositor;
        private readonly IVeiculoRepositor _veiculoRepositor;
        private readonly IConfiguration _configuration;
        public carrinhoservice(IVeiculoRepositor veiculoRepositor,ICarroRepositor carroRepositor,IConfiguration configuration)
        {
            _carroRepositor= carroRepositor;
            _configuration= configuration;
            _veiculoRepositor= veiculoRepositor;
        }
        public void Adicionar(Carro carro)
        {
            // logica feita pelo paulo
            Veiculos veiculo = new Veiculos()
            {
                Ano = carro.Ano,
                modelo = carro.modelo,
                CapacidadeDeTanque = carro.CapacidadeDeTanque,
                ConsumaPorKM = carro.ConsumaPorKM
            };
            _veiculoRepositor.Adicionar(veiculo);
            CreateCarroDTO c = new CreateCarroDTO()
            {
                VeiculoId = veiculo.Id,
                Tipo = carro.Tipo
            };
        long id = _carroRepositor.Adicionar(c);
        }
        public void Remover(int id)
        {
         _carroRepositor.Remover(id);
        }
        public List<Carro> Listar()
        {
           return _carroRepositor.Listar();
        }
        public Carro BuscarPorId(int id)
        {
          return _carroRepositor.BuscarPorId(id);
        }
    }
}
