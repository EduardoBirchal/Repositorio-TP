using System;
using System.Threading;
using System.Collections.Generic;

namespace Ex2
{
    class Program
    {
        public static object locker = new object();

        static void Main(string[] args) {
            Trabalhador trab = new Trabalhador("Maçãs", 1);
            Stack<int> produtos = new Stack<int>();

            Console.WriteLine("Que exercício você quer? (2 a 4)");
            int escolha = Convert.ToInt32(Console.ReadLine());

            switch (escolha) {
                case 2:
                    Console.WriteLine("Começando exercício 2...\n==============\n");

                    Thread thrEx2 = new Thread(trab.Produz);
                    thrEx2.Start();

                    break;

                case 3:
                    Console.WriteLine("Começando exercício 3...\n==============\n");

                    Thread thrEx3 = new Thread(trab.ProduzInfinito);
                    thrEx3.Start();

                    Thread.Sleep(5000);
                    Trabalhador.para = true;
                    Console.WriteLine("Trabalhador parado.");

                    break;

                case 4:
                    Produtor produtor = new Produtor(ref produtos);
                    Consumidor consumidor = new Consumidor(ref produtos);

                    Console.WriteLine("Começando exercício 4...\n==============\n");

                    Thread thrProdutor = new Thread(produtor.produz);
                    thrProdutor.Start();

                    Thread thrConsumidor = new Thread(consumidor.consome);
                    thrConsumidor.Start();

                    break;

                default:
                    Console.WriteLine("Input inválido. Fechando programa...");

                    break;
            }
                

                

                

        }
    }
}
