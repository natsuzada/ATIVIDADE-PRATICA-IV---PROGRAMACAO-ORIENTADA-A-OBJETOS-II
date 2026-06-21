using System;

public class Matricula : IProgresso
{
    public DateTime Data { get; set; }
    public double Progresso { get; private set; }
    public Curso Curso { get; set; }

    public Matricula(Curso curso)
    {
        Curso = curso;
        Data = DateTime.Now;
    }

    public void AtualizarProgresso(double percentual)
    {
        Progresso = percentual;
    }
}