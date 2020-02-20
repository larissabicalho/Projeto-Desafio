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

        public By linkDoCaso(string resumo) //testando o card
        {
            return By.XPath($".//td[@class='left' and contains(text(),'{resumo}')]/parent::tr/td/a");
        }

        public void clicarEmUmCaso(string resumo)
        {
            Click(linkDoCaso(resumo));

        }

        public string verificarTexto()
        {
            return GetText(form);
        }

        #endregion


        #region Relatorios

        public bool verificarSeORegistrodeEstaNaPasta(string filename)
        {

            bool encontrado = false;
            int timeout = 20;
            int tempo = 0;

            while (!encontrado)
            {

                bool exists = File.Exists(GeneralHelpers.GetProjectPath()  + "Documentos"+ @"\" + filename + "");

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

       public void clicarEmCSV()
        {
            Click(exportarCSV);
        }

        public void testeCSV()
        {
            clicarEmCSV();
        }

        public void clicarEmExcel()
        {
           Click(exportarExcell);
        }

        public void testeExcel()
        {
            clicarEmExcel();
        }

        public void clicarEmImprimirRelatorios()
        {
            Click(imprimirRelatorio);
        }
        public void testeImprimirCasos()
        {
            clicarEmImprimirRelatorios();
        }

        public string verificarSeEstaNaPaginaDeRelatorios()
        {
            return GetText(paginaDeRelatorios);
        }

        #endregion

        #region Filtro 

        public void inserirUmNumeroASerPesquisado(string numero)
        {
         
            SendKeys(informaNumeroPesquisa, numero);
        }

        public void clicarEmPesquisarUmFiltro()
        {
            Click(pesquisar);
        }

        public void filtrarUmCaso(string numero)
        {
         
            inserirUmNumeroASerPesquisado(numero);
            clicarEmPesquisarUmFiltro();

        }
         
        public By casoASerFiltrado(string numero)
        {

            return By.XPath($"//*[@id='buglist']/tbody/tr[4]/td[4]/a[contains(text(),'{numero}' )]");
        }

        public string verificarSeONumeroEOFiltrado(string numero)
        {
           return GetText(casoASerFiltrado(numero));
        }

        #endregion

        //copiar
        #region Copiar

        public By selecionarCasoASerCopiado(string resumo)
        {
            return  By.XPath($"//td[@class='left' and contains(text(),'{resumo}')]/parent::tr/td/input[1]");
        }

        public void clicarNoCasoASerCopiado(string resumo)
        {
            Click(selecionarCasoASerCopiado(resumo));
        }

        public void selecionarOpcaodoCombodeCopiarOCaso()
        {
            ComboBoxSelectByVisibleText(seleciona, copiar);
        }

        public void clicarNoBotaodeOk()
        {
            Click(btnOk);
        }

        public string verificarAQuantidadeDeCasos()
        {
            IWebElement casos = driver.FindElement(telaVisualizarCasos);
            string[] words = casos.Text.Split(' ');
            string ultimo = words[words.Length - 1].Replace(")", "");

            return ultimo;        

        }

        public bool verificarSeUmCasoFoiCopiado(string antesDeCopia, string aposACopia)
        {
            int visualizandoAntesdeCopia = Convert.ToInt32(antesDeCopia);
            int visualizandoDepoisdeCopia = Convert.ToInt32(aposACopia);
            if((visualizandoAntesdeCopia + 1) == visualizandoDepoisdeCopia)
            {
                return true;
            }

            return false;

        }

        public void selecionarUmProjetoASerCopiado(string projeto)
        {
            ComboBoxSelectByVisibleText(selecionarProjeto, projeto);
        }

        public void clicarEmCopiar()
        {
            Click(selecionarCopiarCasos);
        }

        public void copiarUmCaso(string projeto, string resumo)
        {
            string quantidadedeCasosAntesDeCopia = verificarAQuantidadeDeCasos();
            clicarNoCasoASerCopiado(resumo); //TTTT
            selecionarOpcaodoCombodeCopiarOCaso();
            clicarNoBotaodeOk();
            selecionarUmProjetoASerCopiado(projeto); // Larissa Bicalho's Project
            clicarEmCopiar();
            WaitForElement(telaVisualizarCasos);
            string quantidadedeCasosDepoisDeCopia = verificarAQuantidadeDeCasos();
            Assert.IsTrue(verificarSeUmCasoFoiCopiado(quantidadedeCasosAntesDeCopia, quantidadedeCasosDepoisDeCopia));
        }

        #endregion

        #endregion


    }

}
