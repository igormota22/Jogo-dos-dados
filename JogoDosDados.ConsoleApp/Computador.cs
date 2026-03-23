using System.Security.Cryptography;

static class Computador
{
    static public int posicao = 0;
    private const int limiteLinhaDeChegada = 30;
    private const int bonusAvancoExtra = 3;
    private const int penalidadeRecuo = 2;
    public static void IniciarRodada()
    {
        ExibirCabecalho();
        System.Console.WriteLine("----------------------");
        System.Console.WriteLine("RODADA DO COMPUTADOR");
        System.Console.WriteLine("----------------------");


        int resultadoComputador = RandomNumberGenerator.GetInt32(1, 7);
        System.Console.WriteLine($"O número sorteado foi {resultadoComputador}");

        posicao += resultadoComputador;


        System.Console.WriteLine($"Computador esta na posição {posicao} de {limiteLinhaDeChegada}");
        if (posicao == 5 || posicao == 10 || posicao == 15 || posicao == 25)
        {
            System.Console.WriteLine("\nCasa de Evento.Avance mais 3 posiçoes");
            posicao += bonusAvancoExtra;
        }
        else if (posicao == 7 || posicao == 13 || posicao == 20)
        {
            System.Console.WriteLine("\nCasa de Evento.Recue menos 2 posiçoes");
            posicao -= penalidadeRecuo;
        }

        if (resultadoComputador == 6)
        {
            System.Console.WriteLine("\nCasa de Evento.Computador ganhou rodada EXTRA!");
            IniciarRodada();
        }

    }

    public static bool Venceu()
    {
        return posicao >= limiteLinhaDeChegada;

    }


    private static void ExibirCabecalho()
    {

        System.Console.WriteLine("----------------------");
        System.Console.WriteLine("JOGO DOS DADOS");
        System.Console.WriteLine("----------------------");

    }
}
