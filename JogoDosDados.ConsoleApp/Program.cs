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
            int posicaoJogador = 0;
            bool jogoEstaEmAndamento = true;

            while (jogoEstaEmAndamento){

            Console.Clear();
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("JOGO DOS DADOS");
            System.Console.WriteLine("----------------------");

            System.Console.WriteLine("Precione ENTER para rolar o dado");
            Console.ReadKey();

            int resultado = RandomNumberGenerator.GetInt32(1,7);

            System.Console.WriteLine($"O número sorteado foi {resultado}");

            posicaoJogador += resultado;

            System.Console.WriteLine($"Voce esta na posição {posicaoJogador} de {limiteLinhaDeChegada}");

            if (posicaoJogador == 5 || posicaoJogador == 10 || posicaoJogador == 15 || posicaoJogador == 25)
                {

                    System.Console.WriteLine("\nCasa de Evento.Avance mais 3 posiçoes");
                    posicaoJogador += bonusAvancoExtra;
                }
                else if (posicaoJogador == 7 || posicaoJogador == 13 || posicaoJogador == 20)
                {
                    System.Console.WriteLine("\nCasa de Evento.Recue menos 3 posiçoes");
                    posicaoJogador -= penalidadeRecuo;
                }

            if(posicaoJogador >= limiteLinhaDeChegada)
            {
                System.Console.WriteLine("Parabéns, voce chegou na linha de chegada!!");
                jogoEstaEmAndamento = false;;
            }

            System.Console.WriteLine();    
            System.Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
            }

            System.Console.Write("Deseja continuar? (s/N): ");
            string? opcaoDesejaContinuar = Console.ReadLine()?.ToUpper();

            if (opcaoDesejaContinuar != "S")
            break;
        }
    }
}

