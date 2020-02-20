using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Bases;
using NUnit.Framework;


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


            gerenciaFlows.entrarNaPaginaDeGerencia("Todos os Projetos");
            gerenciarTodosOsProjetos.adicionarCategoria("TesteLarissa");
            Assert.IsTrue(gerenciarTodosOsProjetos.acharCategoriaSelecionada("TesteLarissa"));
        }

        [Test, Order(2)]
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

        [Test, Order(3)]
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
