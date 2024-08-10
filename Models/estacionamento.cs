using System;
using System.Collections.Generic;

public class Veiculo
{
    public string Placa { get; set; }
    public DateTime Entrada { get; set; }
    
    public Veiculo(string placa)
    {
        Placa = placa;
        Entrada = DateTime.Now;
    }
}

public class Estacionamento
{
    private int totalVagas;
    private List<Veiculo> veiculosNoEstacionamento;

    public Estacionamento(int vagas)
    {
        totalVagas = vagas;
        veiculosNoEstacionamento = new List<Veiculo>();
    }

    public bool RegistrarEntrada(string placa)
    {
        if (veiculosNoEstacionamento.Count >= totalVagas)
        {
            Console.WriteLine("Não há vagas disponíveis.");
            return false;
        }
        
        Veiculo veiculo = new Veiculo(placa);
        veiculosNoEstacionamento.Add(veiculo);
        Console.WriteLine($"Veículo com placa {placa} entrou.");
        return true;
    }

    public bool RegistrarSaida(string placa)
    {
        Veiculo veiculo = veiculosNoEstacionamento.Find(v => v.Placa == placa);
        if (veiculo == null)
        {
            Console.WriteLine("Veículo não encontrado.");
            return false;
        }

        veiculosNoEstacionamento.Remove(veiculo);
        Console.WriteLine($"Veículo com placa {placa} saiu.");
        return true;
    }

    public int ContarVagasOcupadas()
    {
        return veiculosNoEstacionamento.Count;
    }

    public int ContarVagasDisponiveis()
    {
        return totalVagas - ContarVagasOcupadas();
    }
}

public class Program
{
    public static void Main()
    {
        Estacionamento estacionamento = new Estacionamento(10);

        // Registrando entradas
        estacionamento.RegistrarEntrada("ABC123");
        estacionamento.RegistrarEntrada("XYZ789");

        // Verificando vagas
        Console.WriteLine($"Vagas ocupadas: {estacionamento.ContarVagasOcupadas()}");
        Console.WriteLine($"Vagas disponíveis: {estacionamento.ContarVagasDisponiveis()}");

        // Registrando saída
        estacionamento.RegistrarSaida("ABC123");

        // Verificando vagas novamente
        Console.WriteLine($"Vagas ocupadas: {estacionamento.ContarVagasOcupadas()}");
        Console.WriteLine($"Vagas disponíveis: {estacionamento.ContarVagasDisponiveis()}");
    }
}
