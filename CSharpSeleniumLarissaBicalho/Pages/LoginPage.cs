using CSharpSeleniumLarissaBicalho.Bases;
using OpenQA.Selenium;


namespace CSharpSeleniumLarissaBicalho.Pages
{
    public class LoginPage : PageBase
    {
        #region Mapping

        #region  Login
        By usernameField = By.Name("username");
        By passwordField = By.Name("password");
        By loginButton = By.XPath("//input[@type='submit']");

        #endregion

        #region Mensagens de Erro
        By mensagemErroTextArea = By.XPath("/html/body/div[2]/font");
        
        #endregion


        #region Lost Password

        By linkLostPassoword = By.LinkText("Lost your password?");

        #endregion

        #endregion


        #region Action

        #region Login do Usuario 
        public void PreencherUsuario(string usuario)
        {
            SendKeys(usernameField, usuario);
        }

        public void PreencherSenha(string senha)
        {
            SendKeys(passwordField, senha);
        }

        public void ClicarEmLogin()
        {
            Click(loginButton);
        }

        #endregion

       #region mensagem de Erro 

        public string RetornaMensagemDeErro()
        {
            return GetText(mensagemErroTextArea);
        }

        public void AcessarLostPassword()
        {
            Click(linkLostPassoword);
        }


        #endregion

        #endregion
    }
}
