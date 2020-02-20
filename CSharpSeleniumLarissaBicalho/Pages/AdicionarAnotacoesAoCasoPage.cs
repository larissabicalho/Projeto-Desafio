using CSharpSeleniumLarissaBicalho.Bases;
using OpenQA.Selenium;

namespace CSharpSeleniumLarissaBicalho.Pages
{
    public class AdicionarAnotacoesAoCasoPage : PageBase
    {
        #region Mapping

        #region AdicionarAnotacao

        By btnAdicionarAnotacao = By.XPath("//input[@value='Adicionar Anotação']");
        By digitarAAnotacao = By.Name("bugnote_text");

        #endregion

        #region AlterarAnotacao

        By btnAtualizarInformacao = By.XPath(".//input[@value='Atualizar Informação']");
        By textoASerAlterado = By.Name("bugnote_text");
        By lnkVoltar = By.LinkText("Voltar");

        #endregion

        #region ApagarAnotacao

        By btnapagarAnotacao = By.XPath("//input[@value='Apagar Anotação']");

        #endregion

        #endregion


        #region Action

        #region AdicionarAnotacao

        public void clicarEmAdicionarAnotacao()
        {
            Click(btnAdicionarAnotacao);
        }

        public void insererAnotacaoAoCaso(string anotacao)
        {
            SendKeys(digitarAAnotacao, anotacao);
            clicarEmAdicionarAnotacao();

        }

        public By pageVerificarSeAAnotacaoFoiInserida(string anotacao)
        {
            //testee
            return By.XPath($"//td[@class='bugnote-note-public' and contains(text(),'{anotacao}')]");

        }

        public string verificarSeAAnotaçãoFoiInserida(string anotacao)
        {
            return GetText(pageVerificarSeAAnotacaoFoiInserida(anotacao));
        }


        #endregion

        #region Alterar Anotacao 

        public By btnAlterarAnotacao(string anotacao)
        {
            //teste

            return By.XPath($"//td[@class='bugnote-note-public' and contains(text(),'{anotacao}')]/parent::tr/td/div[@class='small']/form[1]");
        }


        public void clicarEmAlterarAnotação(string anotacao)
        {
            Click(btnAlterarAnotacao(anotacao));
        }

        public void limparDado()
        {
            driver.FindElement(textoASerAlterado).Clear();
        }

        public void preencherAnotacaoEditada(string anotacao)
        {
            SendKeys(textoASerAlterado, anotacao);
        }

        public void clicarNoBotaoDeAtualizarAnotacao()
        {
            Click(btnAtualizarInformacao);
        }


        public void alterarAnotacao(string anotacao, string anotacaoEditada)
        {
            clicarEmAlterarAnotação(anotacao);
            limparDado();
            preencherAnotacaoEditada(anotacaoEditada);
            clicarNoBotaoDeAtualizarAnotacao();

        }

        public void clicarEmVoltar()
        {
            Click(lnkVoltar);
        }
        public void entraremAlterarAnotacaoSemAlterar(string anotacao)
        {
            clicarEmAlterarAnotação(anotacao);
            clicarEmVoltar();
        }

        #endregion


        #region Apagar Anotacao

        public By btnApagarUmaAnotacao(string anotacao)
        {
            return By.XPath($"//td[@class='bugnote-note-public' and contains(text(),'{anotacao}')]/parent::tr/td/div[@class='small']/form[2]");
        }

        public void clicarEmApagarAnotacao(string anotacao)
        {
            Click(btnApagarUmaAnotacao(anotacao));
        }

        public void clicarEmConfirmarAExclusaoDaAnotacao()
        {
            Click(btnapagarAnotacao);
        }

        public void apagarAnotacao(string anotacao)
        {
            clicarEmApagarAnotacao(anotacao);
            clicarEmConfirmarAExclusaoDaAnotacao();
        }

        public bool confirmarSeAAnotaçãoFoiApagada(string anotacao)
        {
            try
            {

                driver.FindElement(By.XPath($"//td[@class='bugnote-note-public' and contains(text(),'{anotacao}')]"));
                return true;
            }
            catch (WebDriverException e)
            {

                return false;
            }

        }

        #endregion


        #region Anotacao Privada

        public By verificarOTextoAnotacaoPrivada(string anotacao)
        {
            return  By.XPath($"//td[@class='bugnote-note-private' and contains(text(),'{anotacao}')]/parent::tr/td/span[contains(text(),'[ privado ]')]");
        }


        public bool verificarSeAAnotacaoEstaPrivada(string anotacao)
        {
            try
            {
                ReturnIfElementIsEnabled(verificarOTextoAnotacaoPrivada(anotacao));
                return true;
            }
            catch (WebDriverException e)
            {
                return false;
            }
        }

        public By  btnTornarUmaAnotacaoPrivada(string anotacao)
        {
            return  By.XPath($"//td[@class='bugnote-note-public' and contains(text(),'{anotacao}')]/parent::tr/td/div[@class='small']/form[3]/input[@value='Tornar Privado']");
        }


        public void tornarAAnotacaoPrivada(string anotacao)
        {
            Click(btnTornarUmaAnotacaoPrivada(anotacao));

        }

        #endregion

        #region Privada

        public bool verificarSeAAnotacaoEstaPublica(string anotacao)
        {
            try
            {
                WaitForElement(btnTornarUmaAnotacaoPrivada(anotacao));
                ReturnIfElementIsEnabled(btnTornarUmaAnotacaoPrivada(anotacao));
                return true;
            }
            catch (WebDriverException e)
            {
                return false;
            }
        }

        #endregion

        #region Publica

        public By btnTonarUmaAnotacaoPublica(string anotacao)
        {
            return By.XPath($"//td[@class='bugnote-note-private' and contains(text(),'{anotacao}')]/parent::tr/td/div[@class='small']/form[3]/input[@value='Tornar Público']");
        }


        public void tornarAAnotacaoPublica(string anotacao)
        {
            Click(btnTonarUmaAnotacaoPublica(anotacao));

        }

        #endregion


        #endregion

    }

}

