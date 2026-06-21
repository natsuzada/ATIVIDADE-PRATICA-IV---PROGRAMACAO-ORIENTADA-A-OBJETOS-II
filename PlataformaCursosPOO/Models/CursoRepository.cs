using System.Collections.Generic;

public static class CursoRepository
{
public static List<Curso> ObterCursos()
{
CursoGratuito logica =
new CursoGratuito(
"Lógica de Programação",
"Fundamentos da Programação");

    logica.AdicionarAula(
        new Aula("Variáveis e Tipos", 30));

    logica.AdicionarAula(
        new Aula("Estruturas de Decisão", 45));

    CursoPago csharp =
        new CursoPago(
            "C# Completo",
            "Programação Orientada a Objetos",
            199.90);

    csharp.AdicionarAula(
        new Aula("Classes e Objetos", 50));

    csharp.AdicionarAula(
        new Aula("Herança e Polimorfismo", 60));

    CursoPago bancoDados =
        new CursoPago(
            "Banco de Dados",
            "SQL Server e Modelagem",
            149.90);

    bancoDados.AdicionarAula(
        new Aula("Modelagem de Dados", 40));

    bancoDados.AdicionarAula(
        new Aula("Consultas SQL", 55));

    return new List<Curso>
    {
        logica,
        csharp,
        bancoDados
    };
}

}
