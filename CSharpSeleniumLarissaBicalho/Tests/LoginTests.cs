using CSharpSeleniumLarissaBicalho.Bases;
using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;
using NUnit.Framework;


namespace CSharpSeleniumLarissaBicalho.Tests
{

    public class LoginTests : TestBase
    {

        #region Pages and Flows Objects
        LoginFlows loginFlows;
        MainPage mainPage;
        LoginPage loginPage;
        #endregion

        [Test]
        public void RealizarLoginComSucesso()
        {
            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows = new LoginFlows();
            mainPage = new MainPage();

            loginFlows.EfetuarLogin(usuario, senha);

      

            Assert.AreEqual(usuario, mainPage.RetornaUsernameDasInformacoesDeLogin());
        }

        [Test]
        public void VerificarMensagemErroUsuario()
        {
            #region Parameters
            string usuario = "";
            string senha = "lalelu221510";
            #endregion


            loginPage = new LoginPage();
            loginFlows = new LoginFlows();

            
            loginFlows.EfetuarLogin(usuario, senha);

            Assert.AreEqual("Your account may be disabled or blocked or the username/password you entered is incorrect.", loginPage.RetornaMensagemDeErro());
        }

        [Test]
        public void VerificarMensagemErroSenha()
        {
            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu";
            #endregion

            loginFlows = new LoginFlows();
            loginPage = new LoginPage();
                      

            loginFlows.EfetuarLogin(usuario, senha);

            Assert.AreEqual("Your account may be disabled or blocked or the username/password you entered is incorrect.", loginPage.RetornaMensagemDeErro());
        }

        [Test]
        public void VerificarLoginVazio()
        {
            #region Parameters
            string usuario = "";
            string senha = "";
            #endregion

            loginFlows = new LoginFlows();
            loginPage = new LoginPage();


            loginFlows.EfetuarLogin(usuario, senha);

            Assert.AreEqual("Your account may be disabled or blocked or the username/password you entered is incorrect.", loginPage.RetornaMensagemDeErro());
        }

    }
      
}
