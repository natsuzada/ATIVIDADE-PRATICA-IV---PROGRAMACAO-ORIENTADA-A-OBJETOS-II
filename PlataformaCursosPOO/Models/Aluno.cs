using System;
using System.Collections.Generic;
using System.Linq;

public class Aluno
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public List<Matricula> Matriculas { get; set; } = new();

    public Aluno(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }

    public void Matricular(Curso curso)
    {
        if (Matriculas.Any(m => m.Curso == curso))
            throw new Exception("Aluno já matriculado.");

        Matriculas.Add(new Matricula(curso));
    }

    public void VisualizarProgresso()
{
    foreach (var matricula in Matriculas)
    {
        Console.WriteLine(
            $"Curso: {matricula.Curso.Titulo} - Progresso: {matricula.Progresso}%");
    }
}
}