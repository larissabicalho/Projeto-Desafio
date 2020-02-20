using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Bases;
using NUnit.Framework;


namespace CSharpSeleniumLarissaBicalho.Tests
{
    public class ResetPasswordTests : TestBase

    {
        #region Pages and Flows Objects
        LoginPage loginPage;
        ResetPasswordPage resetPasswordPage;
        ResetFlows resetFlows;
        #endregion


        [Test]
        public void AcessarAPaginaResetPassword()
        {
            loginPage = new LoginPage();
            resetPasswordPage = new ResetPasswordPage();
            loginPage.AcessarLostPassword();
            Assert.AreEqual("Password Reset", resetPasswordPage.VerificarLostPassword());

        }


        [Test]
        public void InserirUserName_Email()
        {
            resetPasswordPage = new ResetPasswordPage();
            resetFlows = new ResetFlows();
            resetFlows.enviarEmailParaRecuperarASenha("larissa.bicalho", "lari_nazarebicalho@hotmail.com");

            Assert.AreEqual("Password Message Sent", resetPasswordPage.RetornarMensagemDeEmailEnviado());

        }

        [Test]
        public void InserirUserNameVazio_Email()
        {

            resetPasswordPage = new ResetPasswordPage();
            resetFlows = new ResetFlows();

            resetFlows.enviarEmailParaRecuperarASenha("", "lari_nazarebicalho@hotmail.com");

            Assert.AreEqual("The provided information does not match any registered account!", resetPasswordPage.RetornarMensagemDeErroUserEmail());

        }

        [Test]
        public void InserirUserName_EmailVazio()
        {


            resetPasswordPage = new ResetPasswordPage();
            resetFlows = new ResetFlows();

            resetFlows.enviarEmailParaRecuperarASenha("larissa.bicalho", "");


            Assert.AreEqual("Invalid e-mail address.", resetPasswordPage.RetornarMensagemDeErroUserEmail());

        }


        [Test]
        public void InserirUserNameVazio_EmailVazio()
        {
            resetPasswordPage = new ResetPasswordPage();
            resetFlows = new ResetFlows();

            resetFlows.enviarEmailParaRecuperarASenha("", "");


            Assert.AreEqual("Invalid e-mail address.", resetPasswordPage.RetornarMensagemDeErroUserEmail());

        }

        [Test]
        public void InserirUserInvalido_Email()
        {
            resetPasswordPage = new ResetPasswordPage();
            resetFlows = new ResetFlows();

            resetFlows.enviarEmailParaRecuperarASenha("larissa.bica", "lari_nazarebicalho@hotmail.com");

            Assert.AreEqual("The provided information does not match any registered account!", resetPasswordPage.RetornarMensagemDeErroUserEmail());

        }

        [Test]
        public void InserirUser_EmailInvalido()
        {

            resetPasswordPage = new ResetPasswordPage();
            resetFlows = new ResetFlows();

            resetFlows.enviarEmailParaRecuperarASenha("larissa.bicalho", "lari_nazarebicalho@hotmail");


            Assert.AreEqual("The provided information does not match any registered account!", resetPasswordPage.RetornarMensagemDeErroUserEmail());

        }

        [Test]
        public void InserirUserInvalido_EmailInvalido()
        {

            resetPasswordPage = new ResetPasswordPage();
            resetFlows = new ResetFlows();

            resetFlows.enviarEmailParaRecuperarASenha("larissa.bica", "lari_nazarebicalho@hotmail");

            Assert.AreEqual("The provided information does not match any registered account!", resetPasswordPage.RetornarMensagemDeErroUserEmail());

        }

        [Test]
        public void VoltarParaBotãoLogin()
        {
            #region Parameters
            string usuario = "larissa.bica";
            string email = "lari_nazarebicalho@hotmail.com";
            #endregion

            loginPage = new LoginPage();
            resetPasswordPage = new ResetPasswordPage();

            loginPage.AcessarLostPassword();
            resetPasswordPage.VerificarLostPassword();
            resetPasswordPage.ClicarEmVoltarLogin();
            Assert.AreEqual("Login", resetPasswordPage.RetornarMensagemTelaDeLogin());

        }

    }
}