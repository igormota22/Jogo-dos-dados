using System.Security.Cryptography;

class Program
{
    /*
 Jogador e computador começam na posição 0
 A cada rodada, um dado é sorteado (1 a 6)
 O valor é somado à posição atual
 Existem casas com eventos especiais
 Vence quem atingir o final primeiro

    */
    static void Main(string[] args)
    {
        const int limiteLinhaDeChegada = 30;
        const int bonusAvancoExtra = 3;
        const int penalidadeRecuo = 2;

        while (true)
        {
            bool ehTurnoJogador = true;
            bool jogoEstaEmAndamento = true;
            int posicaoJogador = 0;
            int posicaoComputador = 0;


            while (jogoEstaEmAndamento)
            {
                Console.Clear();
                ExibirCabecalho();
                if (ehTurnoJogador)
                {

                    posicaoJogador = IniciarRodadaJogador(posicaoJogador, limiteLinhaDeChegada, bonusAvancoExtra, penalidadeRecuo);
                    System.Console.WriteLine("Pressione ENTER para continuar");
                    Console.ReadKey();
                }
                else
                {
                    posicaoComputador = IniciarRodadaComputador(posicaoComputador, limiteLinhaDeChegada, bonusAvancoExtra, penalidadeRecuo);
                    System.Console.WriteLine("Pressione ENTER para continuar");
                    Console.ReadKey();
                }

                int posicaoVencedor;
                if (VerificarVencedor(posicaoJogador, posicaoComputador, limiteLinhaDeChegada, out posicaoVencedor))
                {
                    jogoEstaEmAndamento = false;
                }

                ehTurnoJogador = !ehTurnoJogador;
            }
            System.Console.Write("Deseja continuar? (s/N): ");
            string? opcaoDesejaContinuar = Console.ReadLine()?.ToUpper();
            if (opcaoDesejaContinuar != "S") break;
        }
        static void ExibirCabecalho()
        {

            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("JOGO DOS DADOS");
            System.Console.WriteLine("----------------------");

        }

        static int IniciarRodadaJogador(int posicaoJogador, int limiteLinhaDeChegada, int bonusAvancoExtra, int penalidadeRecuo)
        {
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

            if(resultadoJogador == 6)
            {
               System.Console.WriteLine("\nCasa de evento.Rodada EXTRA!Pressione ENTER para jogar novamente");
               Console.ReadKey();
               posicaoJogador = IniciarRodadaJogador(posicaoJogador,limiteLinhaDeChegada,bonusAvancoExtra,penalidadeRecuo);
            }
            return posicaoJogador;
        }

        static int IniciarRodadaComputador(int posicaoComputador, int limiteLinhaDeChegada, int bonusAvancoExtra, int penalidadeRecuo)
        {
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

            if(resultadoComputador == 6)
            {
              System.Console.WriteLine("\nCasa de Evento.Computador ganhou rodada EXTRA!");
              posicaoComputador = IniciarRodadaComputador(posicaoComputador,limiteLinhaDeChegada,bonusAvancoExtra,penalidadeRecuo);  
            }
            return posicaoComputador;
        }
    }
    static bool VerificarVencedor(int posicaoJogador, int posicaoComputador, int limiteLinhaDeChegada, out int posicaoVencedor)
    {
        if (posicaoJogador >= limiteLinhaDeChegada)
        {
            System.Console.WriteLine("Parabéns, voce chegou na linha de chegada!!");
            System.Console.WriteLine();
            posicaoVencedor = posicaoJogador;
            return true;
        }
        else if (posicaoComputador >= limiteLinhaDeChegada)
        {
            System.Console.WriteLine("Computador chegou na linha de chegada!!");
            System.Console.WriteLine();
            posicaoVencedor = posicaoComputador;
            return true;
        }
        posicaoVencedor = 0;
        return false;
    }
}