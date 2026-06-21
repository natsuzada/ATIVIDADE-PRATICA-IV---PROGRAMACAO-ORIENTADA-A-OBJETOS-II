using System;

public class PagamentoPix : Pagamento, IPagamento
{
    public override void RealizarPagamento(double valor)
    {
        Console.WriteLine($"Pagamento de R$ {valor:F2} realizado via Cartão.");
    }
}