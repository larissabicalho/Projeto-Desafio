using CSharpSeleniumLarissaBicalho.Bases;
using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;
using NUnit.Framework;


namespace CSharpSeleniumLarissaBicalho.Tests
{
    public class MainTests : TestBase

    {
        #region Pages and Flows Objects
     
        MainPage mainPage;
        #endregion

        [Test]

        public void FazerLogout()
        {
            LoginFlows loginFlows = new LoginFlows();

            mainPage = new MainPage();

            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            Assert.AreEqual(usuario, mainPage.RetornaUsernameDasInformacoesDeLogin());
            mainPage.ClicarEmLogout();

            Assert.AreEqual("Login", mainPage.VerificarTelaLogin());


        }

    }
}
