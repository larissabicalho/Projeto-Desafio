using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Bases;
using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumLarissaBicalho.Tests
{
    public class SeeCasesTests : TestBase
    {
    
        SeeCasesPage seeCasesPage;
        GerenciarProjetos gerenciarProjetos;
        SeeCasesFlows seeCasesFlows;


        [Test]
        public void visualizarUmCaso()
        {
            seeCasesFlows = new SeeCasesFlows();
            seeCasesPage = new SeeCasesPage();

            seeCasesFlows.seeCases();
            seeCasesPage.clicarEmUmCaso("TTTT");

            Assert.AreEqual("Ver Detalhes do Caso [ Ir para as Anotações ]", seeCasesPage.verificarTexto());

        }

        [Test]
        public void exportandoCSV()
        {

            seeCasesFlows = new SeeCasesFlows();
            seeCasesPage = new SeeCasesPage();

            seeCasesFlows.seeCases();
            seeCasesPage.testeCSV();
            Assert.IsTrue(seeCasesPage.verificarSeORegistrodeEstaNaPasta("larissa.bicalho.csv"));
        }

        [Test]
        public void exportandoXML()
        {
            seeCasesFlows = new SeeCasesFlows();
            seeCasesPage = new SeeCasesPage();

            seeCasesFlows.seeCases();

            seeCasesPage.testeExcel();
            //verificar como prossegir com aquela mensagem
            Assert.IsTrue(seeCasesPage.verificarSeORegistrodeEstaNaPasta("larissa.bicalho.xml"));
        }

        [Test]
        public void Imprimir()
        {

            seeCasesFlows = new SeeCasesFlows();
            seeCasesPage = new SeeCasesPage();
            gerenciarProjetos = new GerenciarProjetos();

            seeCasesFlows.seeCases();

            gerenciarProjetos.escolherNomeProjeto("Larissa Bicalho's Project");
            seeCasesPage.testeImprimirCasos();
            Assert.AreEqual("MantisBT - Larissa Bicalho's Project", seeCasesPage.verificarSeEstaNaPaginaDeRelatorios());

        }

        [Test]
        public void filtraUmNumero()
        {

            seeCasesFlows = new SeeCasesFlows();
            seeCasesPage = new SeeCasesPage();
            gerenciarProjetos = new GerenciarProjetos();

            seeCasesFlows.seeCases();
            gerenciarProjetos.escolherNomeProjeto("Larissa Bicalho's Project");
            seeCasesPage.filtrarUmCaso("0003533");

            Assert.AreEqual("0003533", seeCasesPage.verificarSeONumeroEOFiltrado("0003533"));
       
        }

        [Test]
        public void copiarUmCaso()
        {
            seeCasesFlows = new SeeCasesFlows();
            seeCasesPage = new SeeCasesPage();
            gerenciarProjetos = new GerenciarProjetos(); 

            seeCasesFlows.seeCases();
           
            gerenciarProjetos.escolherNomeProjeto("Larissa Bicalho's Project");

            seeCasesPage.copiarUmCaso("Larissa Bicalho's Project", "Teste1");
        }

    }
}
