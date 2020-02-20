using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Bases;
using CSharpSeleniumLarissaBicalho.Flows;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumLarissaBicalho.Tests 
{
    public class MyViewTests : TestBase
    {
        [Test]
        public void verUmCaso()
        {
            LoginFlows loginFlows = new LoginFlows();
          
            MyViewPage myView = new MyViewPage();


            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            myView.clicaremUmCasoAtribuido("Teste3");
            Assert.AreEqual("Ver Detalhes do Caso [ Ir para as Anotações ]", myView.verificarTexto());
        }

        [Test]

        public void filtrarPorCasosAtribuidos()
        {
            LoginFlows loginFlows = new LoginFlows();

            MyViewPage myView = new MyViewPage();


            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            myView.clicarEmAtribuidos();
            Assert.IsTrue(myView.verificarSeEntrouNoFiltro("Visualizando Casos"));           


        }

        [Test]
        public void filtrarPorCasosNaoAtribuidos()
        {
            LoginFlows loginFlows = new LoginFlows();

            MyViewPage myView = new MyViewPage();


            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            myView.clicarEmNaoAtribuidos();
            Assert.IsTrue(myView.verificarSeEntrouNoFiltro("Visualizando Casos"));


        }

        [Test]
        public void filtrarPorRelatadorPorMin()
        {
            LoginFlows loginFlows = new LoginFlows();

            MyViewPage myView = new MyViewPage();


            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            myView.clicarEmRelatadosPorMim();
            Assert.IsTrue(myView.verificarSeEntrouNoFiltro("Visualizando Casos"));


        }

        [Test]
        public void filtrarPorResolvidos()
        {
            LoginFlows loginFlows = new LoginFlows();

            MyViewPage myView = new MyViewPage();


            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            myView.clicarEmResolvidos();
            Assert.IsTrue(myView.verificarSeEntrouNoFiltro("Visualizando Casos"));


        }

        [Test]
        public void filtrarPorModificadosRecentemente()
        {
            LoginFlows loginFlows = new LoginFlows();

            MyViewPage myView = new MyViewPage();


            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            myView.clicarEmModificadosRecentemente();
            Assert.IsTrue(myView.verificarSeEntrouNoFiltro("Visualizando Casos"));


        }

        [Test]
        public void filtrarPorMonitoradosPorMim()
        {
            LoginFlows loginFlows = new LoginFlows();

            MyViewPage myView = new MyViewPage();


            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            myView.clicarEmMonitoradosPorMim();
            Assert.IsTrue(myView.verificarSeEntrouNoFiltro("Visualizando Casos"));
        }


    }

 }

