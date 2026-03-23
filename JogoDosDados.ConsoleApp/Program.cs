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

        ExecutarPartida(limiteLinhaDeChegada, bonusAvancoExtra, penalidadeRecuo);

    }
    static void ExibirCabecalho()
    {

        System.Console.WriteLine("----------------------");
        System.Console.WriteLine("JOGO DOS DADOS");
        System.Console.WriteLine("----------------------");

    }

    static void ExecutarPartida(int limiteLinhaDeChegada, int bonusAvancoExtra, int penalidadeRecuo)
    {
        while (true)
        {
            bool ehTurnoJogador = true;
            bool jogoEstaEmAndamento = true;
            int posicaoJogador = 0;
            int posicaoComputador = 0;


            while (jogoEstaEmAndamento)
            {
                Console.Clear();
                if (ehTurnoJogador)
                {

                    posicaoJogador = Jogador.IniciarRodada(posicaoJogador, limiteLinhaDeChegada, bonusAvancoExtra, penalidadeRecuo);
                    System.Console.WriteLine("Pressione ENTER para continuar");
                    Console.ReadKey();
                }
                else
                {
                    posicaoComputador = Computador.IniciarRodada(posicaoComputador, limiteLinhaDeChegada, bonusAvancoExtra, penalidadeRecuo);
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

            if (!JogadorDesejaContinuar()) break;
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

        static bool JogadorDesejaContinuar()
        {
            System.Console.Write("Deseja continuar? (s/N): ");
            string? opcaoDesejaContinuar = Console.ReadLine()?.ToUpper();

            if (opcaoDesejaContinuar != "S")
            {
                return false;
            }
            return true;
        }

    }
}