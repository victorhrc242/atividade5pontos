using atividade5pontos.entidades;

public class Carro : Veiculos
{
    public string Tipo { get; set; }  

   
    public override void exibirdetalhes()
    {
        base.exibirdetalhes();
        Console.WriteLine($"Tipo: {Tipo}");
    }
    public override double CalcularConsumo(double distancia)
    {
        double consumo = base.CalcularConsumo(distancia);
        if (Tipo == "Híbrido")
        {
            consumo *= 0.8;  
        }
        return consumo;
    }
}
