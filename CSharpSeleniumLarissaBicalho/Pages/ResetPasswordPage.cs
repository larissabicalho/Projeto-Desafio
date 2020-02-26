using CSharpSeleniumLarissaBicalho.Bases;
using OpenQA.Selenium;


namespace CSharpSeleniumLarissaBicalho.Pages
{
    public class ResetPasswordPage : PageBase
    {
        #region Mapping

        By txtLostPassword = By.ClassName("form-title");
        By txtEmailLogin = By.ClassName("form-title");
        By tfUsername = By.Name("username");
        By tfEmail = By.Name("email");
        By btnLoginSubmit = By.XPath("//input[@value='Submit']");
        By linkVoltarEmail = By.LinkText("Login");
        By txtEmailEnviado = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Proceed'])[1]/preceding::b[1]");
        By UserVazioOrEmail = By.XPath(("/html/body/div[2]/table/tbody/tr[2]/td/p"));

        #endregion

        #region Actions

        public string VerificarLostPassword()
        {
            return GetText(txtLostPassword);
        }

        public string RetornarMensagemDeEmailEnviado()
        {
            return GetText(txtEmailEnviado);

        }

        public string RetornarMensagemTelaDeLogin()
        {
            return GetText(txtEmailLogin);
        }

        public string RetornarMensagemDeErroUserEmail()
        {
            return GetText(UserVazioOrEmail);
        }

        public void PreencherUsuario(string usuario)
        {
            SendKeys(tfUsername, usuario);
        }

        public void PreencherEmail(string email)
        {
            SendKeys(tfEmail, email);
        }


        public void ClicarEmVoltarLogin()
        {
            Click(linkVoltarEmail);
        }


        public void ClicarEmSubmeter()
        {
            Click(btnLoginSubmit);
        }

        #endregion

    }
}
