using CSharpSeleniumLarissaBicalho.Bases;
using OpenQA.Selenium;
using System;


namespace CSharpSeleniumLarissaBicalho.Pages
{
    public class GerenciarTodososProjetosPage : PageBase

    {
        #region Mapping

        #region Gerencia

        By linkGerenciar = By.LinkText("Gerenciar Projetos");

        #endregion

        #region Adicionar

        By adicionarNomeCategoria = By.Name("name");
        By btnAdicionar = By.XPath("//input[@value='Adicionar Categoria']");

        #endregion

        #region  Editar

        By atribuirCategoria = By.Name("assigned_to");
        By btnEditarCategoria = By.XPath("//input[@value='Atualizar Categoria']");

        #endregion

        #region Proseguir

        By lnkProseguir = By.LinkText("Clique aqui para prosseguir");

        #endregion

        #region Apagar

        By btnApagarCategoria = By.XPath("//input[@value='Apagar Categoria']");

        #endregion

        #endregion

        #region Action

        #region AdicionarCategoria

        public void ClicarEmGerenciarProjetos()
        {
            Click(linkGerenciar);
        }

        public void PreencherNomeCategoria(string nome)
        {
            SendKeys(adicionarNomeCategoria, nome);
        }

        public void ClicarEmAdicionarCategoria()
        {
            Click(btnAdicionar);
        }

        public string AdicionarCategoria(string categoria)
        {
            ClicarEmGerenciarProjetos();
            PreencherNomeCategoria(categoria);
            ClicarEmAdicionarCategoria();
            return categoria;
        }

        #endregion

        #region Alterar Categoria

        private By AlterarButton(string categoria)
        {
            return By.XPath($"//td[contains(text(), '{categoria}')]/parent::tr//input[@value='Alterar']");
        }

        public void ClicarEmAlterarCategoria(string categoria)
        {
            Click(AlterarButton(categoria));
        }

        public void LimparNomeCategoria()
        {
            driver.FindElement(adicionarNomeCategoria).Clear();
        }

        public void AtribuirAUmaPessoa(string pessoa)
        {
            ComboBoxSelectByVisibleText(atribuirCategoria, pessoa);
        }

        public void ClicarEmAtualizarCategoria()
        {
            Click(btnEditarCategoria);
        }

        public void ClicarEmProsseguirEdicao()
        {
            Click(lnkProseguir);
        }

        public void EditarCategoria(string nomeCategoria, string pessoa)
        {
            LimparNomeCategoria();
            PreencherNomeCategoria(nomeCategoria);
            AtribuirAUmaPessoa(pessoa);
            ClicarEmAtualizarCategoria();
            ClicarEmProsseguirEdicao();

        }

        #endregion

        #region DeletarCategoria 

        private By DeletarButton(string categoria)
        {
            return By.XPath($"//td[contains(text(), '{categoria}')]/parent::tr//input[@value='Apagar']");
        }

        public void ClicarEmDeletarCategoria(string categoria)
        {
            Click(DeletarButton(categoria));
        }

        public void ClicarEmApagarCategoria()
        {
            Click(btnApagarCategoria);
        }

        public void DeletarCategoria()
        {
            ClicarEmApagarCategoria();
            ClicarEmProsseguirEdicao();

        }

        #endregion

        #region Procurar

        private By ProcurarCategoria(string categoria)
        {
            return By.XPath($"//td[contains(text(), '{categoria}')]");
        }

        public bool AcharCategoriaSelecionada(string categoria)
        {
            try
            {

                driver.FindElement(ProcurarCategoria(categoria));
                return true;

            }
            catch (Exception e)
            {

                return false;
            }

        }


        #endregion

        #endregion

    }

}
