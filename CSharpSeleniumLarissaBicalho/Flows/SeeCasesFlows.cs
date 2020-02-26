using CSharpSeleniumLarissaBicalho.Pages;


namespace CSharpSeleniumLarissaBicalho.Flows
{
    public class SeeCasesFlows
    {

        #region Page Object and Constructor

        LoginFlows loginFlows;
        MainPage mainPage;
        SeeCasesPage seeCasesPage;

        public SeeCasesFlows()
        {
            loginFlows = new LoginFlows();
            mainPage = new MainPage();
            seeCasesPage = new SeeCasesPage();

        }

        #endregion

        public void SeeCases()
        {

            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            mainPage.ClicarEmVerCasos();

        }
    }
}
