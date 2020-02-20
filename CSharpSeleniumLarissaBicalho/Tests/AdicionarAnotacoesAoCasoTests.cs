using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Bases;
using CSharpSeleniumLarissaBicalho.Flows;
using NUnit.Framework;


namespace CSharpSeleniumLarissaBicalho.Tests
{
    public class AdicionarAnotacoesAoCasoTests : TestBase
    {
        
        AdicionarAnotacoesAoCasoPage adicionarAnotacoesAoCasoPage;
        AdicionarAnotacoesAoCasoFlows adicionarAnotacoesAoCasoFlows;

        [Test, Order(1)]
        public void adicionarAnotacao()
        {
            adicionarAnotacoesAoCasoPage = new AdicionarAnotacoesAoCasoPage();
            adicionarAnotacoesAoCasoFlows = new AdicionarAnotacoesAoCasoFlows();

            adicionarAnotacoesAoCasoFlows.anotacoesInicio();
            adicionarAnotacoesAoCasoPage.insererAnotacaoAoCaso("vjosjojojojvojhhhh");

            Assert.AreEqual("vjosjojojojvojhhhh", adicionarAnotacoesAoCasoPage.verificarSeAAnotaçãoFoiInserida("vjosjojojojvoj"));
        }

        [Test, Order(3)]
        public void alterarAnotacao()
        {
            adicionarAnotacoesAoCasoPage = new AdicionarAnotacoesAoCasoPage();
            adicionarAnotacoesAoCasoFlows = new AdicionarAnotacoesAoCasoFlows();

            adicionarAnotacoesAoCasoFlows.anotacoesInicio();

            adicionarAnotacoesAoCasoPage.alterarAnotacao("vjosjojojojvoj","testee");

            Assert.AreEqual("testee", adicionarAnotacoesAoCasoPage.verificarSeAAnotaçãoFoiInserida("testee"));

        }

        [Test, Order(2)]
        public void naoAlterarAnotacao()
        {
            //clicar em voltar
            adicionarAnotacoesAoCasoPage = new AdicionarAnotacoesAoCasoPage();
            adicionarAnotacoesAoCasoFlows = new AdicionarAnotacoesAoCasoFlows();

            adicionarAnotacoesAoCasoFlows.anotacoesInicio();

            adicionarAnotacoesAoCasoPage.entraremAlterarAnotacaoSemAlterar("vjosjojojojvoj");

            Assert.AreEqual("vjosjojojojvoj", adicionarAnotacoesAoCasoPage.verificarSeAAnotaçãoFoiInserida("vjosjojojojvoj"));

        }

        [Test, Order(4)]
        public void apagarAnotacao()
        {
            adicionarAnotacoesAoCasoPage = new AdicionarAnotacoesAoCasoPage();
            adicionarAnotacoesAoCasoFlows = new AdicionarAnotacoesAoCasoFlows();

            adicionarAnotacoesAoCasoFlows.anotacoesInicio();
            adicionarAnotacoesAoCasoPage.apagarAnotacao("testee");

            Assert.IsFalse(adicionarAnotacoesAoCasoPage.confirmarSeAAnotaçãoFoiApagada("testee"));

        }
      
        [Test, Order(5)]
        public void tornarUmaAnotacaoPrivada()
        {
            adicionarAnotacoesAoCasoPage = new AdicionarAnotacoesAoCasoPage();
            adicionarAnotacoesAoCasoFlows = new AdicionarAnotacoesAoCasoFlows();

            adicionarAnotacoesAoCasoFlows.anotacoesInicio();
            adicionarAnotacoesAoCasoPage.tornarAAnotacaoPrivada("testee");

            Assert.IsTrue(adicionarAnotacoesAoCasoPage.verificarSeAAnotacaoEstaPrivada("testee"));

        }

        [Test, Order(6)]
        public void tornarUmaAnotacaoPublica()
        {
            adicionarAnotacoesAoCasoPage = new AdicionarAnotacoesAoCasoPage();
            adicionarAnotacoesAoCasoFlows = new AdicionarAnotacoesAoCasoFlows();

            adicionarAnotacoesAoCasoFlows.anotacoesInicio();

            adicionarAnotacoesAoCasoPage.tornarAAnotacaoPublica("testee");

            
            Assert.IsTrue(adicionarAnotacoesAoCasoPage.verificarSeAAnotacaoEstaPublica("testee"));

        }


    }
}
