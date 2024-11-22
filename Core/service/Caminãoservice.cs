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
using System.Text;
using System.Threading.Tasks;

namespace Core.service
{
    public class Caminãoservice : Icaminhãoservice
    {
        private readonly Icaminhãorepositor _icaminhãorepositor;
        private readonly IConfiguration _configuration;
        private readonly IVeiculoRepositor _veiculorepositor;
        public Caminãoservice(IVeiculoRepositor veiculoRepositor, Icaminhãorepositor icaminhãorepositor, IConfiguration configuration)
        {
            _icaminhãorepositor = icaminhãorepositor;
            _configuration = configuration;
            _veiculorepositor = veiculoRepositor;
        }
        public void Adicionar(Caminhao caminhao)
        {
            Veiculos veiculo = new Veiculos()
            {
                Ano = caminhao.Ano,
                modelo = caminhao.modelo,
                CapacidadeDeTanque = caminhao.CapacidadeDeTanque,
                ConsumaPorKM = caminhao.ConsumaPorKM
            };
            _veiculorepositor.Adicionar(veiculo);
            CreateCaminhao c = new CreateCaminhao()
            {
                VeiculoId = veiculo.Id,
                CapacidadeCarga=caminhao.CapacidadeCarga,
            };
            long id = _icaminhãorepositor.Adicionar(c);
        }
        public void Remover(int id)
        {
            _icaminhãorepositor.Remover(id);
        }

        public List<Caminhao> BuscarPorVeiculoId(int id)
{
    // Buscar o veículo pelo ID diretamente
    var veiculo = _veiculorepositor.BuscarPorId(id); // Método para buscar veículo pelo ID

    // Se o veículo não for encontrado, retornar uma lista vazia
    if (veiculo == null)
        return new List<Caminhao>();

    // Buscar o caminhão correspondente ao veículo
    var caminhão = _icaminhãorepositor.BuscarPorVeiculoId(id); // Método para buscar caminhão pelo ID do veículo

    // Se o caminhão não for encontrado, retornar uma lista vazia
    if (caminhão == null)
        return new List<Caminhao>();

    // Criar a lista de caminhões e adicionar o caminhão encontrado
    return new List<Caminhao>
    {
        new Caminhao
        {
            Id = caminhão.Id,
            modelo = veiculo.modelo,
            Ano = veiculo.Ano,
            CapacidadeDeTanque = veiculo.CapacidadeDeTanque,
            ConsumaPorKM = veiculo.ConsumaPorKM,
            CapacidadeCarga = caminhão.CapacidadeCarga
        }
    };
}

        public Caminhao BuscarPorId(int id)
        {
            return _icaminhãorepositor.BuscarPorId(id);
        }
    }
}
