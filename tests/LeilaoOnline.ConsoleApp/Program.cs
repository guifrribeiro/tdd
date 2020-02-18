using LeilaoOnline.Core;
using System;

namespace LeilaoOnline.ConsoleApp
{
    class Program
    {
        private static void LeilaoComVariosLances()
        {
            //Arranje - cenários
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            if (valorEsperado == valorObtido)
            {
                Console.WriteLine("Teste OK");
            }
            else
            {
                Console.WriteLine("Teste FALHOU");
            }
        }

        private static void LeilaoComApenasUmLance()
        {
            //Arranje - cenários
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.RecebeLance(fulano, 800);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);
        }

        private static void Verifica(double esperado, double obtido)
        {
            var cor = Console.ForegroundColor;

            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Teste OK! Esperado: {esperado}. Obtido: {obtido}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Teste FALHOU! Esperado: {esperado}. Obtido: {obtido}");
            }

            Console.ForegroundColor = cor;
        }

        static void Main()
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();
        }
    }
}
