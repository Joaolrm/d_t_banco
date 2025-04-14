class ContaSalario(Pessoa titular, long numero, int agencia, double taxaSaque)
    : Conta(titular, numero, agencia, taxaSaque),
        IDepositavel
{
    public void Depositar(double valor)
    {
        throw new NotImplementedException();
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
            throw new Exception("Transferência só permitida para contas do mesmo titular.");
        }
    }
}
