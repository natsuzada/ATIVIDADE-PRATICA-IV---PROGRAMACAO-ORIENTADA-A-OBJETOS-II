public class AlunoDTO
{
    public string Nome { get; set; } = "";
    public string Email { get; set; } = "";
    public List<string> Cursos { get; set; } = new();
    public string FormaPagamento { get; set; } = "";
    public double ValorTotal { get; set; }
}