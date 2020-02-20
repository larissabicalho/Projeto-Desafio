using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumLarissaBicalho.Flows
{
    public class MarcadorFlows

    {
        #region Page Object and Constructor
        GerenciaFlows gerenciaFlows;
        GerenciarProjetos gerenciarProjetos;


        public MarcadorFlows()
        {
            gerenciaFlows = new GerenciaFlows();
            gerenciarProjetos = new GerenciarProjetos();



        }

        #endregion

        public void inicializarUmMarcador(string nomeProjeto)
        {
            gerenciaFlows.entrarNaPaginaDeGerencia(nomeProjeto);
            gerenciarProjetos.entrarNoLinkdeGerenciarMarcadores();
           
        }
    }
}
