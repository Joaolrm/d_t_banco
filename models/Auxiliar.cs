static class Auxiliar
{
    public static string FaixaEtaria(int idade)
    {
        return idade switch
        {
            <= 11 => "criança",
            >= 12 and <= 21 => "jovem",
            >= 22 and <= 59 => "adulto",
            >= 60 => "idoso",
        };
    }

    public static int CalcularIdade(DateTime data)
    {
        return DateTime.Now.Year - data.Year;
    }
}
