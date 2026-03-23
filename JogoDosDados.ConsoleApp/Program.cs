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

            ConfigurarPartida();

            while (jogoEstaEmAndamento)
            {
                Console.Clear();
                if (ehTurnoJogador)
                {
                    Jogador.IniciarRodada();
                    System.Console.WriteLine("Pressione ENTER para continuar");
                    Console.ReadKey();
                }
                else
                {
                    Computador.IniciarRodada();
                    System.Console.WriteLine("Pressione ENTER para continuar");
                    Console.ReadKey();
                }

                if (Jogador.Venceu())
                {
                    jogoEstaEmAndamento = false;
                }
                else
                {
                    Computador.IniciarRodada();
                }

                ehTurnoJogador = !ehTurnoJogador;
            }

            if (!JogadorDesejaContinuar()) break;
        }

        static void ConfigurarPartida()
        {
            Jogador.posicao = 0;
            Computador.posicao = 0;
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