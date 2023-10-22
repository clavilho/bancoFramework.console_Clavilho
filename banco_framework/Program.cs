using Application;
using CpfCnpjLibrary;
using Domain.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        Identificacao();
    }

    static Pessoa Identificacao()
    {
        var cliente = new Cliente();

        do
        {
            InformacoesCadastro(cliente);

            if (cliente.Validacoes.Count > 0 )
            {
                Console.Clear();
                foreach (var item in cliente.Validacoes)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("");
                }
                Console.ReadKey();
                Console.Clear();
            }

        } while (cliente.Validacoes.Count > 0);
          
        
       
            Console.WriteLine($"Como posso ajudar {cliente.Nome}?");
            Menu(cliente);

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

    private static void InformacoesCadastro(Cliente cliente)
    {
        cliente.Validacoes = new List<string>();
        Console.WriteLine("Seu número de identificação:");
        cliente.SetId(Console.ReadLine());

        Console.WriteLine("Seu nome:");
        cliente.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        string cpf = Console.ReadLine();
        bool cpfValido = Cpf.Validar(cpf);
        cliente.SetCpf(cpfValido, cpf);


        Console.WriteLine("Seu Saldo:");
        cliente.setSaldo(Console.ReadLine());
        Console.Clear();
    }
}