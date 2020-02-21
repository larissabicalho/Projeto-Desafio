using CSharpSeleniumLarissaBicalho.Pages;


namespace CSharpSeleniumLarissaBicalho.Flows
{
    public class ResetFlows
    {
        LoginPage loginPage;
        ResetPasswordPage resetPasswordPage;

        public void enviarEmailParaRecuperarASenha(string usuario, string email)
        {
            

            loginPage = new LoginPage();
            resetPasswordPage = new ResetPasswordPage();

            loginPage.AcessarLostPassword();
            resetPasswordPage.VerificarLostPassword();
            resetPasswordPage.PreencherUsuario(usuario);
            resetPasswordPage.PreencherEmail(email);
            resetPasswordPage.ClicarEmSubmeter();
        }
    }
}
