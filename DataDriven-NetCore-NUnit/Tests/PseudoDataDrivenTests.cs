using DataDriven_NetCore_NUnit.Helpers;
using NUnit.Framework;

namespace DataDriven_NetCore_NUnit
{
    public class PseudoDataDrivenTests
    {

      //POR FAVOR NÃO USEM ISTO! É SÓ PRA MOSTRAR O QUE NÃO FAZER!!

        [Test]
        public void TesteErroComum()
        {

            string[] dadosTeste = {"Nome1", "Nome2", "Nome3", "Nome4", "Nome5"};    

            for (int i = 0; i <= 4; i++) 
            {
                string dadoTeste = dadosTeste[i];
                //Click, SendKeys...
                //Click, SendKeys...
            }

            Assert.Pass();
        }

    }
}