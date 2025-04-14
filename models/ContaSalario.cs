class ContaSalario(Pessoa titular, long numero, int agencia, double taxaSaque)
    : Conta(titular, numero, agencia, taxaSaque),
        IDepositavel
{
    private const string TRANSFERENCIA_INVALIDA =
        "Transferência só permitida para contas do mesmo titular.";

    public void Depositar(double valor)
    {
        Saldo += valor;
    }

    public int getIdDoTitular()
    {
        return Titular.Id;
    }

    public override void Transferir(IDepositavel depositavel, double valor)
    {
        if (Titular.Id == depositavel.getIdDoTitular())
        {
            base.Transferir(depositavel, valor);
        }
        else
        {
            throw new Exception(TRANSFERENCIA_INVALIDA);
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()}, \nTipo: Salário";
    }
}
