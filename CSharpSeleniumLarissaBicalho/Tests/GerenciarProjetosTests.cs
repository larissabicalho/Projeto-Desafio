using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Bases;
using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Helpers;
using NUnit.Framework;

namespace CSharpSeleniumLarissaBicalho.Tests
{
    public class GerenciarProjetosTests : TestBase

    {
        #region Pages and Flows Objects
        GerenciaFlows gerenciaFlows;
        MarcadorFlows marcadorFlows;
        GerenciarProjetos gerenciarProjetos;
        PerfilGlobalFlows perfilGlobalFlows;

        string marcador = "TesteLarissaMarcador" + GeneralHelpers.ReturnStringWithRandomCharacters(3);


        #endregion

        [Test]
        public void entrarNaPaginadeGerencia()
        {
            gerenciaFlows = new GerenciaFlows();
            gerenciarProjetos = new GerenciarProjetos();

            gerenciaFlows.entrarNaPaginaDeGerencia("Larissa Bicalho's Project");

            

            Assert.AreEqual("Informação do Site", gerenciarProjetos.VerificarTelaGerenciar());

        }

        [Test, Order(1)]
        public void criarUmMarcador()
        {

            marcadorFlows = new MarcadorFlows();
            gerenciarProjetos = new GerenciarProjetos();
          
            

            marcadorFlows.inicializarUmMarcador( "Larissa Bicalho's Project");

            string marcador = "TesteLarissaMarcador" + GeneralHelpers.ReturnStringWithRandomCharacters(3);


            gerenciarProjetos.criarMarcador(marcador, "klkepckpk");

           

            Assert.IsTrue(gerenciarProjetos.retornaSeOMarcadorFoiCriado(marcador));
          

        }

        [Test, Order(4)]
        public void nãoPreencherNomeMarcador()
        {
            marcadorFlows = new MarcadorFlows();
            gerenciarProjetos = new GerenciarProjetos();

            marcadorFlows.inicializarUmMarcador("Larissa Bicalho's Project");
            gerenciarProjetos.criarMarcador("", "ejfojjvojvoej");
           
            Assert.IsFalse(gerenciarProjetos.pesquisarMarcadorNaLista("Teste Larissa"));
        }

        [Test, Order(2)]
        
        public void atualizarMarcador()
        {

            marcadorFlows = new MarcadorFlows();
            gerenciarProjetos = new GerenciarProjetos();

            marcadorFlows.inicializarUmMarcador("Larissa Bicalho's Project");

            string marcador = "TesteLarissaMarcador" + GeneralHelpers.ReturnStringWithRandomCharacters(3);

            string marcadorFeito = gerenciarProjetos.criarMarcador(marcador,"nnnnnnn");


            gerenciarProjetos.atualizarMarcador(marcadorFeito, "lowran.elias", "-Edit");

            Assert.AreEqual ("Detalhes do marcador: "+ marcadorFeito +"", gerenciarProjetos.verificarSeAtualizouMarcador(marcador));

        }

        [Test, Order(3)]

        public void apagarMarcador()
        {
            marcadorFlows = new MarcadorFlows();
            gerenciarProjetos = new GerenciarProjetos();

            marcadorFlows.inicializarUmMarcador("Larissa Bicalho's Project");

            string marcador = "TesteLarissaMarcador" + GeneralHelpers.ReturnStringWithRandomCharacters(3);

            string marcadorFeito = gerenciarProjetos.criarMarcador(marcador, "nnnnnnn");


            gerenciarProjetos.apagarMarcador(marcadorFeito);

            Assert.IsFalse(gerenciarProjetos.pesquisarMarcadorNaLista(marcadorFeito));

        }

        [Test, Order(5)]
         public void adicionarPerfilGlobal()
        {
            perfilGlobalFlows = new PerfilGlobalFlows();
            gerenciarProjetos = new GerenciarProjetos();

            perfilGlobalFlows.inicializarUmPerfil("Larissa Bicalho's Project");

            string plataforma = "PlataformaTeste" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            gerenciarProjetos.adicionarUmPerfilGlobal(plataforma,"SiSTEMA","Windows10","Testando Descricao1");
            
            Assert.IsTrue(gerenciarProjetos.verificarSeUmPerfilFoiCriado(""+plataforma+" SiSTEMA Windows10"));


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

        

        [Test, Order(6)]

        public void editarPerfilGlobal()
        {
            perfilGlobalFlows = new PerfilGlobalFlows();
            gerenciarProjetos = new GerenciarProjetos();

            perfilGlobalFlows.inicializarUmPerfil("Larissa Bicalho's Project");

            string plataformaAdicional = "PlataformaTeste" + GeneralHelpers.ReturnStringWithRandomCharacters(3);

            gerenciarProjetos.adicionarUmPerfilGlobal(plataformaAdicional, "SiSTEMA", "Windows10", "Testando Descricao2");

            string plataformaEditada = "PlataformaTeste" + GeneralHelpers.ReturnStringWithRandomCharacters(3);

            gerenciarProjetos.editarPerfil("" + plataformaAdicional + " SiSTEMA Windows10", plataformaEditada);


            Assert.IsTrue(gerenciarProjetos.verificarSeUmPerfilFoiCriado("" + plataformaEditada + " SiSTEMA Windows10"));


        }

        [Test, Order(7)]
        public void apagarPerfil()
        {

            perfilGlobalFlows = new PerfilGlobalFlows();
            gerenciarProjetos = new GerenciarProjetos();

            perfilGlobalFlows.inicializarUmPerfil("Larissa Bicalho's Project");


            string plataforma = "PlataformaTeste" + GeneralHelpers.ReturnStringWithRandomCharacters(3);

            gerenciarProjetos.adicionarUmPerfilGlobal(plataforma, "SiSTEMA", "Windows10", "Testando Descricao2");

            gerenciarProjetos.apagarPefil("" + plataforma +" SiSTEMA Windows10");

            Assert.IsFalse(gerenciarProjetos.verificarSeUmPerfilFoiCriado("" + plataforma +" SiSTEMA Windows10"));

        }

    }
}
