using System.Security.Cryptography;

static class Computador
{
   public static int IniciarRodada(int posicaoComputador, int limiteLinhaDeChegada, int bonusAvancoExtra, int penalidadeRecuo)
    {
        ExibirCabecalho();
        System.Console.WriteLine("----------------------");
        System.Console.WriteLine("RODADA DO COMPUTADOR");
        System.Console.WriteLine("----------------------");


        int resultadoComputador = RandomNumberGenerator.GetInt32(1, 7);
        System.Console.WriteLine($"O número sorteado foi {resultadoComputador}");

        posicaoComputador += resultadoComputador;


        System.Console.WriteLine($"Computador esta na posição {posicaoComputador} de {limiteLinhaDeChegada}");
        if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15 || posicaoComputador == 25)
        {
            System.Console.WriteLine("\nCasa de Evento.Avance mais 3 posiçoes");
            posicaoComputador += bonusAvancoExtra;
        }
        else if (posicaoComputador == 7 || posicaoComputador == 13 || posicaoComputador == 20)
        {
            System.Console.WriteLine("\nCasa de Evento.Recue menos 2 posiçoes");
            posicaoComputador -= penalidadeRecuo;
        }

        if (resultadoComputador == 6)
        {
            System.Console.WriteLine("\nCasa de Evento.Computador ganhou rodada EXTRA!");
            posicaoComputador = IniciarRodada(posicaoComputador, limiteLinhaDeChegada, bonusAvancoExtra, penalidadeRecuo);
        }
        return posicaoComputador;
    }

     private static void ExibirCabecalho()
    {

        System.Console.WriteLine("----------------------");
        System.Console.WriteLine("JOGO DOS DADOS");
        System.Console.WriteLine("----------------------");

    }
}
