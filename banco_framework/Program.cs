using Domain.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var pessoa = Identificacao();
    }

    static Pessoa Identificacao()
    {
        var pessoa = new Pessoa();

        Console.WriteLine("Seu número de identificação:");
        pessoa.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Seu nome:");
        pessoa.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        pessoa.Cpf = Console.ReadLine();
        Console.Clear();

        Console.WriteLine($"Como posso ajudar {pessoa.Nome}?");
        Menu();
        Console.ReadKey();

        return pessoa;
    }

    private static void Menu()
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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" 1 - Deposito");
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" 2 - Saque");
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Menu();
                    break;
            }
            Console.ResetColor();
        }
        else
        {
            Console.Clear();
            Menu();
        }


    }
}