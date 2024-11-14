using atividade5pontos.entidades;

public class Carro : Veiculos
{
    public string Tipo { get; set; }  // Tipo do carro, como "Hatch", "Sedan", etc.

    // Exibindo detalhes específicos do carro
    public override void exibirdetalhes()
    {
        base.exibirdetalhes();
        Console.WriteLine($"Tipo: {Tipo}");
    }

    // Alterando o cálculo de consumo dependendo do tipo de carro (por exemplo, híbrido)
    public override double CalcularConsumo(double distancia)
    {
        double consumo = base.CalcularConsumo(distancia);
        if (Tipo == "Híbrido")
        {
            consumo *= 0.8;  // Híbridos consomem 20% menos combustível
        }
        return consumo;
    }
}
