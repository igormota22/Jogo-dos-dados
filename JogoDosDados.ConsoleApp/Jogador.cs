using System.Security.Cryptography;

static class Jogador
{

    public static int IniciarRodada(int posicaoJogador, int limiteLinhaDeChegada, int bonusAvancoExtra, int penalidadeRecuo)
    {
        ExibirCabecalho();
        System.Console.WriteLine("----------------------");
        System.Console.WriteLine("RODADA DO JOGADOR");
        System.Console.WriteLine("----------------------");
        System.Console.WriteLine("Precione ENTER para rolar o dado");
        Console.ReadKey();

        int resultadoJogador = RandomNumberGenerator.GetInt32(1, 7);

        System.Console.WriteLine($"O número sorteado foi {resultadoJogador}");
        posicaoJogador += resultadoJogador;

        System.Console.WriteLine($"Voce esta na posição {posicaoJogador} de {limiteLinhaDeChegada}");

        if (posicaoJogador == 5 || posicaoJogador == 10 || posicaoJogador == 15 || posicaoJogador == 25)
        {
            System.Console.WriteLine("\nCasa de Evento.Avance mais 3 posiçoes");
            posicaoJogador += bonusAvancoExtra;
        }
        else if (posicaoJogador == 7 || posicaoJogador == 13 || posicaoJogador == 20)
        {
            System.Console.WriteLine("\nCasa de Evento.Recue menos 2 posiçoes");
            posicaoJogador -= penalidadeRecuo;
        }

        if (resultadoJogador == 6)
        {
            System.Console.WriteLine("\nCasa de evento.Rodada EXTRA!Pressione ENTER para jogar novamente");
            Console.ReadKey();
            posicaoJogador = IniciarRodada(posicaoJogador, limiteLinhaDeChegada, bonusAvancoExtra, penalidadeRecuo);
        }
        return posicaoJogador;
    }

      private static void ExibirCabecalho()
    {

        System.Console.WriteLine("----------------------");
        System.Console.WriteLine("JOGO DOS DADOS");
        System.Console.WriteLine("----------------------");

    }
}
