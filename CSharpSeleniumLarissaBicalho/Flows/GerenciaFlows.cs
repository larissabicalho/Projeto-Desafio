using CSharpSeleniumLarissaBicalho.Pages;

namespace CSharpSeleniumLarissaBicalho.Flows
{
    public class GerenciaFlows
    {
        GerenciarProjetos gerenciarProjetos;
        LoginFlows loginFlows;
        MainPage mainPage;

        public GerenciaFlows()
        {
            gerenciarProjetos = new GerenciarProjetos();
            loginFlows = new LoginFlows();
            mainPage = new MainPage();


        }

        public void entrarNaPaginaDeGerencia(string nomeProjeto)
        {
            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            gerenciarProjetos.escolherNomeProjeto(nomeProjeto);
            mainPage.ClicarEmGerenciar();

        }
    }
}
