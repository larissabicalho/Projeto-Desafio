﻿using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Flows;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumLarissaBicalho.Flows
{
    public class SeeCasesFlows
    {

        #region Page Object and Constructor

        LoginFlows loginFlows;
        MainPage mainPage;
        SeeCasesPage seeCasesPage;
     
        public SeeCasesFlows()
        {
            loginFlows = new LoginFlows();
            mainPage = new MainPage();
            seeCasesPage = new SeeCasesPage();

        }

        #endregion

        public void seeCases()
        {
           

            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            mainPage.ClicarEmVerCasos();

        }
    }
}
