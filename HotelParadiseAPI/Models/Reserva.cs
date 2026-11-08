namespace HotelParadiseAPI.Models;

public class Reserva{
    public int Id {get; set;}

    public int HospedeId { get; set; }
    public Hospede Hospede {get; set;} = null!;

    public int QuartoNumero { get; set; }
    public Quarto Quarto {get; set;} = null!;
    
    public DateTime DataEntrada {get; set;}
    public DateTime DataSaida {get; set;}
    public decimal ValorTotal {get; set;}
    
}