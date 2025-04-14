class PessoaFisica : Pessoa
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string RG { get; set; }
    public string CPF { get; set; }
    public DateTime DataNasc { get; set; }

    private readonly int idade;
    private int Idade
    {
        get { return idade; }
    }

    private readonly string faixaEtaria;
    private string FaixaEtaria
    {
        get { return faixaEtaria; }
    }
    public double Renda { get; set; }

    public PessoaFisica(
        string nome,
        string sobrenome,
        string rg,
        string cpf,
        DateTime dataNasc,
        double renda,
        string endereco,
        string tel,
        string email
    )
        : base(endereco, tel, email)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        RG = rg;
        CPF = cpf;
        DataNasc = dataNasc;
        Renda = renda;
        idade = Auxiliar.CalcularIdade(dataNasc);
        faixaEtaria = Auxiliar.FaixaEtaria(Idade);
    }

    public override double getRendaOuFaturamento()
    {
        return Renda;
    }
}
