public abstract class Pessoa(string endereco, string tel, string email)
{
    public static int NumeroDePessoas { get; set; } = 0;

    public int Id { get; set; } = ++NumeroDePessoas;
    public string Endereco { get; set; } = endereco;
    public string Tel { get; set; } = tel;
    public string Email { get; set; } = email;

    public abstract double getRendaOuFaturamento();

    public override string ToString()
    {
        return $"Id: {Id}, \nEndereço: {Endereco}, \nTelefone: {Tel}, \nE-mail: {Email}";
    }
}
