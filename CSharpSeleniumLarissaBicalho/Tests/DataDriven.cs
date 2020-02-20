using CSharpSeleniumLarissaBicalho.Bases;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using CSharpSeleniumLarissaBicalho.Flows;
using CSharpSeleniumLarissaBicalho.Pages;

namespace CSharpSeleniumLarissaBicalho.Tests
{
    public class DataDriven : TestBase
    {
  
            [Test, TestCaseSource("GetTestData")]
            public void MyExample_Test(
             string categoria,
             string frequencia,
             string gravidade,
             string prioridade,
             string perfil,
             string resumo,
             string descricao)
            {

            LoginFlows loginFlows = new LoginFlows();

            MainPage mainPage = new MainPage();

            ReportCasesPage reportPage = new ReportCasesPage();

            #region Parameters
            string usuario = "larissa.bicalho";
            string senha = "lalelu221510";
            string continuarRelatando = "não";
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
                    continuarRelatando,
                    "Enviar Relatório");

            reportPage.relatarCaso(continuarRelatando);

            reportPage.clicarSair();


        }


        public static IEnumerable<TestCaseData> GetTestData()
        {
            var testCases = new List<TestCaseData>();
            using (var csv = new LumenWorks.Framework.IO.Csv.CsvReader(new StreamReader("C:\\Users\\base2\\Downloads\\csharpseleniumextentreportnetcoretemplate-master\\CSharpSeleniumLarissaBicalho\\input.csv", true)))
            {
                    while (csv.ReadNextRecord())
                    {
                   
                        string categoria = string.Format(csv[0]);
                        string frequencia= string.Format(csv[1]);
                        string gravidade = string.Format(csv[2]);
                        string prioridade = string.Format(csv[3]);
                        string perfil = string.Format(csv[4]);
                        string resumo = string.Format(csv[5]);
                        string descricao = string.Format(csv[6]);
                        var testCase = new TestCaseData(categoria, frequencia, gravidade, prioridade, perfil, resumo, descricao);

                        testCases.Add(testCase);
                       
                
                    }
                   
                }

                 return testCases;
            }   
        }
    }

