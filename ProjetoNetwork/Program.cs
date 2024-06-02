using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoNetwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o número de elementos: ");
            int numElementos;
            while (!int.TryParse(Console.ReadLine(), out numElementos) || numElementos <= 0)
            {
                Console.WriteLine("Por favor, insira um número válido maior que zero.");
                Console.Write("Digite o número de elementos: ");
            }

            Network network = new Network(numElementos);

            while (true)
            {
                Console.Write("Digite 'c' para conectar, '?' para consulta ou 's' para sair: ");
                char comando;
                while (!char.TryParse(Console.ReadLine(), out comando) || (comando != 'c' && comando != '?' && comando != 's'))
                {
                    Console.WriteLine("Comando inválido. Tente novamente.");
                    Console.Write("Digite 'c' para conectar, '?' para consulta ou 's' para sair: ");
                }

                if (comando == 's')
                {
                    break;
                }

                Console.Write("Digite o primeiro elemento: ");
                int elemento1;
                while (!int.TryParse(Console.ReadLine(), out elemento1) || elemento1 <= 0 || elemento1 > numElementos)
                {
                    Console.WriteLine("Elemento inválido. Tente novamente.");
                    Console.Write("Digite o primeiro elemento: ");
                }

                Console.Write("Digite o segundo elemento: ");
                int elemento2;
                while (!int.TryParse(Console.ReadLine(), out elemento2) || elemento2 <= 0 || elemento2 > numElementos)
                {
                    Console.WriteLine("Elemento inválido. Tente novamente.");
                    Console.Write("Digite o segundo elemento: ");
                }

                if (comando == 'c')
                {
                    if (network.Connect(elemento1, elemento2))
                    {
                        Console.WriteLine("Conexão realizada!");
                    }
                    else
                    {
                        Console.WriteLine("Ou os elementos já estão conectados ou os números são inválidos.");
                    }
                }
                else if (comando == '?')
                {
                    bool conectou = network.Query(elemento1, elemento2);
                    Console.WriteLine(conectou ? "Os elementos estão conectados." : "Os elementos não estão conectados.");
                }
            }
        }
    }
}

