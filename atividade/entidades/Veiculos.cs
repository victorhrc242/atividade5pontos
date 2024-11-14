using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividade5pontos.entidades
{
    public class Veiculos:IVeiculo
    {
        public string modelo { get; set; }
        public int Ano { get; set; }
        public double CapacidadeDeTanque { get; set; }
        public double ConsumaPorKM { get; set; }
        public virtual void exibirdetalhes()
        {
            Console.WriteLine($"o modelo e:{modelo}  Ano  {Ano}  " +
           $"capacidade de tanque={CapacidadeDeTanque} ei consumo que o veiculo faz por KM  e de:{ConsumaPorKM}");
        }
        public virtual double CalcularConsumo(double distancia)
        {
            return distancia / ConsumaPorKM;
        }

    }
}
