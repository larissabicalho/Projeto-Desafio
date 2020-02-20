using CSharpSeleniumLarissaBicalho.Bases;
using System.Linq;
using System.Reflection.Metadata;
using NUnit.Framework;
using CSharpSeleniumLarissaBicalho.Helpers;
using System;
using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;

// /Users/larissabicalho/Downloads/coruja-2_xl.jpeg

namespace CSharpSeleniumLarissaBicalho.Tests
{
	public class ReportCasesTest : TestBase
	{
		LoginFlows loginFlows;
		ReportCasesPage reportPage;

		[TestCase("[Todos os Projetos] a", "sempre", "pequeno", "normal", "Desktop Windows 10",
            "resumo", "descricao", "Passos para Reproduzir", "add", "C:\\Users\\base2\\Downloads\\base.jpg",
            "10", "nao", "Operação realizada com sucesso")]
		
		[TestCase("(selecione)", "sempre", "pequeno","normal","Desktop  Windows 10", 
        		  "resumo", "descricao", "Passos para Reproduzir","add", "C:\\Users\\base2\\Downloads\\base.jpg",
                  "10","nao","Um campo necessário 'Categoria' estava vazio.  Por favor, verifique novamente suas entradas.")]
        [TestCase("[Todos os Projetos] a", "sempre", "pequeno", "normal", "Desktop  Windows 10",
				   "resumo", "", "Passos para Reproduzir", "add", "C:\\Users\\base2\\Downloads\\base.jpg",
		           "10", "nao", "Um campo necessário 'Descrição' estava vazio.  Por favor, verifique novamente suas entradas.")]
        [TestCase("[Todos os Projetos] a", "sempre", "pequeno", "normal", "Desktop  Windows 10",
				   "", "descricao", "Passos para Reproduzir", "add", "C:\\Users\\base2\\Downloads\\base.jpg",
			             "10", "nao", "Um campo necessário 'Resumo' estava vazio.  Por favor, verifique novamente suas entradas.")]
        [TestCase("[Todos os Projetos] a", "sempre", "pequeno", "normal", "Desktop  Windows 10",
				  "resumo", "descricao", "Passos para Reproduzir", "add", "C:\\Users\\base2\\Downloads\\base.jpg",
				  "10", "sim", "Digite os Detalhes do Relatório")]

		
		public void TesteRelatarCasos(
			string categoria,
            string frequencia,
            string gravidade,
            string prioridade,
            string perfil,
            string resumo,
            string descricao,
            string passos,
            string adicionais,
            string image,
            string visibilidade,
            string continuarRelatando,
            string msg
            )
		{
			 loginFlows = new LoginFlows();
			 reportPage = new ReportCasesPage();

			#region Parameters
			string usuario = "larissa.bicalho";
			string senha = "lalelu221510";
			#endregion

			loginFlows.EfetuarLogin(usuario, senha);
			reportPage.escolherProjeto("Larissa Bicalho's Project");
			
			reportPage.PreencherRelatarCaso(
					categoria,
					frequencia,
					gravidade,
					prioridade,
					perfil,
					resumo,
					descricao,
					passos,
					adicionais,
					image,
					visibilidade,
					continuarRelatando,
					"Enviar Relatório");

			reportPage.relatarCaso(continuarRelatando);


			Assert.True(DriverFactory.INSTANCE.PageSource.Contains(msg));
			
			reportPage.clicarSair();
		}

		



	}

}

