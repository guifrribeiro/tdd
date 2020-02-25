using LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(2, new double[] { 800, 900 })]
        [InlineData(4, new double[] { 100, 1200, 1300, 1400 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdeEsperada, double[] ofertas)
        {
            //Arranje - cenários
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i%2) == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }
            leilao.TerminaPregao();

            //Act - método sob teste
            leilao.RecebeLance(fulano, 1000);

            //Assert
            var valorObtido = leilao.Lances.Count();

            Assert.Equal(qtdeEsperada, valorObtido);
        }

        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Arranje - cenários
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();

            //foreach (var valor in ofertas)
            //{
            //    leilao.RecebeLance(fulano, valor);
            //}
            leilao.RecebeLance(fulano, 800);

            //Act - método sob teste
            leilao.RecebeLance(fulano, 1000);

            leilao.TerminaPregao();

            //Assert
            var qtdeEsperada = 1;
            var qtdeObtida = leilao.Lances.Count();

            Assert.Equal(qtdeEsperada, qtdeObtida);
        }
    }
}
