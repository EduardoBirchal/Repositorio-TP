using System;
using System.Threading;
using System.Collections.Generic;

namespace Ex2
{
	public class Consumidor
	{
		Random rnd = new Random();
		Stack<int> pilha;

		public Consumidor(ref Stack<int> pilha) {
			this.pilha = pilha;
		}

		private void pegaObjeto() {
			Console.WriteLine("Pegando um objeto...");

			if (pilha.Count > 0) {
				lock (Program.locker) {
					pilha.Pop();
				}
				Console.WriteLine($"Objeto pego! Tamanho da pilha: {pilha.Count}");
			}
			else {
				Console.WriteLine("Pilha vazia!");
			}
		}

		public void consome() {
			for (int i = 0; i < 50; i++) {
				pegaObjeto();
				Thread.Sleep(rnd.Next(500, 4000));
			}
		}
	}
}

