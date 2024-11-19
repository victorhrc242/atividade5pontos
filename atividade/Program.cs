Carro car=new Carro { modelo="usv",Ano=12,CapacidadeDeTanque=12.3,ConsumaPorKM=10.3,Tipo= "Híbrido" };
Carro car1 = new Carro { modelo = "sedn", Ano = 1980, CapacidadeDeTanque = 20.00, ConsumaPorKM = 2, Tipo = "Híbrido" };
Caminhao caminhao= new Caminhao {modelo="Scania",Ano= 1891 ,CapacidadeDeTanque=60.00,CapacidadeCarga=200.00,ConsumaPorKM=12.90};
Caminhao caminhao1 = new Caminhao { modelo = "Volvo", Ano = 1927, CapacidadeDeTanque = 40.00, CapacidadeCarga = 400.00, ConsumaPorKM = 12.90 };


List<IVeiculo> veiculos = new List<IVeiculo> { car,car1, caminhao1 };
foreach (IVeiculo veiculo in veiculos)
{
    Console.WriteLine(veiculo.exibirdetalhes()); 
    double distancia = 100;  
    double consumo = veiculo.CalcularConsumo(distancia);  
    Console.WriteLine($"Consumo para {distancia} km: {consumo} litros\n"); 
}

