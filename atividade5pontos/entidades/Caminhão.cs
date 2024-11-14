using atividade5pontos.entidades;

public class Caminhao : Veiculos
{
    public double CapacidadeCarga { get; set; }  // Capacidade de carga em toneladas

    // Exibindo detalhes específicos do caminhão
    public override void exibirdetalhes()
    {
        base.exibirdetalhes();
        Console.WriteLine($"Capacidade de Carga: {CapacidadeCarga} toneladas");
    }

    // Alterando o cálculo de consumo para considerar o peso da carga
    public override double CalcularConsumo(double distancia)
    {
        double consumo = base.CalcularConsumo(distancia);
        if (CapacidadeCarga > 10)  // Caminhões com carga acima de 10 toneladas consomem mais
        {
            consumo *= 1.2;  // Aumenta o consumo em 20% para cargas mais pesadas
        }
        return consumo;
    }
}
