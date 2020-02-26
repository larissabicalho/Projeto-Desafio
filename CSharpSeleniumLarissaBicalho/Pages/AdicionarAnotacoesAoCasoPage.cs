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

        public void ClicarEmAdicionarAnotacao()
        {
            Click(btnAdicionarAnotacao);
        }

        public string InsererAnotacaoAoCaso(string anotacao)
        {
            SendKeys(digitarAAnotacao, anotacao);
            ClicarEmAdicionarAnotacao();

            return anotacao;

        }

        public By PageVerificarSeAAnotacaoFoiInserida(string anotacao)
        {
            //testee
            return By.XPath($"//td[@class='bugnote-note-public' and contains(text(),'{anotacao}')]");

        }

        public string VerificarSeAAnotaçãoFoiInserida(string anotacao)
        {
            return GetText(PageVerificarSeAAnotacaoFoiInserida(anotacao));
        }


        #endregion

        #region Alterar Anotacao 

        public By BtnAlterarAnotacao(string anotacao)
        {
            //teste

            return By.XPath($"//td[@class='bugnote-note-public' and contains(text(),'{anotacao}')]/parent::tr/td/div[@class='small']/form[1]");
        }


        public void ClicarEmAlterarAnotação(string anotacao)
        {
            Click(BtnAlterarAnotacao(anotacao));
        }

        public void LimparDado()
        {
            driver.FindElement(textoASerAlterado).Clear();
        }

        public void PreencherAnotacaoEditada(string anotacao)
        {
            SendKeys(textoASerAlterado, anotacao);
        }

        public void ClicarNoBotaoDeAtualizarAnotacao()
        {
            Click(btnAtualizarInformacao);
        }


        public void AlterarAnotacao(string anotacao, string anotacaoEditada)
        {
            ClicarEmAlterarAnotação(anotacao);
            LimparDado();
            PreencherAnotacaoEditada(anotacaoEditada);
            ClicarNoBotaoDeAtualizarAnotacao();

        }

        public void ClicarEmVoltar()
        {
            Click(lnkVoltar);
        }

        public void entraremAlterarAnotacaoSemAlterar(string anotacao)
        {
            ClicarEmAlterarAnotação(anotacao);
            ClicarEmVoltar();
        }

        #endregion


        #region Apagar Anotacao

        public By BtnApagarUmaAnotacao(string anotacao)
        {
            return By.XPath($"//td[@class='bugnote-note-public' and contains(text(),'{anotacao}')]/parent::tr/td/div[@class='small']/form[2]");
        }

        public void ClicarEmApagarAnotacao(string anotacao)
        {
            Click(BtnApagarUmaAnotacao(anotacao));
        }

        public void ClicarEmConfirmarAExclusaoDaAnotacao()
        {
            Click(btnapagarAnotacao);
        }

        public void ApagarAnotacao(string anotacao)
        {
            ClicarEmApagarAnotacao(anotacao);
            ClicarEmConfirmarAExclusaoDaAnotacao();
        }

        public bool ConfirmarSeAAnotaçãoFoiApagada(string anotacao)
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

        public By VerificarOTextoAnotacaoPrivada(string anotacao)
        {
            return By.XPath($"//td[@class='bugnote-note-private' and contains(text(),'{anotacao}')]/parent::tr/td/span[contains(text(),'[ privado ]')]");
        }


        public bool VerificarSeAAnotacaoEstaPrivada(string anotacao)
        {
            try
            {
                ReturnIfElementIsEnabled(VerificarOTextoAnotacaoPrivada(anotacao));
                return true;
            }
            catch (WebDriverException e)
            {
                return false;
            }
        }

        public By BtnTornarUmaAnotacaoPrivada(string anotacao)
        {
            return By.XPath($"//td[@class='bugnote-note-public' and contains(text(),'{anotacao}')]/parent::tr/td/div[@class='small']/form[3]/input[@value='Tornar Privado']");
        }


        public void TornarAAnotacaoPrivada(string anotacao)
        {
            Click(BtnTornarUmaAnotacaoPrivada(anotacao));

        }

        #endregion

        #region Privada

        public bool VerificarSeAAnotacaoEstaPublica(string anotacao)
        {
            try
            {
                WaitForElement(BtnTornarUmaAnotacaoPrivada(anotacao));
                ReturnIfElementIsEnabled(BtnTornarUmaAnotacaoPrivada(anotacao));
                return true;
            }
            catch (WebDriverException e)
            {
                return false;
            }
        }

        #endregion

        #region Publica

        public By BtnTonarUmaAnotacaoPublica(string anotacao)
        {
            return By.XPath($"//td[@class='bugnote-note-private' and contains(text(),'{anotacao}')]/parent::tr/td/div[@class='small']/form[3]/input[@value='Tornar Público']");
        }


        public void TornarAAnotacaoPublica(string anotacao)
        {
            Click(BtnTonarUmaAnotacaoPublica(anotacao));

        }

        #endregion

        #endregion

    }

}

