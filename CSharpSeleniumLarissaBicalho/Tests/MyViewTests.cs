using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Bases;
using CSharpSeleniumLarissaBicalho.Flows;
using NUnit.Framework;


namespace CSharpSeleniumLarissaBicalho.Tests 
{
    public class MyViewTests : TestBase
    {
        [Test]

        public void VerUmCaso()
        {
            LoginFlows loginFlows = new LoginFlows();
          
            MyViewPage myView = new MyViewPage();


            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            myView.ClicaremUmCasoAtribuido("Teste3");

            Assert.AreEqual("Ver Detalhes do Caso [ Ir para as Anotações ]", myView.VerificarTexto());
        }

        [Test]

        public void FiltrarPorCasosAtribuidos()
        {
            LoginFlows loginFlows = new LoginFlows();

            MyViewPage myView = new MyViewPage();


            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            myView.ClicarEmAtribuidos();

            Assert.IsTrue(myView.VerificarSeEntrouNoFiltro("Visualizando Casos"));           


        }

        [Test]

        public void FiltrarPorCasosNaoAtribuidos()
        {
            LoginFlows loginFlows = new LoginFlows();

            MyViewPage myView = new MyViewPage();


            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            myView.ClicarEmNaoAtribuidos();

            Assert.IsTrue(myView.VerificarSeEntrouNoFiltro("Visualizando Casos"));


        }

        [Test]

        public void FiltrarPorRelatadorPorMin()
        {
            LoginFlows loginFlows = new LoginFlows();

            MyViewPage myView = new MyViewPage();


            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            myView.ClicarEmRelatadosPorMim();

            Assert.IsTrue(myView.VerificarSeEntrouNoFiltro("Visualizando Casos"));


        }

        [Test]

        public void FiltrarPorResolvidos()
        {
            LoginFlows loginFlows = new LoginFlows();

            MyViewPage myView = new MyViewPage();


            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            myView.ClicarEmResolvidos();

            Assert.IsTrue(myView.VerificarSeEntrouNoFiltro("Visualizando Casos"));


        }

        [Test]

        public void FiltrarPorModificadosRecentemente()
        {
            LoginFlows loginFlows = new LoginFlows();

            MyViewPage myView = new MyViewPage();


            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            myView.ClicarEmModificadosRecentemente();

            Assert.IsTrue(myView.VerificarSeEntrouNoFiltro("Visualizando Casos"));


        }

        [Test]
        public void FiltrarPorMonitoradosPorMim()
        {
            LoginFlows loginFlows = new LoginFlows();

            MyViewPage myView = new MyViewPage();


            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            myView.ClicarEmMonitoradosPorMim();
            Assert.IsTrue(myView.VerificarSeEntrouNoFiltro("Visualizando Casos"));
        }


    }

 }

