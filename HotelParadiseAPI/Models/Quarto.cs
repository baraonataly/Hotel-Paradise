namespace HotelParadiseAPI.Models;

public class Quarto{
    public int Numero { get; set; }
    public string Tipo { get; set; } = "";  // Solteiro, Casal, Suite
    public int Capacidade { get; set; }
    public decimal ValorDiaria { get; set; }
    public bool Disponibilidade { get; set; } = true;
    
    public Quarto(){}

    public Quarto(int numero, string tipo, int capacidade, decimal valorDiaria){
        Numero = numero;
        Tipo = tipo;
        Capacidade = capacidade;
        ValorDiaria = valorDiaria;
    }

    public void Ocupar(){
        Disponibilidade = false;
    }

    public void Liberar(){
        Disponibilidade = true;
    }
}