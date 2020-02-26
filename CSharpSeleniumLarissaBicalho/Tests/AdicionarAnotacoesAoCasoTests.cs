using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Bases;
using CSharpSeleniumLarissaBicalho.Flows;
using NUnit.Framework;
using CSharpSeleniumLarissaBicalho.Helpers;

namespace CSharpSeleniumLarissaBicalho.Tests
{
    public class AdicionarAnotacoesAoCasoTests : TestBase
    {
        
        AdicionarAnotacoesAoCasoPage adicionarAnotacoesAoCasoPage;
        AdicionarAnotacoesAoCasoFlows adicionarAnotacoesAoCasoFlows;

        [Test]

        public void AdicionarAnotacao()
        {
            adicionarAnotacoesAoCasoPage = new AdicionarAnotacoesAoCasoPage();
            adicionarAnotacoesAoCasoFlows = new AdicionarAnotacoesAoCasoFlows();

            string descricao = "TesteLarissaDescricao" + GeneralHelpers.ReturnStringWithRandomCharacters(6);
            adicionarAnotacoesAoCasoFlows.AnotacoesInicio();
            adicionarAnotacoesAoCasoPage.InsererAnotacaoAoCaso(descricao);

            Assert.AreEqual(descricao, adicionarAnotacoesAoCasoPage.VerificarSeAAnotaçãoFoiInserida(descricao));
        }

        [Test]

        public void AlterarAnotacao()
        {
            adicionarAnotacoesAoCasoPage = new AdicionarAnotacoesAoCasoPage();
            adicionarAnotacoesAoCasoFlows = new AdicionarAnotacoesAoCasoFlows();

            string descricao = "TesteLarissaDescricao" + GeneralHelpers.ReturnStringWithRandomCharacters(6);
            adicionarAnotacoesAoCasoFlows.AnotacoesInicio();
            string descricaoFeita = adicionarAnotacoesAoCasoPage.InsererAnotacaoAoCaso(descricao);
            string descricaoAtualizada = "TesteLarissaDescricao" + GeneralHelpers.ReturnStringWithRandomCharacters(6);
            adicionarAnotacoesAoCasoPage.AlterarAnotacao(descricaoFeita, descricaoAtualizada);

            Assert.AreEqual(descricaoAtualizada, adicionarAnotacoesAoCasoPage.VerificarSeAAnotaçãoFoiInserida(descricaoAtualizada));

        }

        [Test]

        public void NaoAlterarAnotacao()
        {
            //clicar em voltar
            adicionarAnotacoesAoCasoPage = new AdicionarAnotacoesAoCasoPage();
            adicionarAnotacoesAoCasoFlows = new AdicionarAnotacoesAoCasoFlows();

            adicionarAnotacoesAoCasoFlows.AnotacoesInicio();
            string descricao = "TesteLarissaDescricao" + GeneralHelpers.ReturnStringWithRandomCharacters(6);
            adicionarAnotacoesAoCasoFlows.AnotacoesInicio();
            string descricaoFeita = adicionarAnotacoesAoCasoPage.InsererAnotacaoAoCaso(descricao);
            adicionarAnotacoesAoCasoPage.entraremAlterarAnotacaoSemAlterar(descricaoFeita);

            Assert.AreEqual(descricaoFeita, adicionarAnotacoesAoCasoPage.VerificarSeAAnotaçãoFoiInserida(descricaoFeita));

        }

        [Test]

        public void ApagarAnotacao()
        {
            adicionarAnotacoesAoCasoPage = new AdicionarAnotacoesAoCasoPage();
            adicionarAnotacoesAoCasoFlows = new AdicionarAnotacoesAoCasoFlows();

            string descricao = "TesteLarissaDescricao" + GeneralHelpers.ReturnStringWithRandomCharacters(6);
            adicionarAnotacoesAoCasoFlows.AnotacoesInicio();
            string descricaoFeita = adicionarAnotacoesAoCasoPage.InsererAnotacaoAoCaso(descricao);
            adicionarAnotacoesAoCasoPage.ApagarAnotacao(descricaoFeita);

            Assert.IsFalse(adicionarAnotacoesAoCasoPage.ConfirmarSeAAnotaçãoFoiApagada(descricaoFeita));

        }
      
        [Test]

        public void TornarUmaAnotacaoPrivada()
        {
            adicionarAnotacoesAoCasoPage = new AdicionarAnotacoesAoCasoPage();
            adicionarAnotacoesAoCasoFlows = new AdicionarAnotacoesAoCasoFlows();

            string descricao = "TesteLarissaDescricao" + GeneralHelpers.ReturnStringWithRandomCharacters(6);
            adicionarAnotacoesAoCasoFlows.AnotacoesInicio();
            string descricaoFeita = adicionarAnotacoesAoCasoPage.InsererAnotacaoAoCaso(descricao);
            adicionarAnotacoesAoCasoPage.TornarAAnotacaoPrivada(descricaoFeita);

            Assert.IsTrue(adicionarAnotacoesAoCasoPage.VerificarSeAAnotacaoEstaPrivada(descricaoFeita));

        }

        [Test]

        public void TornarUmaAnotacaoPublica()
        {
            adicionarAnotacoesAoCasoPage = new AdicionarAnotacoesAoCasoPage();
            adicionarAnotacoesAoCasoFlows = new AdicionarAnotacoesAoCasoFlows();

            string descricao = "TesteLarissaDescricao" + GeneralHelpers.ReturnStringWithRandomCharacters(6);
            adicionarAnotacoesAoCasoFlows.AnotacoesInicio();
            string descricaoFeita = adicionarAnotacoesAoCasoPage.InsererAnotacaoAoCaso(descricao);
            adicionarAnotacoesAoCasoPage.TornarAAnotacaoPrivada(descricaoFeita);
            adicionarAnotacoesAoCasoPage.TornarAAnotacaoPublica(descricaoFeita);
           
            Assert.IsTrue(adicionarAnotacoesAoCasoPage.VerificarSeAAnotacaoEstaPublica("testee"));

        }


    }
}
