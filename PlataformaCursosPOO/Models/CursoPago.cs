public class CursoPago : Curso
{
    public double Valor { get; set; }

    public CursoPago(string titulo, string descricao, double valor)
        : base(titulo, descricao)
    {
        Valor = valor;
    }
}