using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Bases;
using NUnit.Framework;
using CSharpSeleniumLarissaBicalho.Helpers;
using CSharpSeleniumExtentReportNetCoreTemplate.Helpers;

namespace CSharpSeleniumLarissaBicalho.Tests
{
    public class GerenciarTodosOsProjetosTests : TestBase
    {
        GerenciaFlows gerenciaFlows;
        GerenciarTodososProjetosPage gerenciarTodosOsProjetos;

        [Test]

        public void AdicionarCategoria()
        {
            gerenciaFlows = new GerenciaFlows();
            gerenciarTodosOsProjetos = new GerenciarTodososProjetosPage();

            string categoria = "TesteLarissa" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            gerenciaFlows.EntrarNaPaginaDeGerencia("Todos os Projetos");
            gerenciarTodosOsProjetos.AdicionarCategoria(categoria);

            Assert.IsTrue(gerenciarTodosOsProjetos.AcharCategoriaSelecionada(categoria));
        }

        [Test]

        public void AlterarCategoria()
        {


            gerenciaFlows = new GerenciaFlows();
            gerenciarTodosOsProjetos = new GerenciarTodososProjetosPage();


            gerenciaFlows.EntrarNaPaginaDeGerencia("Todos os Projetos");
            gerenciarTodosOsProjetos.ClicarEmGerenciarProjetos();
            string categoria = "TesteLarissa" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string categoriaAdicionada = gerenciarTodosOsProjetos.AdicionarCategoria(categoria);
            gerenciarTodosOsProjetos.ClicarEmAlterarCategoria(categoriaAdicionada);
            string categoriaEditada = "TesteLarissa" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            gerenciarTodosOsProjetos.EditarCategoria(categoriaEditada, "larissa.bicalho");
           
            
            Assert.IsTrue(gerenciarTodosOsProjetos.AcharCategoriaSelecionada(categoriaEditada));

        }

        [Test]
        public void DeletarCategoria()
        {

            gerenciaFlows = new GerenciaFlows();
            gerenciarTodosOsProjetos = new GerenciarTodososProjetosPage();


            gerenciaFlows.EntrarNaPaginaDeGerencia("Todos os Projetos");
            gerenciarTodosOsProjetos.ClicarEmGerenciarProjetos();
            string categoria = "TesteLarissa" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string categoriaAdicionada = gerenciarTodosOsProjetos.AdicionarCategoria(categoria);
            gerenciarTodosOsProjetos.ClicarEmDeletarCategoria(categoriaAdicionada);
            gerenciarTodosOsProjetos.DeletarCategoria();
           
            Assert.IsFalse(gerenciarTodosOsProjetos.AcharCategoriaSelecionada(categoriaAdicionada));

        }

    }
}
