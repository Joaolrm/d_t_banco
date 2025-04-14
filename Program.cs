using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        // Criação de objetos e teste de funcionalidades
        PessoaFisica pf1 = new(
            "João",
            "Moura",
            "12345678901",
            "60000000000",
            new DateTime(2003, 4, 28),
            2000.00,
            "Rua 1",
            "99999999999",
            "email@email.com.br"
        );
        Console.WriteLine(pf1);
        PessoaFisica pf2 = new(
            "João2",
            "Moura2",
            "12345678901",
            "60000000000",
            new DateTime(2012, 4, 28),
            6000.00,
            "Rua 1",
            "99999999999",
            "email@email.com.br"
        );
        Console.WriteLine(pf2);

        // Criação de contas salário
        ContaSalario cs1 = new(pf1, 123456789, 1234, 0.00);
        ContaSalario cs2 = new(pf2, 123456789, 1234, 3.00);
        cs1.Depositar(1000.00);
        cs2.Depositar(1000.00);
        Console.WriteLine();
        Console.WriteLine(cs1);
        try
        {
            cs1.Transferir(cs2, 500.00);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message); // Exibe mensagem de erro já que não é permitido transferir de conta salário para conta de outra pessoa
        }
        try
        {
            cs2.Sacar(1000.00);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message); // Exibe mensagem de erro já taxa de saque + valor de saque é maior q o saldo
        }
        cs2.Sacar(997.00); // Sacar valor menor que o saldo cosiderando a taxa
        Console.WriteLine(cs2);
        cs2.Depositar(1000.00);
        ContaCorrente cc1 = new(pf2, 123456789, 1234, 2.00);
        cs2.Transferir(cc1, 1000.00);
        Console.WriteLine(cc1);
        cc1.Sacar(13998.00); // Saque bem sucedido
        Console.WriteLine(cc1);
        cc1.Sacar(1000.00); // Saque bem sucedido, para testar se da para sacar mais de uma vez usando o limite
        Console.WriteLine(cc1);
        try
        {
            cc1.Sacar(1000.00);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message); // Erro esperado estourou o limite
        }
        PessoaJuridica pj1 = new(
            123456789, // Example CNPJ
            "Empresa X", // Example company name
            "12345678000199", // Example company registration number
            "60000000000", // Example tax ID
            new DateTime(2010, 1, 1), // Example foundation date
            pf1, // Example owner (PessoaFisica object)
            100000.00, // Example capital
            "Avenida Principal", // Example address
            "88888888888", // Example phone number
            "empresa@email.com" // Example email
        );
        Console.WriteLine(pj1);
        ContaCorrente cc2 = new(pj1, 123456789, 1234, 2.00);
        cc2.Sacar(1000.00); // Saque bem sucedido
        Console.WriteLine(cc2);
    }
}
