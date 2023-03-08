using System;
using System.Collections.Generic;

namespace Aula2
{
    public class Sapo
    {
        int id, distanciaPulo, distanciaPercorrida, distanciaCorrida;
        
        public static List<int> Vencedores = new List<int>();
        
        public Sapo (int id, int distanciaPulo, int distanciaCorrida) { // Bob o Construtor
            this.id = id;
            this.distanciaPulo = distanciaPulo;
            this.distanciaCorrida = distanciaCorrida;
            this.distanciaPercorrida = 0;
        }
        
        void Pula () {
            distanciaPercorrida += distanciaPulo;
            
            Console.WriteLine($"Sapo {id} pulou pra posição {distanciaPercorrida}...");
        }
        
        public void Participa () {
            while (distanciaPercorrida < distanciaCorrida) {
                Pula();
            }
            
            Ganha();
        }
        
        public void Ganha () {
            lock (this) { // Já que o sapo manipula uma lista compartilhada entre todos os sapos, dá um lock na função pra não ter corrupção da lista
                Vencedores.Add(id);
                Console.WriteLine($"==== Sapo {id} ganhou em {Vencedores.Count}o lugar! ===="); 
            }
        }
    }
}
