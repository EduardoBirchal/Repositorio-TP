using System;
using System.Threading;
using System.Collections.Generic;

namespace Aula2 
{
    public class CorridaSapos
    {
        int numSapos, distanciaCorrida;
        Random rnd = new Random();
        
        public CorridaSapos (int numSapos, int distanciaCorrida) { // Bob o Construtor
            this.numSapos = numSapos;
            this.distanciaCorrida = distanciaCorrida;
        }
        
        public void ComecaCorrida () {
            for (int i=0; i<numSapos; i++) {
                Sapo novoSapo = new Sapo(i, rnd.Next(1, distanciaCorrida/2), distanciaCorrida);
                
                Thread novaThread = new Thread(novoSapo.Participa);
                novaThread.Start();
            }
            
            ChecaSeAcabou();
        }
        
        void ChecaSeAcabou () {
            while (true) {
                if (Sapo.Vencedores.Count >= numSapos) {
                    Console.WriteLine("\n======= A CORRIDA ACABOU! =======");
                    Console.WriteLine("Vencedores:");
                    
                    Console.WriteLine("- Medalha de bronze: Sapo " + Sapo.Vencedores[2]);
                    Console.WriteLine("- Medalha de prata: Sapo " + Sapo.Vencedores[1]);
                    Console.WriteLine("- Medalha de ouro: Sapo " + Sapo.Vencedores[0]);
                    
                    break;
                }
            }
        }
    }
}