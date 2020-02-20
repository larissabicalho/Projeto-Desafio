using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Bases;
using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;
using NUnit.Framework;


namespace CSharpSeleniumLarissaBicalho.Tests
{
    public class GerenciarTodosOsProjetosTests : TestBase
    {
        GerenciaFlows gerenciaFlows;
        GerenciarTodososProjetosPage gerenciarTodosOsProjetos;

        [Test]
        public void adicionarCategoria()
        {
            gerenciaFlows = new GerenciaFlows();
            gerenciarTodosOsProjetos = new GerenciarTodososProjetosPage();


            gerenciaFlows.entrarNaPaginaDeGerencia("Todos os Projetos");
            gerenciarTodosOsProjetos.adicionarCategoria("TesteLarissa");
            Assert.IsTrue(gerenciarTodosOsProjetos.acharCategoriaSelecionada("TesteLarissa"));
        }

        [Test]
        public void alterarCategoria()
        {


            gerenciaFlows = new GerenciaFlows();
            gerenciarTodosOsProjetos = new GerenciarTodososProjetosPage();


            gerenciaFlows.entrarNaPaginaDeGerencia("Todos os Projetos");

            gerenciarTodosOsProjetos.clicarEmGerenciarProjetos();
            gerenciarTodosOsProjetos.ClicarEmAlterarCategoria("TesteLarissa");
            gerenciarTodosOsProjetos.editarCategoria("TesteCat", "larissa.bicalho");
           
            
            Assert.IsTrue(gerenciarTodosOsProjetos.acharCategoriaSelecionada("TesteCat"));

        }

        [Test]
        public void deletarCategoria()
        {

            gerenciaFlows = new GerenciaFlows();
            gerenciarTodosOsProjetos = new GerenciarTodososProjetosPage();


            gerenciaFlows.entrarNaPaginaDeGerencia("Todos os Projetos");

            gerenciarTodosOsProjetos.clicarEmGerenciarProjetos();

            gerenciarTodosOsProjetos.ClicarEmDeletarCategoria("TesteCat");
            gerenciarTodosOsProjetos.deletarCategoria();
           
            Assert.IsFalse(gerenciarTodosOsProjetos.acharCategoriaSelecionada("TesteCat"));

        }

    }
}
