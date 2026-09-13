using System;
class Hospede{
    public int Id;
    public string Nome;
    public string CPF;
    public string Telefone;

    public Hospede(int id, string nome, string cpf, string telefone)
    {
        Id = id;
        Nome = nome;
        CPF = cpf;
        Telefone = telefone;
    }

    public void ExibirDados()
    {
        Console.WriteLine("ID: " + Id);
        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("CPF: " + CPF);
        Console.WriteLine("Telefone: " + Telefone);
    }

}