using CSharpSeleniumLarissaBicalho.Bases;
using OpenQA.Selenium;

namespace CSharpSeleniumLarissaBicalho.Pages
{
	public class ReportCasesPage : PageBase
	{
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
		By projetoSelecionado  = By.XPath("//input[@value='Selecionar Projeto']");

		#endregion

		#region Relatar Mais Casos

		By relatarMaisCasos = By.XPath("//input[@value='Relatar Mais Casos']");

		#endregion

		#region Sair 

		By lnkSair = By.LinkText("Sair");

        #endregion

        #region Actions PreencherRelatorio

        public void selecionarCategoria( string categoria)
		{
			ComboBoxSelectByVisibleText(inputCategoria, categoria);
		}

		public void selecionarFrequencia(string frequencia)
		{
			ComboBoxSelectByVisibleText(inputFrequencia, frequencia);
		}

		public void selecionarGravidade (string gravidade)
		{
			ComboBoxSelectByVisibleText(inputGravidade, gravidade);
		}

		public void selecionarPrioridade (string prioridade)
		{
			ComboBoxSelectByVisibleText(inputPrioridade, prioridade);
		}

		public void selecionarPerfil(string profileId)
		{
			ComboBoxSelectByVisibleText(inputPerfil, profileId);
		}

		public void preencherResumo(string resumo)
		{
			SendKeys(inputResumo, resumo);
		}

		public void preencherDescricao(string descricao)
		{
			SendKeys(inputDescricao, descricao);
		}

		public void preencherPassos(string passos)
		{
			SendKeys(inputPassos, passos);
		}

		public void preencherDadosAdicionais(string adicionais)
		{
			SendKeys(inputAdicionais, adicionais);
		}

		public void enviarImagem(string image)
		{
			SendKeys(inputImage, image);
		}

		public By acharBotaoVisibilidade(string visibilidade)
		{
			return By.XPath($"//input[@name='view_state'][@value='{visibilidade}']");
		}

		public void clicarEmVisibilidade(string visibilidade)
		{
			Click(acharBotaoVisibilidade(visibilidade));
		}

		public void clicarEmContinuarReportando()
		{
			Click(rdContinuarReportando);
		}

		public By acharBotaoEnviarRelatorio(string valor)
		{
			return By.XPath($"//input[@value='{valor}']");
		}

	    public void clicarEmEnviarRelatorio(string valor)
		{
			Click(acharBotaoEnviarRelatorio(valor));
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
			selecionarCategoria(categoria);
			selecionarFrequencia(frequencia);
			selecionarGravidade(gravidade);
			selecionarPrioridade(prioridade);
			selecionarPerfil(profileId);
			preencherResumo(resumo);
			preencherDescricao(descricao);
			preencherPassos(passos);
			preencherDadosAdicionais(adicionais);
			enviarImagem(image);
			clicarEmVisibilidade(visibilidade);

			if (continuarRelatando.Equals("sim"))
				clicarEmContinuarReportando();

			clicarEmEnviarRelatorio(value);

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

			selecionarCategoria(categoria);
			selecionarFrequencia(frequencia);
			selecionarGravidade(gravidade);
			selecionarPrioridade(prioridade);
			selecionarPerfil(profileId);
			preencherResumo(resumo);
			preencherDescricao(descricao);


			if (continuarRelatando.Equals("sim"))
				clicarEmContinuarReportando();

			clicarEmEnviarRelatorio(value);

		}

		#endregion

		#region Escolher Projeto

		public void clicarEmRelataCaso()
		{
			Click(lnkRelatarCaso);
		}

		public void selecionarProjeto(string nomeProjeto)
		{
			ComboBoxSelectByVisibleText(cmbEscolherProjeto, nomeProjeto);
		}

		public void clicarEmSelecionarProjeto()
		{
			Click(projetoSelecionado);
		}

		public void escolherProjeto(string nomeProjeto) {
			clicarEmRelataCaso();
			selecionarProjeto(nomeProjeto);
			clicarEmSelecionarProjeto();
		}

		#endregion


		#region Relatar Casos

		public void clicarEmRelatarMaisCasos()
		{
			Click(relatarMaisCasos);
		}

		public void relatarCaso(string continuarRelatando)
		{
			if (continuarRelatando.Equals("sim"))
				clicarEmRelatarMaisCasos();
		}

		#endregion

		#region Sair

		public void clicarSair()
		{
			Click(lnkSair);
		}

        #endregion


    }
}