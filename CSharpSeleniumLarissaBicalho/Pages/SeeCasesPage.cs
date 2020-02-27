
using CSharpSeleniumLarissaBicalho.Bases;
using CSharpSeleniumLarissaBicalho.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;

namespace CSharpSeleniumLarissaBicalho.Pages
{
    public class SeeCasesPage : PageBase
    {
        #region Mapping

        #region  Ver Casos

        By form = By.ClassName("form-title");

        #endregion

        #region Tipos de Relatorios 
        By exportarCSV = By.LinkText("Exportar CSV");
        By exportarExcell = By.LinkText("Exportação para Excel");
        By imprimirRelatorio = By.LinkText("Imprimir Relatórios");
        By paginaDeRelatorios = By.XPath("//td[@class='form-title']/div");

        #endregion

        #region Pesquisa

        By informaNumeroPesquisa = By.XPath("//*[@id='filters_form_closed']/table/tbody/tr/td[1]/input[1]");

        #endregion

        #region Filtros

        By pesquisar = By.XPath("//*[@id='filters_form_closed']/table/tbody/tr/td[1]/input[2]");

        #endregion

        #region Copiar Um Caso

        By seleciona = By.Name("action");
        string copiar = "Copiar";
        By btnOk = By.XPath("//input[@value='OK']");
        By telaVisualizarCasos = By.XPath("//td[@class='form-title']/span[contains(text(),'Visualizando Casos')]");
        By selecionarProjeto = By.XPath("//table/tbody/tr/td/select");
        By selecionarCopiarCasos = By.XPath("//input[@value='Copiar Casos']");

        #endregion

        #endregion

        #region Mapping

        #region Casos 

        public By LinkDoCaso(string resumo) //testando o card
        {
            return By.XPath($".//td[@class='left' and contains(text(),'{resumo}')]/parent::tr/td/a");
        }

        public void ClicarEmUmCaso(string resumo)
        {
            Click(LinkDoCaso(resumo));

        }

        public string VerificarTexto()
        {
            return GetText(form);
        }

        #endregion


        #region Relatorios

        public bool VerificarSeORegistrodeEstaNaPasta(string filename)
        {

            bool encontrado = false;
            int timeout = 20;
            int tempo = 0;

            while (!encontrado)
            {

                bool exists = File.Exists(GeneralHelpers.GetProjectPath() + "Documentos" + @"\" + filename + "");

                if (exists)
                {

                    encontrado = true;
                    return true;
                }

                else
                    Thread.Sleep(500);
                tempo++;

                if (timeout == tempo)
                {
                    return false;
                }
            }

            return false;
        }

        public void ClicarEmCSV()
        {
            Click(exportarCSV);
        }

        public void TesteCSV()
        {
            ClicarEmCSV();
        }

        public void ClicarEmExcel()
        {
            Click(exportarExcell);
        }

        public void TesteExcel()
        {
            ClicarEmExcel();
        }

        public void ClicarEmImprimirRelatorios()
        {
            Click(imprimirRelatorio);
        }

        public void TesteImprimirCasos()
        {
            ClicarEmImprimirRelatorios();
        }

        public string VerificarSeEstaNaPaginaDeRelatorios()
        {
            return GetText(paginaDeRelatorios);
        }

        #endregion

        #region Filtro 

        public void InserirUmNumeroASerPesquisado(string numero)
        {

            SendKeys(informaNumeroPesquisa, numero);
        }

        public void ClicarEmPesquisarUmFiltro()
        {
            Click(pesquisar);
        }

        public void FiltrarUmCaso(string numero)
        {

            InserirUmNumeroASerPesquisado(numero);
            ClicarEmPesquisarUmFiltro();

        }

        public By CasoASerFiltrado(string numero)
        {

            return By.XPath($"//*[@id='buglist']/tbody/tr[4]/td[4]/a[contains(text(),'{numero}' )]");
        }

        public string VerificarSeONumeroEOFiltrado(string numero)
        {
            return GetText(CasoASerFiltrado(numero));
        }

        #endregion

        //copiar
        #region Copiar

        public By SelecionarCasoASerCopiado(string resumo)
        {
            return By.XPath($"//td[@class='left' and contains(text(),'{resumo}')]/parent::tr/td/input[1]");
        }

        public void ClicarNoCasoASerCopiado(string resumo)
        {
            Click(SelecionarCasoASerCopiado(resumo));
        }

        public void SelecionarOpcaodoCombodeCopiarOCaso()
        {
            ComboBoxSelectByVisibleText(seleciona, copiar);
        }

        public void ClicarNoBotaodeOk()
        {
            Click(btnOk);
        }

        public string VerificarAQuantidadeDeCasos()
        {
            IWebElement casos = driver.FindElement(telaVisualizarCasos);
            string[] words = casos.Text.Split(' ');
            string ultimo = words[words.Length - 1].Replace(")", "");

            return ultimo;

        }

        public bool VerificarSeUmCasoFoiCopiado(string antesDeCopia, string aposACopia)
        {
            int visualizandoAntesdeCopia = Convert.ToInt32(antesDeCopia);
            int visualizandoDepoisdeCopia = Convert.ToInt32(aposACopia);
            if ((visualizandoAntesdeCopia + 1) == visualizandoDepoisdeCopia)
            {
                return true;
            }

            return false;

        }

        public void SelecionarUmProjetoASerCopiado(string projeto)
        {
            ComboBoxSelectByVisibleText(selecionarProjeto, projeto);
        }

        public void ClicarEmCopiar()
        {
            Click(selecionarCopiarCasos);
        }

        public void CopiarUmCaso(string projeto, string resumo)
        {
            string quantidadedeCasosAntesDeCopia = VerificarAQuantidadeDeCasos();
            ClicarNoCasoASerCopiado(resumo); //TTTT
            SelecionarOpcaodoCombodeCopiarOCaso();
            ClicarNoBotaodeOk();
            SelecionarUmProjetoASerCopiado(projeto); // Larissa Bicalho's Project
            ClicarEmCopiar();
            WaitForElement(telaVisualizarCasos);
            string quantidadedeCasosDepoisDeCopia = VerificarAQuantidadeDeCasos();

            Assert.IsTrue(VerificarSeUmCasoFoiCopiado(quantidadedeCasosAntesDeCopia, quantidadedeCasosDepoisDeCopia));
        }

        #endregion

        #endregion


    }

}
