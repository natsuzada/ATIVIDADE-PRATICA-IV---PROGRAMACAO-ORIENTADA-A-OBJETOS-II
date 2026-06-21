using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class JsonRepository
{
    private static string arquivo = "alunos.json";

    public static void Salvar(List<AlunoDTO> alunos)
    {
        string json = JsonSerializer.Serialize(
            alunos,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(arquivo, json);
    }

    public static List<AlunoDTO> Carregar()
    {
        if (!File.Exists(arquivo))
            return new List<AlunoDTO>();

        string json = File.ReadAllText(arquivo);

        return JsonSerializer.Deserialize<List<AlunoDTO>>(json)
               ?? new List<AlunoDTO>();
    }
}