using CSharpSeleniumLarissaBicalho.Pages;
using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumLarissaBicalho.Flows
{
    public class PerfilGlobalFlows
    {
        #region Page Object and Constructor

        GerenciaFlows gerenciaFlows;
        GerenciarProjetos gerenciarProjetos;

        public PerfilGlobalFlows()
        {
            gerenciaFlows = new GerenciaFlows();
            gerenciarProjetos = new GerenciarProjetos();

        }

        #endregion

        public void inicializarUmPerfil(string nomeProjeto)
        {
            gerenciaFlows.entrarNaPaginaDeGerencia(nomeProjeto);
            gerenciarProjetos.clicarEmGerenciarPerfisGlobais();
            
        }



    }
}
