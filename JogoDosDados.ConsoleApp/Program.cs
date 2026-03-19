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
        while (true)
        {
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("JOGO DOS DADOS");
            System.Console.WriteLine("----------------------");

            System.Console.WriteLine("Precione ENTER para rolar o dado");
            Console.ReadKey();

            int resultado = RandomNumberGenerator.GetInt32(1,7);

            System.Console.WriteLine($"O número sorteado foi {resultado}");

            System.Console.Write("Deseja continuar? (s/N): ");
            string? opcaoDesejaContinuar = Console.ReadLine()?.ToUpper();

            if (opcaoDesejaContinuar != "S")
            break;
        }
    }
}

