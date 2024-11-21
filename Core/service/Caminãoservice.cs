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
        public List<Caminhao> Listar()
        {
            // Obtendo todos os veículos
            var veiculos = _veiculorepositor.Listar(); // Supondo que você tenha um método Listar no repositório de Veículos

            // Criando uma lista para armazenar os caminhões
            List<Caminhao> caminhões = new List<Caminhao>();

            // Para cada veículo, vamos verificar se ele está na tabela de Caminhaos
            foreach (var veiculo in veiculos)
            {
                // Buscar o caminhão correspondente ao veículo
                var caminhão = _icaminhãorepositor.BuscarPorVeiculoId(veiculo.Id);

                if (caminhão != null)
                {
                    // Criar um objeto Caminhao e preencher as propriedades
                    Caminhao caminhao = new Caminhao()
                    {
                        Id = caminhão.Id,
                        modelo = veiculo.modelo,
                        Ano = veiculo.Ano,
                        CapacidadeDeTanque = veiculo.CapacidadeDeTanque,
                        ConsumaPorKM = veiculo.ConsumaPorKM,
                        CapacidadeCarga = caminhão.CapacidadeCarga
                    };

                    // Adicionar o caminhão à lista
                    caminhões.Add(caminhao);
                }
            }

            // Retornar a lista de caminhões
            return caminhões;
        }
        public Caminhao BuscarPorId(int id)
        {
            return _icaminhãorepositor.BuscarPorId(id);
        }
    }
}
