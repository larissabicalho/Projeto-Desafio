using CSharpSeleniumLarissaBicalho.Bases;
using OpenQA.Selenium;


namespace CSharpSeleniumLarissaBicalho.Pages
{
    public class MyViewPage : PageBase
    {
        #region Mapping

        By form = By.ClassName("form-title");
        By linkAtribuidos = By.LinkText("Atribuídos a Mim (não resolvidos)");
        By linkNaoAtribuidos = By.LinkText("Não Atribuídos");
        By linkRelatadosPorMim = By.LinkText("Relatados por Mim");
        By linkResolvidos = By.LinkText("Resolvidos");
        By linkModificadosRecentemente = By.LinkText("Modificados Recentemente");
        By linkMonitoradosPorMim = By.LinkText("Monitorados por Mim");

        #endregion

        #region Actions

        public string VerificarTexto()
        {
            return GetText(form);
        }

        public void ClicarEmAtribuidos()
        {
            Click(linkAtribuidos);
        }

        public void ClicarEmNaoAtribuidos()
        {
            Click(linkNaoAtribuidos);
        }

        public void ClicarEmRelatadosPorMim()
        {
            Click(linkRelatadosPorMim);
        }

        public void ClicarEmResolvidos()
        {
            Click(linkResolvidos);
        }

        public void ClicarEmModificadosRecentemente()
        {
            Click(linkModificadosRecentemente);
        }

        public void ClicarEmMonitoradosPorMim()
        {
            Click(linkMonitoradosPorMim);
        }

        public bool VerificarSeEntrouNoFiltro(string texto)
        {
            return driver.PageSource.Contains(texto);
        }

        public By CardEscolhido(string resumo)
        {
            return By.XPath($".//td[@class ='left']//span[contains(text(),'{resumo}')]/parent::td[@class='left']/parent::tr/td/span/a");
        }

        public void ClicaremUmCasoAtribuido(string resumo)
        {
            Click(CardEscolhido(resumo));
        }


        #endregion


    }
}
