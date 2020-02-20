using CSharpSeleniumLarissaBicalho.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumLarissaBicalho.Flows
{
   public class AdicionarAnotacoesAoCasoFlows
    {

        MyViewPage myViewPage;
        LoginFlows loginFlows;
        AdicionarAnotacoesAoCasoPage adicionarAnotacoesAoCasoPage;

        public AdicionarAnotacoesAoCasoFlows()
        {
            myViewPage = new MyViewPage();
            loginFlows = new LoginFlows();
            adicionarAnotacoesAoCasoPage = new AdicionarAnotacoesAoCasoPage();


        }

        public void anotacoesInicio()
        {
        
            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            string caso = "Larissa";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            myViewPage.clicaremUmCasoAtribuido(caso);
        }


    }
}
