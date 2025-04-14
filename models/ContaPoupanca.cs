class ContaPoupanca(Pessoa pessoa, long numero, int agencia)
    : Conta(pessoa, numero, agencia, TAXA_SAQUE),
        IDepositavel
{
    private const double TAXA_SAQUE = 2.25;

    public void Depositar(double valor)
    {
        Saldo += valor;
    }

    public int getIdDoTitular()
    {
        return Titular.Id;
    }
}
