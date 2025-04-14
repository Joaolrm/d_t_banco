using System.Runtime.CompilerServices;

public class ContaCorrente : Conta, IDepositavel
{
    private readonly string tipo;
    private string Tipo
    {
        get { return tipo; }
    }
    private readonly double limite;
    private double Limite
    {
        get { return limite; }
    }
    private readonly double taxaDoLimite;
    private double TaxaDoLimite
    {
        get { return taxaDoLimite; }
    }

    public void Pagar(string codigoDeBarras) { }

    public void Emprestimo(double valor) { }

    public void Depositar(double valor)
    {
        Saldo += valor;
    }

    public int getIdDoTitular()
    {
        return Titular.Id;
    }

    public ContaCorrente(
        double limite,
        double taxaDoLimite,
        Pessoa titular,
        long numero,
        int agencia,
        double taxaSaque
    )
        : base(titular, numero, agencia, taxaSaque)
    {
        this.limite = limite;
        this.taxaDoLimite = taxaDoLimite;
        this.tipo = Titular.getRendaOuFaturamento() switch
        {
            > 5000.00 => "ESPECIAL",
            _ => "SIMPLES",
        };

        if (Tipo == "ESPECIAL")
        {
            this.limite = Titular.getRendaOuFaturamento() * 2.5;
            this.taxaDoLimite = 0.02;
        }
        else if (Tipo == "SIMPLES")
        {
            this.limite = Titular.getRendaOuFaturamento() * 1.5;
            this.taxaDoLimite = 0.05;
        }
        else
        {
            throw new Exception("Tipo de conta inválido");
        }
    }
}
