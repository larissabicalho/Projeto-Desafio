using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Bases;
using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Helpers;
using NUnit.Framework;
using CSharpSeleniumExtentReportNetCoreTemplate.Helpers;

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
        public void EntrarNaPaginadeGerencia()
        {
            gerenciaFlows = new GerenciaFlows();
            gerenciarProjetos = new GerenciarProjetos();

            gerenciaFlows.EntrarNaPaginaDeGerencia("Larissa Bicalho's Project");

            
            Assert.AreEqual("Informação do Site", gerenciarProjetos.VerificarTelaGerenciar());

        }

        [Test]
        public void CriarUmMarcador()
        {

            marcadorFlows = new MarcadorFlows();
            gerenciarProjetos = new GerenciarProjetos();
                     

            marcadorFlows.InicializarUmMarcador( "Larissa Bicalho's Project");
            string marcador = "TesteLarissaMarcador" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            gerenciarProjetos.CriarMarcador(marcador, "klkepckpk");
          
            Assert.IsTrue(gerenciarProjetos.RetornaSeOMarcadorFoiCriado(marcador));
          

        }

        [Test]
        public void NãoPreencherNomeMarcador()
        {
            marcadorFlows = new MarcadorFlows();
            gerenciarProjetos = new GerenciarProjetos();

            marcadorFlows.InicializarUmMarcador("Larissa Bicalho's Project");
            gerenciarProjetos.CriarMarcador("", "ejfojjvojvoej");
           
            Assert.IsFalse(gerenciarProjetos.PesquisarMarcadorNaLista("Teste Larissa"));
        }

        [Test]
        
        public void AtualizarMarcador()
        {

            marcadorFlows = new MarcadorFlows();
            gerenciarProjetos = new GerenciarProjetos();

            marcadorFlows.InicializarUmMarcador("Larissa Bicalho's Project");
            string marcador = "TesteLarissaMarcador" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string marcadorFeito = gerenciarProjetos.CriarMarcador(marcador,"nnnnnnn");
            gerenciarProjetos.AtualizarMarcador(marcadorFeito, "lowran.elias", "-Edit");

            Assert.AreEqual ("Detalhes do marcador: "+ marcadorFeito +"", gerenciarProjetos.VerificarSeAtualizouMarcador(marcador));

        }

        [Test]

        public void ApagarMarcador()
        {
            marcadorFlows = new MarcadorFlows();
            gerenciarProjetos = new GerenciarProjetos();

            marcadorFlows.InicializarUmMarcador("Larissa Bicalho's Project");
            string marcador = "TesteLarissaMarcador" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string marcadorFeito = gerenciarProjetos.CriarMarcador(marcador, "nnnnnnn");
            gerenciarProjetos.ApagarMarcador(marcadorFeito);

            Assert.IsFalse(gerenciarProjetos.PesquisarMarcadorNaLista(marcadorFeito));

        }

        [Test]

         public void AdicionarPerfilGlobal()
        {
            perfilGlobalFlows = new PerfilGlobalFlows();
            gerenciarProjetos = new GerenciarProjetos();

            perfilGlobalFlows.InicializarUmPerfil("Larissa Bicalho's Project");
            string plataforma = "PlataformaTeste" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            gerenciarProjetos.AdicionarUmPerfilGlobal(plataforma,"SiSTEMA","Windows10","Testando Descricao1");
            
            Assert.IsTrue(gerenciarProjetos.VerificarSeUmPerfilFoiCriado(""+plataforma+" SiSTEMA Windows10"));


        }

        [Test]

        public void VerificarErroPlataforma() {

            perfilGlobalFlows = new PerfilGlobalFlows();
            gerenciarProjetos = new GerenciarProjetos();

            perfilGlobalFlows.InicializarUmPerfil("Larissa Bicalho's Project");
            gerenciarProjetos.ClicarEmAdicionarPerfil();

            Assert.AreEqual("Um campo necessário 'Plataforma' estava vazio. Por favor, verifique novamente suas entradas.", gerenciarProjetos.VerificarMensagemdeErro());

        }

        [Test]

        public void VerificarErroSO()
        {

            perfilGlobalFlows = new PerfilGlobalFlows();
            gerenciarProjetos = new GerenciarProjetos();

            perfilGlobalFlows.InicializarUmPerfil("Larissa Bicalho's Project");
            gerenciarProjetos.PreencherPlataforma("PlataformaTeste");
            gerenciarProjetos.ClicarEmAdicionarPerfil();

            Assert.AreEqual("Um campo necessário 'Sistema Operacional' estava vazio. Por favor, verifique novamente suas entradas.", gerenciarProjetos.VerificarMensagemdeErro());

        }

        [Test]

        public void VerificarErroVersaoSO()
        {

            perfilGlobalFlows = new PerfilGlobalFlows();
            gerenciarProjetos = new GerenciarProjetos();

            perfilGlobalFlows.InicializarUmPerfil("Larissa Bicalho's Project");
            gerenciarProjetos.PreencherPlataforma("PlataformaTeste");
            gerenciarProjetos.PreencherSO("Windows");
            gerenciarProjetos.ClicarEmAdicionarPerfil();

            Assert.AreEqual("Um campo necessário 'Versão' estava vazio. Por favor, verifique novamente suas entradas.", gerenciarProjetos.VerificarMensagemdeErro());

        }

        

        [Test]

        public void EditarPerfilGlobal()
        {
            perfilGlobalFlows = new PerfilGlobalFlows();
            gerenciarProjetos = new GerenciarProjetos();

            perfilGlobalFlows.InicializarUmPerfil("Larissa Bicalho's Project");
            string plataformaAdicional = "PlataformaTeste" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            gerenciarProjetos.AdicionarUmPerfilGlobal(plataformaAdicional, "SiSTEMA", "Windows10", "Testando Descricao2");
            string plataformaEditada = "PlataformaTeste" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            gerenciarProjetos.EditarPerfil("" + plataformaAdicional + " SiSTEMA Windows10", plataformaEditada);

            Assert.IsTrue(gerenciarProjetos.VerificarSeUmPerfilFoiCriado("" + plataformaEditada + " SiSTEMA Windows10"));

        }

        [Test]

        public void ApagarPerfil()
        {

            perfilGlobalFlows = new PerfilGlobalFlows();
            gerenciarProjetos = new GerenciarProjetos();

            perfilGlobalFlows.InicializarUmPerfil("Larissa Bicalho's Project");
            string plataforma = "PlataformaTeste" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            gerenciarProjetos.AdicionarUmPerfilGlobal(plataforma, "SiSTEMA", "Windows10", "Testando Descricao2");
            gerenciarProjetos.ApagarPefil("" + plataforma +" SiSTEMA Windows10");

            Assert.IsFalse(gerenciarProjetos.VerificarSeUmPerfilFoiCriado("" + plataforma +" SiSTEMA Windows10"));

        }

    }
}
