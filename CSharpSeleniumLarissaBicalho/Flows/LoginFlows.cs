using CSharpSeleniumLarissaBicalho.Pages;


namespace CSharpSeleniumLarissaBicalho.Flows
{
    public class LoginFlows
    {
        #region Page Object and Constructor
        
        LoginPage loginPage;

        public LoginFlows()
        {
            loginPage = new LoginPage();
        }
        #endregion

        public void EfetuarLogin(string username, string password)
        {
            loginPage.PreencherUsuario(username);
            loginPage.PreencherSenha(password);
            loginPage.ClicarEmLogin();
        }
    }
}
