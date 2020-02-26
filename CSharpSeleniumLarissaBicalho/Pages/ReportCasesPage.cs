using CSharpSeleniumLarissaBicalho.Bases;
using OpenQA.Selenium;

namespace CSharpSeleniumLarissaBicalho.Pages
{
    public class ReportCasesPage : PageBase
    {

        #region Mapping

        #region RelatarCaso

        By inputCategoria = By.Name("category_id");
        By inputFrequencia = By.Name("reproducibility");
        By inputGravidade = By.Name("severity");
        By inputPrioridade = By.Name("priority");
        By inputPerfil = By.Name("profile_id");
        By inputResumo = By.Name("summary");
        By inputDescricao = By.Name("description");
        By inputPassos = By.Name("steps_to_reproduce");
        By inputAdicionais = By.Name("additional_info");
        By inputImage = By.Id("ufile[]");
        By rdContinuarReportando = By.Id("report_stay");

        #endregion

        #region Selecionar Projeto 

        By lnkRelatarCaso = By.LinkText("Relatar Caso");
        By cmbEscolherProjeto = By.XPath("//tr[2]/td[2]/select");
        By projetoSelecionado = By.XPath("//input[@value='Selecionar Projeto']");

        #endregion

        #region Relatar Mais Casos

        By relatarMaisCasos = By.XPath("//input[@value='Relatar Mais Casos']");

        #endregion

        #region Sair 

        By lnkSair = By.LinkText("Sair");

        #endregion

        #endregion

        #region Actions

        #region  Preencher Relatorio

        public void SelecionarCategoria(string categoria)
        {
            ComboBoxSelectByVisibleText(inputCategoria, categoria);
        }

        public void SelecionarFrequencia(string frequencia)
        {
            ComboBoxSelectByVisibleText(inputFrequencia, frequencia);
        }

        public void SelecionarGravidade(string gravidade)
        {
            ComboBoxSelectByVisibleText(inputGravidade, gravidade);
        }

        public void SelecionarPrioridade(string prioridade)
        {
            ComboBoxSelectByVisibleText(inputPrioridade, prioridade);
        }

        public void SelecionarPerfil(string profileId)
        {
            ComboBoxSelectByVisibleText(inputPerfil, profileId);
        }

        public void PreencherResumo(string resumo)
        {
            SendKeys(inputResumo, resumo);
        }

        public void PreencherDescricao(string descricao)
        {
            SendKeys(inputDescricao, descricao);
        }

        public void PreencherPassos(string passos)
        {
            SendKeys(inputPassos, passos);
        }

        public void PreencherDadosAdicionais(string adicionais)
        {
            SendKeys(inputAdicionais, adicionais);
        }

        public void EnviarImagem(string image)
        {
            SendKeys(inputImage, image);
        }

        public By AcharBotaoVisibilidade(string visibilidade)
        {
            return By.XPath($"//input[@name='view_state'][@value='{visibilidade}']");
        }

        public void ClicarEmVisibilidade(string visibilidade)
        {
            Click(AcharBotaoVisibilidade(visibilidade));
        }

        public void ClicarEmContinuarReportando()
        {
            Click(rdContinuarReportando);
        }

        public By AcharBotaoEnviarRelatorio(string valor)
        {
            return By.XPath($"//input[@value='{valor}']");
        }

        public void ClicarEmEnviarRelatorio(string valor)
        {
            Click(AcharBotaoEnviarRelatorio(valor));
        }

        public void PreencherRelatarCaso(string categoria,
        string frequencia,
        string gravidade,
        string prioridade,
        string profileId,
        string resumo,
        string descricao,
        string passos,
        string adicionais,
        string image,
        string visibilidade,
        string continuarRelatando,
        string value)
        {
            SelecionarCategoria(categoria);
            SelecionarFrequencia(frequencia);
            SelecionarGravidade(gravidade);
            SelecionarPrioridade(prioridade);
            SelecionarPerfil(profileId);
            PreencherResumo(resumo);
            PreencherDescricao(descricao);
            PreencherPassos(passos);
            PreencherDadosAdicionais(adicionais);
            EnviarImagem(image);
            ClicarEmVisibilidade(visibilidade);

            if (continuarRelatando.Equals("sim"))
                ClicarEmContinuarReportando();

            ClicarEmEnviarRelatorio(value);

        }

        public void PreencherRelatarCaso(string categoria,
        string frequencia,
        string gravidade,
        string prioridade,
        string profileId,
        string resumo,
        string descricao,
        string continuarRelatando,
        string value)
        {

            SelecionarCategoria(categoria);
            SelecionarFrequencia(frequencia);
            SelecionarGravidade(gravidade);
            SelecionarPrioridade(prioridade);
            SelecionarPerfil(profileId);
            PreencherResumo(resumo);
            PreencherDescricao(descricao);


            if (continuarRelatando.Equals("sim"))
                ClicarEmContinuarReportando();

            ClicarEmEnviarRelatorio(value);

        }

        #endregion

        #region Escolher Projeto

        public void ClicarEmRelataCaso()
        {
            Click(lnkRelatarCaso);
        }

        public void SelecionarProjeto(string nomeProjeto)
        {
            ComboBoxSelectByVisibleText(cmbEscolherProjeto, nomeProjeto);
        }

        public void ClicarEmSelecionarProjeto()
        {
            Click(projetoSelecionado);
        }

        public void EscolherProjeto(string nomeProjeto)
        {
            ClicarEmRelataCaso();
            SelecionarProjeto(nomeProjeto);
            ClicarEmSelecionarProjeto();
        }

        #endregion


        #region Relatar Casos

        public void ClicarEmRelatarMaisCasos()
        {
            Click(relatarMaisCasos);
        }

        public void RelatarCaso(string continuarRelatando)
        {
            if (continuarRelatando.Equals("sim"))
                ClicarEmRelatarMaisCasos();
        }

        #endregion

        #region Sair

        public void ClicarSair()
        {
            Click(lnkSair);
        }

        #endregion

        #endregion

    }
}