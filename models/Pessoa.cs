public abstract class Pessoa(string endereco, string tel, string email)
{
    public static int NumeroDePessoas { get; set; } = 0;

    public int Id { get; set; } = ++NumeroDePessoas;
    public required string Endereco { get; set; } = endereco;
    public required string Tel { get; set; } = tel;
    public required string Email { get; set; } = email;

    public abstract double getRendaOuFaturamento();
}
