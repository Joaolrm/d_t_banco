public abstract class Conta(Pessoa titular, long numero, int agencia, double taxaSaque)
{
    private const string SALDO_INSUFICIENTE = "Saldo insuficiente";
    private const string VALOR_INVALIDO = "Valor inválido";
    private const string ERRO_DESCONHECIDO = "Erro desconhecido";
    private const string VALOR_INVALIDO_SAQUE = "Valor de saque inválido.";
    private const string SALDO_INSUFICIENTE_SAQUE = "Saldo insuficiente para saque.";
    public Pessoa Titular { get; set; } = titular;
    public long Numero { get; set; } = numero;
    public int Agencia { get; set; } = agencia;
    protected double Saldo { get; set; } = 0;
    public double TaxaSaque { get; set; } = taxaSaque;

    protected void RemoverSaldo(double valor)
    {
        if (valor > Saldo)
        {
            throw new Exception(SALDO_INSUFICIENTE);
        }
        if (valor < 0)
        {
            throw new Exception(VALOR_INVALIDO);
        }
        Saldo -= valor;
    }

    public void Sacar(double valor)
    {
        try
        {
            RemoverSaldo(valor + TaxaSaque);
        }
        catch (Exception ex)
        {
            throw ex.Message switch
            {
                SALDO_INSUFICIENTE => new Exception(SALDO_INSUFICIENTE_SAQUE),
                VALOR_INVALIDO => new Exception(VALOR_INVALIDO_SAQUE),
                _ => new Exception(ERRO_DESCONHECIDO),
            };
        }
    }

    public double ConsultarSaldo()
    {
        return Saldo;
    }

    public virtual void Transferir(IDepositavel depositavel, double valor)
    {
        Sacar(valor);
        depositavel.Depositar(valor);
    }
}
