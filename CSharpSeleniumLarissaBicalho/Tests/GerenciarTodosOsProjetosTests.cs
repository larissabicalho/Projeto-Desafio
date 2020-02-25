using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Bases;
using NUnit.Framework;
using CSharpSeleniumLarissaBicalho.Helpers;

namespace CSharpSeleniumLarissaBicalho.Tests
{
    public class GerenciarTodosOsProjetosTests : TestBase
    {
        GerenciaFlows gerenciaFlows;
        GerenciarTodososProjetosPage gerenciarTodosOsProjetos;

        [Test, Order(1)]
        public void adicionarCategoria()
        {
            gerenciaFlows = new GerenciaFlows();
            gerenciarTodosOsProjetos = new GerenciarTodososProjetosPage();

            string categoria = "TesteLarissa" + GeneralHelpers.ReturnStringWithRandomCharacters(3);

            gerenciaFlows.entrarNaPaginaDeGerencia("Todos os Projetos");
            gerenciarTodosOsProjetos.adicionarCategoria(categoria);
            Assert.IsTrue(gerenciarTodosOsProjetos.acharCategoriaSelecionada(categoria));
        }

        [Test, Order(2)]
        public void alterarCategoria()
        {


            gerenciaFlows = new GerenciaFlows();
            gerenciarTodosOsProjetos = new GerenciarTodososProjetosPage();


            gerenciaFlows.entrarNaPaginaDeGerencia("Todos os Projetos");

            gerenciarTodosOsProjetos.clicarEmGerenciarProjetos();

            string categoria = "TesteLarissa" + GeneralHelpers.ReturnStringWithRandomCharacters(3);

            string categoriaAdicionada = gerenciarTodosOsProjetos.adicionarCategoria(categoria);

            gerenciarTodosOsProjetos.ClicarEmAlterarCategoria(categoriaAdicionada);

            string categoriaEditada = "TesteLarissa" + GeneralHelpers.ReturnStringWithRandomCharacters(3);

            gerenciarTodosOsProjetos.editarCategoria(categoriaEditada, "larissa.bicalho");
           
            
            Assert.IsTrue(gerenciarTodosOsProjetos.acharCategoriaSelecionada(categoriaEditada));

        }

        [Test, Order(3)]
        public void deletarCategoria()
        {

            gerenciaFlows = new GerenciaFlows();
            gerenciarTodosOsProjetos = new GerenciarTodososProjetosPage();


            gerenciaFlows.entrarNaPaginaDeGerencia("Todos os Projetos");

            gerenciarTodosOsProjetos.clicarEmGerenciarProjetos();

            string categoria = "TesteLarissa" + GeneralHelpers.ReturnStringWithRandomCharacters(3);

            string categoriaAdicionada = gerenciarTodosOsProjetos.adicionarCategoria(categoria);


            gerenciarTodosOsProjetos.ClicarEmDeletarCategoria(categoriaAdicionada);
            gerenciarTodosOsProjetos.deletarCategoria();
           
            Assert.IsFalse(gerenciarTodosOsProjetos.acharCategoriaSelecionada(categoriaAdicionada));

        }

    }
}
