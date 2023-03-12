using System;
using System.Threading;
using System.Collections.Generic;

namespace Ex2
{
	public class Produtor
	{
		Random rnd = new Random();
		Stack<int> pilha;

		public Produtor(ref Stack<int> pilha) {
			this.pilha = pilha;
		}

		private void geraObjeto() {
			Console.WriteLine("Guardando novo objeto...");
			lock (Program.locker) {
				pilha.Push(rnd.Next(0, 10));
			}
			Console.WriteLine($"Novo objeto guardado! Tamanho da pilha: {pilha.Count}");
		}

		public void produz() {
			for (int i = 0; i < 50; i++) {
				geraObjeto();
				Thread.Sleep(rnd.Next(100, 2000));
            }
        }
	}
}

