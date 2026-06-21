using System;
using System.Collections.Generic;

public static class SistemaCursos
{
public static void Executar()
{
    List<AlunoDTO> alunos = JsonRepository.Carregar();

    while (true)
    {
        Console.Clear();

        Console.WriteLine("==== PLATAFORMA DE CURSOS ====");
        Console.WriteLine("1 - Cadastrar Aluno");
        Console.WriteLine("2 - Listar Alunos");
        Console.WriteLine("0 - Sair");
        Console.WriteLine();

        Console.Write("Escolha uma opção: ");

        string opcao = Console.ReadLine() ?? "";

        switch (opcao)
        {
            case "1":
                CadastrarAluno(alunos);
                break;

            case "2":
                ListarAlunos(alunos);
                break;

            case "0":
                JsonRepository.Salvar(alunos);

                Console.WriteLine();
                Console.WriteLine("Sistema encerrado.");
                return;

            default:
                Console.WriteLine();
                Console.WriteLine("Opção inválida!");
                Console.WriteLine("Digite apenas 1, 2 ou 0.");
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
        }
    }
}

private static void CadastrarAluno(List<AlunoDTO> alunos)
{
    Console.Clear();

    Console.Write("Nome: ");
    string nome = Console.ReadLine() ?? "";

string email = "";

while (true)
{
    Console.WriteLine();
    Console.Write("Email (obrigatoriamente @gmail.com): ");

    email = Console.ReadLine() ?? "";

    if (email.EndsWith("@gmail.com",
        StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    Console.WriteLine();
    Console.WriteLine("E-mail inválido!");
    Console.WriteLine("O e-mail deve terminar com @gmail.com");
    Console.WriteLine("Exemplo: aluno@gmail.com");
}

    var cursosDisponiveis = CursoRepository.ObterCursos();

    List<string> cursosEscolhidos = new List<string>();

    double valorTotal = 0;

    Console.WriteLine();
    Console.WriteLine("Cursos Disponíveis:");

    for (int i = 0; i < cursosDisponiveis.Count; i++)
    {
        Curso curso = cursosDisponiveis[i];

        if (curso is CursoPago cursoPago)
        {
            Console.WriteLine(
                $"{i + 1} - {cursoPago.Titulo} - R$ {cursoPago.Valor:F2}");
        }
        else
        {
            Console.WriteLine(
                $"{i + 1} - {curso.Titulo} - GRATUITO");
        }
    }

    Console.WriteLine();
    Console.Write("Digite os cursos separados por vírgula: ");

    string entrada = Console.ReadLine() ?? "";

    string formaPagamento = "Não Necessário";

    double progresso = 0;

bool selecaoValida = false;

while (!selecaoValida)
{
    try
    {
        cursosEscolhidos.Clear();
        valorTotal = 0;

        Console.WriteLine();
        Console.Write("Digite os cursos separados por vírgula: ");

        entrada = Console.ReadLine() ?? "";

        foreach (string item in entrada.Split(','))
        {
            if (!int.TryParse(item.Trim(), out int opcaoCurso))
                throw new Exception("Digite apenas números.");

            int indice = opcaoCurso - 1;

            if (indice < 0 || indice >= cursosDisponiveis.Count)
                throw new Exception("Curso inexistente.");

            Curso curso = cursosDisponiveis[indice];

            cursosEscolhidos.Add(curso.Titulo);

            if (curso is CursoPago cursoPago)
            {
                valorTotal += cursoPago.Valor;

                Console.WriteLine();
                Console.WriteLine($"Pagamento do curso {cursoPago.Titulo}");
                Console.WriteLine("1 - Cartão");
                Console.WriteLine("2 - Pix");

                string opPagamento = Console.ReadLine() ?? "";

                while (opPagamento != "1" && opPagamento != "2")
                {
                    Console.WriteLine("Opção inválida.");
                    Console.WriteLine("1 - Cartão");
                    Console.WriteLine("2 - Pix");

                    opPagamento = Console.ReadLine() ?? "";
                }

                formaPagamento =
                    opPagamento == "1"
                    ? "Cartão"
                    : "Pix";
            }
        }

        selecaoValida = true;
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"Erro: {ex.Message}");
        Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
        Console.ReadKey();
    }
}

while (true)
{
    Console.WriteLine();
    Console.Write("Informe o progresso do aluno (0 a 100): ");

    if (double.TryParse(Console.ReadLine(), out progresso)
        && progresso >= 0
        && progresso <= 100)
    {
        break;
    }

    Console.WriteLine("Progresso inválido! Digite um valor entre 0 e 100.");
}

    alunos.Add(new AlunoDTO
    {
        Nome = nome,
        Email = email,
        Cursos = cursosEscolhidos,
        FormaPagamento = formaPagamento,
        ValorTotal = valorTotal,
        Progresso = progresso
    });

    JsonRepository.Salvar(alunos);

    Console.WriteLine();
    Console.WriteLine("Aluno cadastrado com sucesso!");

    Console.ReadKey();
}

private static void ListarAlunos(List<AlunoDTO> alunos)
{
Console.Clear();

if (alunos.Count == 0)
{
    Console.WriteLine("Nenhum aluno cadastrado.");
    Console.ReadKey();
    return;
}

var cursosDisponiveis = CursoRepository.ObterCursos();

foreach (var aluno in alunos)
{
    Console.WriteLine($"Nome: {aluno.Nome}");
    Console.WriteLine($"Email: {aluno.Email}");
    Console.WriteLine($"Forma de Pagamento: {aluno.FormaPagamento}");
    Console.WriteLine($"Valor Pago: R$ {aluno.ValorTotal:F2}");
    Console.WriteLine($"Progresso: {aluno.Progresso}%");

    Console.WriteLine("Cursos Matriculados:");

    foreach (var nomeCurso in aluno.Cursos)
    {
        Console.WriteLine($" - {nomeCurso}");

        Curso cursoCompleto =
            cursosDisponiveis.Find(c => c.Titulo == nomeCurso);

        if (cursoCompleto != null)
        {
            Console.WriteLine("   Aulas:");

            foreach (var aula in cursoCompleto.Aulas)
            {
                Console.WriteLine(
                    $"   • {aula.Titulo} ({aula.Duracao} min)");
            }
        }
    }

    Console.WriteLine("----------------------------------");
}

Console.ReadKey();

}
}