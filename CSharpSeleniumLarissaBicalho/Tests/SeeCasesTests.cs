using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Bases;
using NUnit.Framework;


namespace CSharpSeleniumLarissaBicalho.Tests
{
    public class SeeCasesTests : TestBase
    {
    
        SeeCasesPage seeCasesPage;
        GerenciarProjetos gerenciarProjetos;
        SeeCasesFlows seeCasesFlows;


        [Test]

        public void VisualizarUmCaso()
        {
            seeCasesFlows = new SeeCasesFlows();
            seeCasesPage = new SeeCasesPage();

            seeCasesFlows.SeeCases();
            seeCasesPage.ClicarEmUmCaso("TTTT");

            Assert.AreEqual("Ver Detalhes do Caso [ Ir para as Anotações ]", seeCasesPage.VerificarTexto());

        }

        [Test]

        public void ExportandoCSV()
        {

            seeCasesFlows = new SeeCasesFlows();
            seeCasesPage = new SeeCasesPage();

            seeCasesFlows.SeeCases();
            seeCasesPage.TesteCSV();

            Assert.IsTrue(seeCasesPage.VerificarSeORegistrodeEstaNaPasta("larissa.bicalho.csv"));
        }

        [Test]

        public void ExportandoXML()
        {
            seeCasesFlows = new SeeCasesFlows();
            seeCasesPage = new SeeCasesPage();

            seeCasesFlows.SeeCases();

            seeCasesPage.TesteExcel();

            //verificar como prossegir com aquela mensagem
            Assert.IsTrue(seeCasesPage.VerificarSeORegistrodeEstaNaPasta("larissa.bicalho.xml"));
        }

        [Test]

        public void Imprimir()
        {

            seeCasesFlows = new SeeCasesFlows();
            seeCasesPage = new SeeCasesPage();
            gerenciarProjetos = new GerenciarProjetos();

            seeCasesFlows.SeeCases();

            gerenciarProjetos.EscolherNomeProjeto("Larissa Bicalho's Project");
            seeCasesPage.TesteImprimirCasos();

            Assert.AreEqual("MantisBT - Larissa Bicalho's Project", seeCasesPage.VerificarSeEstaNaPaginaDeRelatorios());

        }

        [Test]

        public void FiltraUmNumero()
        {

            seeCasesFlows = new SeeCasesFlows();
            seeCasesPage = new SeeCasesPage();
            gerenciarProjetos = new GerenciarProjetos();

            seeCasesFlows.SeeCases();
            gerenciarProjetos.EscolherNomeProjeto("Larissa Bicalho's Project");
            seeCasesPage.FiltrarUmCaso("0003533");

            Assert.AreEqual("0003533", seeCasesPage.VerificarSeONumeroEOFiltrado("0003533"));
       
        }

        [Test]

        public void CopiarUmCaso()
        {
            seeCasesFlows = new SeeCasesFlows();
            seeCasesPage = new SeeCasesPage();
            gerenciarProjetos = new GerenciarProjetos(); 

            seeCasesFlows.SeeCases();
           
            gerenciarProjetos.EscolherNomeProjeto("Larissa Bicalho's Project");

            seeCasesPage.CopiarUmCaso("Larissa Bicalho's Project", "Teste1");
        }

    }
}
