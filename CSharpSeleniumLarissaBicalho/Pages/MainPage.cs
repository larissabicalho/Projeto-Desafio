using CSharpSeleniumLarissaBicalho.Bases;
using OpenQA.Selenium;


namespace CSharpSeleniumLarissaBicalho.Pages
{
    public class MainPage : PageBase
    {
        #region Mapping

        By usernameLoginInfoTextArea = By.XPath("//td[@class='login-info-left']/span[@class='italic']");
        By myViewPage = By.XPath("//a[@href='/my_view_page.php']");
        By AllCases = By.XPath("//a[@href='/view_all_bug_page.php']");
        By reportIssueLink = By.XPath("//a[@href='/bug_report_page.php']");
        By changeRegister = By.XPath("//a[@href='/changelog_page.php']");
        By planningLink = By.XPath("//a[@href='/roadmap_page.php']");
        By summary = By.XPath("//a[@href='/summary_page.php']");
        By manager = By.XPath("//a[@href='/manage_overview_page.php']");
        By myAccount = By.XPath("//a[@href='/account_page.php']");
        By logout = By.XPath("//a[@href='/logout_page.php']");
        By txtLogin = By.ClassName("form-title");

        #endregion

        #region Actions

        public string RetornaUsernameDasInformacoesDeLogin()
        {
            return GetText(usernameLoginInfoTextArea);
        }

        public void ClicarEmReportIssue()
        {
            Click(reportIssueLink);
        }

        public void ClicarEmVerCasos()
        {
            Click(AllCases);
        }

        public void ClicarEmRelatarCasos()
        {
            Click(reportIssueLink);
        }

        public void ClicarEmRegistrodeMudanças()
        {
            Click(changeRegister);
        }

        public void ClicarEmPlanejamento()
        {
            Click(planningLink);
        }

        public void ClicarEmResumo()
        {
            Click(summary);
        }

        public void ClicarEmGerenciar()
        {
            Click(manager);
        }

        public void ClicarEmMinhaConta()
        {
            Click(myAccount);
        }

        public void ClicarEmLogout()
        {
            Click(logout);
        }

        public string VerificarTelaLogin()
        {
            return GetText(txtLogin);
        }

        #endregion

    }
}
