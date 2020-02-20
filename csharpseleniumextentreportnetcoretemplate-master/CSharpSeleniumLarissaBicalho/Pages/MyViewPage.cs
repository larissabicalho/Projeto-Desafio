﻿using CSharpSeleniumLarissaBicalho.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumLarissaBicalho.Pages
{
    public class MyViewPage : PageBase
    {
     
        By form = By.ClassName("form-title");
        By linkAtribuidos = By.LinkText("Atribuídos a Mim (não resolvidos)");
        By linkNaoAtribuidos = By.LinkText("Não Atribuídos");
        By linkRelatadosPorMim = By.LinkText("Relatados por Mim");
        By linkResolvidos = By.LinkText("Resolvidos");
        By linkModificadosRecentemente = By.LinkText("Modificados Recentemente");
        By linkMonitoradosPorMim = By.LinkText("Monitorados por Mim");

       

        public string verificarTexto()
        {
            return GetText(form);
        }

        public void clicarEmAtribuidos()
        {
            Click(linkAtribuidos);
        }

        public void clicarEmNaoAtribuidos()
        {
            Click(linkNaoAtribuidos);
        }

        public void clicarEmRelatadosPorMim()
        {
            Click(linkRelatadosPorMim);
        }

        public void clicarEmResolvidos()
        {
            Click(linkResolvidos);
        }

        public void clicarEmModificadosRecentemente()
        {
            Click(linkModificadosRecentemente);
        }

        public void clicarEmMonitoradosPorMim()
        {
            Click(linkMonitoradosPorMim);
        }


        public bool verificarSeEntrouNoFiltro(string texto)
        {
            return driver.PageSource.Contains(texto);
        }

        public By cardEscolhido(string resumo)
        {
            return By.XPath($".//td[@class ='left']//span[contains(text(),'{resumo}')]/parent::td[@class='left']/parent::tr/td/span/a");
        }

        public void clicaremUmCasoAtribuido(string resumo)
        {
            Click(cardEscolhido(resumo));
        }

       


    }
}
