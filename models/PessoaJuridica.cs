class PessoaJuridica : Pessoa
{
    public List<PessoaFisica> socios = [];
    public int Cnpj { get; set; }
    public string RazaoSocial { get; set; }
    public string NomeFantasia { get; set; }
    public string InscricaoEstadual { get; set; }
    public DateTime DataAbertura { get; set; }
    private readonly int idade;

    private int Idade
    {
        get { return idade; }
    }
    public double Faturamento { get; set; }

    public PessoaJuridica(
        int cnpj,
        string razaoSocial,
        string nomeFantasia,
        string inscricaoEstadual,
        DateTime dataAbertura,
        PessoaFisica socio,
        double faturamento,
        string endereco,
        string tel,
        string email
    )
        : base(endereco, tel, email)
    {
        Cnpj = cnpj;
        RazaoSocial = razaoSocial;
        NomeFantasia = nomeFantasia;
        InscricaoEstadual = inscricaoEstadual;
        DataAbertura = dataAbertura;
        AdicionarSocio(socio);
        idade = Auxiliar.CalcularIdade(dataAbertura);
        Faturamento = faturamento;
    }

    public void AdicionarSocio(PessoaFisica socio)
    {
        socios.Add(socio);
    }

    public override double getRendaOuFaturamento()
    {
        return Faturamento;
    }
}
