using atividade5pontos.entidades;

public class Caminhao : Veiculos
{
    public double CapacidadeCarga { get; set; }

    public override string exibirdetalhes()
    {
      string mensagenretorno=  base.exibirdetalhes();
        mensagenretorno=$"Capacidade de Carga: {CapacidadeCarga} toneladas";
    return mensagenretorno;
    }

   
    public override double CalcularConsumo(double distancia)
    {
        double consumo = base.CalcularConsumo(distancia);
        if (CapacidadeCarga > 10)  
        {
            consumo *= 1.2;  
        }
        return consumo;
    }
}
