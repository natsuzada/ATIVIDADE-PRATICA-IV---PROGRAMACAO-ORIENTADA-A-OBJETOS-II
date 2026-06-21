using System.Collections.Generic;

public abstract class Curso
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public List<Aula> Aulas { get; set; }

    public Curso(string titulo, string descricao)
    {
        Titulo = titulo;
        Descricao = descricao;
        Aulas = new List<Aula>();
    }

    public void AdicionarAula(Aula aula)
    {
        Aulas.Add(aula);
    }
}