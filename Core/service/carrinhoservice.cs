using atividade5pontos.entidades;
using Core.DTO;
using Core.Repositorio;
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
        Carro carro = new Carro();
        public List<Carro> BuscarPorVeiculoId(int id)
        {
            // Buscar o veículo pelo ID diretamente
            var veiculo = _veiculoRepositor.BuscarPorId(id); // Método para buscar veículo pelo ID

            // Se o veículo não for encontrado, retornar uma lista vazia
            if (veiculo == null)
                return new List<Carro>();

            // Buscar o caminhão correspondente ao veículo
            var caminhão = _carroRepositor.BuscarPorVeiculoId(id); // Método para buscar caminhão pelo ID do veículo

            // Se o caminhão não for encontrado, retornar uma lista vazia
            if (caminhão == null)
                return new List<Carro>();

            // Criar a lista de caminhões e adicionar o caminhão encontrado
            return new List<Carro>
    {
        new Carro
        {
           
            Id = veiculo.Id,
            modelo = veiculo.modelo,
            Ano = veiculo.Ano,
            CapacidadeDeTanque = veiculo.CapacidadeDeTanque,
            ConsumaPorKM = veiculo.ConsumaPorKM,
            Tipo=carro.Tipo,
            
        }
    };
        }
        public Carro BuscarPorId(int id)
        {
          return _carroRepositor.BuscarPorId(id);
        }
    }
}
