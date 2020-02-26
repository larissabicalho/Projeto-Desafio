using CSharpSeleniumLarissaBicalho.Pages;


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

        public void InicializarUmMarcador(string nomeProjeto)
        {
            gerenciaFlows.EntrarNaPaginaDeGerencia(nomeProjeto);
            gerenciarProjetos.EntrarNoLinkdeGerenciarMarcadores();

        }
    }
}
