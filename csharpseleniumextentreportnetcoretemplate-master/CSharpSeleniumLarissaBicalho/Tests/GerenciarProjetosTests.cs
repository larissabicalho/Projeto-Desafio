using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Bases;
using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Helpers;
using NUnit.Framework;
using CSharpSeleniumLarissaBicalho.Helpers;

namespace CSharpSeleniumLarissaBicalho.Tests
{
    public class GerenciarProjetosTests : TestBase

    {
        #region Pages and Flows Objects
        GerenciaFlows gerenciaFlows;
        MarcadorFlows marcadorFlows;
        GerenciarProjetos gerenciarProjetos;
        PerfilGlobalFlows perfilGlobalFlows;
     
        

        #endregion

        [Test]
        public void entrarNaPaginadeGerencia()
        {
            gerenciaFlows = new GerenciaFlows();
            gerenciarProjetos = new GerenciarProjetos();

            gerenciaFlows.entrarNaPaginaDeGerencia("Larissa Bicalho's Project");

            Assert.AreEqual("Informação do Site", gerenciarProjetos.VerificarTelaGerenciar());

        }

        [Test] 
        public void criarUmMarcador()
        {

            marcadorFlows = new MarcadorFlows();
            gerenciarProjetos = new GerenciarProjetos();
          
            

            marcadorFlows.inicializarUmMarcador( "Larissa Bicalho's Project");

            string marcador = "TesteLarissaMarcador" + GeneralHelpers.ReturnStringWithRandomCharacters(3);

             
            marcador =  gerenciarProjetos.criarMarcador(marcador, "klkepckpk");


            Assert.IsTrue(gerenciarProjetos.retornaSeOMarcadorFoiCriado(marcador));
          

        }

        [Test]
        public void nãoPreencherNomeMarcador()
        {
            marcadorFlows = new MarcadorFlows();
            gerenciarProjetos = new GerenciarProjetos();

            marcadorFlows.inicializarUmMarcador("Larissa Bicalho's Project");
            gerenciarProjetos.criarMarcador("", "ejfojjvojvoej");
            Assert.IsFalse(gerenciarProjetos.pesquisarMarcadorNaLista("Teste Larissa"));
        }

        [Test]
        
        public void atualizarMarcador()
        {

            marcadorFlows = new MarcadorFlows();
            gerenciarProjetos = new GerenciarProjetos();

            marcadorFlows.inicializarUmMarcador("Larissa Bicalho's Project");


            gerenciarProjetos.atualizarMarcador("Teste Larissa", "lowran.elias", "-Edit");

            Assert.AreEqual ("Detalhes do marcador: Teste Larissa", gerenciarProjetos.verificarSeAtualizouMarcador("Teste Larissa"));

        }

        [Test]

        public void apagarMarcador()
        {
            marcadorFlows = new MarcadorFlows();
            gerenciarProjetos = new GerenciarProjetos();

            marcadorFlows.inicializarUmMarcador("Larissa Bicalho's Project");
            gerenciarProjetos.apagarMarcador("Teste Larissa");

            Assert.IsFalse(gerenciarProjetos.pesquisarMarcadorNaLista("TesteNLarissa"));

        }

        [Test]
         public void adicionarPerfilGlobal()
        {
            perfilGlobalFlows = new PerfilGlobalFlows();
            gerenciarProjetos = new GerenciarProjetos();

            perfilGlobalFlows.inicializarUmPerfil("Larissa Bicalho's Project");
            gerenciarProjetos.adicionarUmPerfilGlobal("PlataformaTeste","SiSTEMA","Windows10","Testando Descricao1");
            
            Assert.IsTrue(gerenciarProjetos.verificarSeUmPerfilFoiCriado("PlataformaTeste SiSTEMA Windows10"));


        }

        [Test]

        public void verificarErroPlataforma() {

            perfilGlobalFlows = new PerfilGlobalFlows();
            gerenciarProjetos = new GerenciarProjetos();

            perfilGlobalFlows.inicializarUmPerfil("Larissa Bicalho's Project");
            gerenciarProjetos.clicarEmAdicionarPerfil();

            Assert.AreEqual("Um campo necessário 'Plataforma' estava vazio. Por favor, verifique novamente suas entradas.", gerenciarProjetos.verificarMensagemdeErro());

        }

        [Test]

        public void verificarErroSO()
        {

            perfilGlobalFlows = new PerfilGlobalFlows();
            gerenciarProjetos = new GerenciarProjetos();

            perfilGlobalFlows.inicializarUmPerfil("Larissa Bicalho's Project");
            gerenciarProjetos.preencherPlataforma("PlataformaTeste");
            gerenciarProjetos.clicarEmAdicionarPerfil();

            Assert.AreEqual("Um campo necessário 'Sistema Operacional' estava vazio. Por favor, verifique novamente suas entradas.", gerenciarProjetos.verificarMensagemdeErro());

        }

        [Test]

        public void verificarErroVersaoSO()
        {

            perfilGlobalFlows = new PerfilGlobalFlows();
            gerenciarProjetos = new GerenciarProjetos();

            perfilGlobalFlows.inicializarUmPerfil("Larissa Bicalho's Project");
            gerenciarProjetos.preencherPlataforma("PlataformaTeste");
            gerenciarProjetos.preencherSO("Windows");
            gerenciarProjetos.clicarEmAdicionarPerfil();

            Assert.AreEqual("Um campo necessário 'Versão' estava vazio. Por favor, verifique novamente suas entradas.", gerenciarProjetos.verificarMensagemdeErro());

        }

        

        [Test]

        public void editarPerfilGlobal()
        {
            perfilGlobalFlows = new PerfilGlobalFlows();
            gerenciarProjetos = new GerenciarProjetos();

            perfilGlobalFlows.inicializarUmPerfil("Larissa Bicalho's Project");
            gerenciarProjetos.editarPerfil("PlataformaTeste SiSTEMA Windows10", "Plataforma2Teste");
            
            Assert.IsTrue(gerenciarProjetos.verificarSeUmPerfilFoiCriado("Plataforma2Teste SiSTEMA Windows10"));


        }

        [Test]
        public void apagarPerfil()
        {

            perfilGlobalFlows = new PerfilGlobalFlows();
            gerenciarProjetos = new GerenciarProjetos();

            perfilGlobalFlows.inicializarUmPerfil("Larissa Bicalho's Project");
            gerenciarProjetos.apagarPefil("Plataforma2Teste SiSTEMA Windows10");

            Assert.IsFalse(gerenciarProjetos.verificarSeUmPerfilFoiCriado("Plataforma2Teste SiSTEMA Windows10"));

        }

    }
}
