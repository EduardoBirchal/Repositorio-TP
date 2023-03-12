using System;
using System.Threading;

namespace Ex2
{
	public class Trabalhador
	{
		string produto;
		int tempo;
		public static bool para = false;
		Random rnd = new Random();

		public Trabalhador(string produto, int tempo) {
			this.produto = produto;
			this.tempo = tempo;
		}

		public void Produz() {
			for (int i = 0; i < 50; i++) {
				System.Console.WriteLine($"{i} {produto}");

				try {
					Thread.Sleep(rnd.Next(0, 500) * tempo);
				}
				catch (ThreadInterruptedException excecao) {
					System.Console.WriteLine($"{excecao}: Thread interrompida!");
				}
			}

			System.Console.WriteLine($"Terminei {produto}!");
		}

		public void ProduzInfinito() {
			int i = 0;

			while (!para) {
				System.Console.WriteLine($"{i} {produto}");

				try {
					Thread.Sleep(rnd.Next(0, 500) * tempo);
				}
				catch (ThreadInterruptedException excecao) {
					System.Console.WriteLine($"{excecao}: Thread interrompida!");
				}

				i++;
			}

			System.Console.WriteLine($"Terminei {produto}!");
		}
	}
}
