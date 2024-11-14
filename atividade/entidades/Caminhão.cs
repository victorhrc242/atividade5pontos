using atividade5pontos.entidades;

public class Caminhao : Veiculos
{
    public double CapacidadeCarga { get; set; }

    public override void exibirdetalhes()
    {
        base.exibirdetalhes();
        Console.WriteLine($"Capacidade de Carga: {CapacidadeCarga} toneladas");
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
