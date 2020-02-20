using CSharpSeleniumLarissaBicalho.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSeleniumLarissaBicalho.Pages
{
    public class GerenciarTodososProjetosPage : PageBase

   {
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

        #region AdicionarCategoria

        public void clicarEmGerenciarProjetos()
        {
            Click(linkGerenciar);
        }

        public void preencherNomeCategoria(string nome)
        {
            SendKeys(adicionarNomeCategoria, nome);
        }

        public void clicarEmAdicionarCategoria()
        {
            Click(btnAdicionar);
        }

        public void adicionarCategoria(string categoria)
        {
            clicarEmGerenciarProjetos();
            preencherNomeCategoria(categoria);
            clicarEmAdicionarCategoria();


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

        public void limparNomeCategoria()
        {
            driver.FindElement(adicionarNomeCategoria).Clear();
        }

        public void atribuirAUmaPessoa(string pessoa)
        {
            ComboBoxSelectByVisibleText(atribuirCategoria, pessoa);
        }

        public void clicarEmAtualizarCategoria()
        {
            Click(btnEditarCategoria);
        }

        public void clicarEmProsseguirEdicao()
        {
            Click(lnkProseguir);
        }

        public void editarCategoria(string nomeCategoria, string pessoa)
        {
            limparNomeCategoria();
            preencherNomeCategoria(nomeCategoria);
            atribuirAUmaPessoa(pessoa);
            clicarEmAtualizarCategoria();
            clicarEmProsseguirEdicao();


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

        public void clicarEmApagarCategoria()
        {
            Click(btnApagarCategoria);
        }

        public void deletarCategoria()
        { 
            clicarEmApagarCategoria();
            clicarEmProsseguirEdicao();

        }

        #endregion

        #region Procurar

        private By procurarCategoria(string categoria)
        {
            return By.XPath($"//td[contains(text(), '{categoria}')]");
        }

        public bool acharCategoriaSelecionada(string categoria)
        {
            try
            {

                driver.FindElement(procurarCategoria(categoria));
                return true;

            }
            catch (Exception e)
            {

                return false;
            }

        }


        #endregion


    }
    
}
