using Application;
using Domain.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var cliente = Identificacao();
    }

    static Pessoa Identificacao()
    {
        var cliente = new Cliente();

        Console.WriteLine("Seu número de identificação:");
        cliente.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Seu nome:");
        cliente.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        cliente.Cpf = Console.ReadLine();

        Console.WriteLine("Seu Saldo:");
        cliente.Saldo = float.Parse(Console.ReadLine());
        Console.Clear();

        Console.WriteLine($"Como posso ajudar {cliente.Nome}?");
        Menu(cliente);
        Console.ReadKey();

        return cliente;
    }

    private static void Menu(Cliente cliente)
    {
        int variavel = 0;
        Console.WriteLine("| ------------------------------------ |");
        Console.WriteLine("|           1 - Deposito               |");
        Console.WriteLine("|           2 - Saque                  |");
        Console.WriteLine("|           3 - Sair                   |");
        Console.WriteLine("| ------------------------------------ |");
        string opcaoMenu = Console.ReadLine();

        if (int.TryParse(opcaoMenu, out variavel))
        {
            switch (int.Parse(opcaoMenu))
            {
                case 1:
                    Deposito(cliente);
                    break;
                case 2:
                    Saque(cliente);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Menu(cliente);
                    break;
            }
            Console.ResetColor();
        }
        else
        {
            Console.Clear();
            Menu(cliente);
        }
    }

    private static void Deposito(Cliente cliente)
    {
        Console.Clear();
        Console.WriteLine("| ------------------------------------ |");
        Console.WriteLine("|           1 - Deposito               |");
        Console.WriteLine("|       Digite o valor do deposito:    |");
        Console.WriteLine("| ------------------------------------ |");
        float valorDeposito = float.Parse(Console.ReadLine());
        Console.Clear();

        cliente.Saldo = Calculo.Soma(cliente.Saldo, valorDeposito);
        ApresentarSaldo(cliente);
    }


    private static void Saque(Cliente cliente)
    {
        Console.Clear();
        Console.WriteLine("| ------------------------------------ |");
        Console.WriteLine("|           2 - Saque                  |");
        Console.WriteLine("|       Digite o valor do Saque:       |");
        Console.WriteLine("| ------------------------------------ |");
        float valorSaque = float.Parse(Console.ReadLine());
        Console.Clear();

        cliente.Saldo = Calculo.Subtracao(cliente.Saldo, valorSaque);
        ApresentarSaldo(cliente);
    }

    private static void ApresentarSaldo(Cliente cliente)
    {
        Console.WriteLine("| ------------------------------------ |");
        Console.WriteLine("|            Saldo Atual:              |");
        Console.WriteLine($"|              R${cliente.Saldo}                   |");
        Console.WriteLine("| ------------------------------------ |");

        Menu(cliente);
    }
}