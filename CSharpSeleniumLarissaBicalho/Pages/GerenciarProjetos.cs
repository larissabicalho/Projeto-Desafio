using CSharpSeleniumLarissaBicalho.Bases;
using OpenQA.Selenium;


namespace CSharpSeleniumLarissaBicalho.Pages
{
    //lembrando que esse tem o projeto como LarissaBicalhoProject's
    public class GerenciarProjetos : PageBase
    {
        #region Mapping

        #region Click em Botoes
        By txtGerencia = By.ClassName("form-title");
        By linkGerenciarPerfisGlobais = By.LinkText("Gerenciar Perfís Globais");
        By linkGerenciarMarcadores = By.LinkText("Gerenciar Marcadores");

        #endregion

        #region Adicionar Marcador

        By btnAtualizarMarcador = By.XPath("//input[@value='Atualizar Marcador']");
        By btnCriarMarcador = By.XPath("//input[@value='Criar Marcador']");
        By btnApagarMarcador = By.XPath("//input[@value='Apagar Marcador']");
        By nomeMarcador = By.Name("name");
        By descricaoMarcador = By.Name("description");
        By linkAlterarUsuarioAtribuido = By.Id("user_id_edit");
        By opcoesDeUsuarioCombobox = By.Name("user_id");
        By telaDetalhesMarcador = By.XPath("//td[@class='form-title']");


        #endregion

        #region Perfis Globais

        By plataforma = By.Name("platform");
        By so = By.Name("os");
        By versaoSO = By.Name("os_build");
        By descricaoAdicional = By.Name("description");
        By btnAdicionarPerfil = By.XPath("//input[@value='Adicionar Perfil']");
        By rdeditarPerfil = By.XPath("//input[@value='edit']");
        By rdapagarPerfil = By.XPath("//input[@value='delete']");
        By btnEnviarPerfilASerEditado = By.XPath("//input[@value='Enviar']");
        By btnEditarPerfil = By.XPath("//input[@value='Atualizar Perfil']");
        By erroMensagem = By.XPath("/html/body/div[2]/table/tbody/tr[2]/td/p");
        By comboSelecionavel = By.Name("profile_id");
        
        #endregion

        #region Projeto
        By selecionarProjeto = By.Name("project_id");
        By btnMudarProjeto = By.XPath("//input[@value='Mudar']");

        #endregion

        #endregion

        #region Action

        #region  Gerenciar
        public string VerificarTelaGerenciar()
        {
            return GetText(txtGerencia);
        }

        public void entrarNoLinkdeGerenciarMarcadores()
        {
            Click(linkGerenciarMarcadores);
        }

        #endregion

        #region Marcadores

        public void preencherNomeMarcador(string nome)
        {
            SendKeys(nomeMarcador, nome);
        }

        public void preencherDescricaoMarcador(string descricao)
        {
            SendKeys(descricaoMarcador, descricao);
        }

        public void clicarEmCriarMarcador()
        {
            Click(btnCriarMarcador);
        }

        public string criarMarcador(string nome, string descricao)
        {
            preencherNomeMarcador(nome);
            preencherDescricaoMarcador(descricao);
            clicarEmCriarMarcador();
            return nome;
        }

        private By CreateMarcador(string nome)
        {
            return By.LinkText(nome);
        }

        public bool retornaSeOMarcadorFoiCriado(string nome)
        {
            return ReturnIfElementIsDisplayed(CreateMarcador(nome));
        }

        public By marcadorASerSelecionado(string nomeMarcador)
        {
            return By.LinkText(nomeMarcador);
        }

        public void selecionarMarcadorCriado( string nomeMarcador)
        {
            Click(marcadorASerSelecionado(nomeMarcador));
        }

        public void clicarNoBotaoAtualizarMarcador()
        {
            Click(btnAtualizarMarcador);
        }

       
        public void EditarUsuarioAtribuido(string atribuir)
        {
            Click(linkAlterarUsuarioAtribuido);
            ComboBoxSelectByVisibleText(opcoesDeUsuarioCombobox, atribuir);
        }

        public void EditarDescricao(string descricao)
        {
            SendKeys(descricaoMarcador, descricao);
        }

        public void clicarEmAtualizarMarcador()
        {
            Click(btnAtualizarMarcador);
        }

        public void atualizarMarcador(string nomeMarcador, string atribuir, string descricao)
        {
            selecionarMarcadorCriado(nomeMarcador);
            clicarNoBotaoAtualizarMarcador();
            EditarUsuarioAtribuido(atribuir);
            limparDado(descricaoAdicional);
            EditarDescricao(descricao);
            clicarEmAtualizarMarcador();
        }

        public string verificarSeAtualizouMarcador(string nomeMarcador)
        {
            return GetText(telaDetalhesMarcador);

        }

        public void clicarEmApagarMarcador()
        {
            Click(btnApagarMarcador);
            Click(btnApagarMarcador);
        }

        public void apagarMarcador(string nomeMarcador)
        {
            selecionarMarcadorCriado(nomeMarcador);
            clicarEmApagarMarcador();

        }

        public By pesquisarMarcador(string marcador)
        {
            return By.XPath("//table[@class='width100' and @cellspacing='1']/tbody/tr[starts-with(@class,'row-')]/td[1]/a");
        }

        public bool pesquisarMarcadorNaLista(string marcador)
        {
            var table = driver.FindElements(pesquisarMarcador(marcador));
            //   var rows = table.FindElements(By.CssSelector("tr"));

            foreach (var row in table)
            {
                if (row.Text.Contains(marcador))
                    return true;

            }

            return false;

        }

        #endregion

        #region PerfilGlobal

        public void clicarEmGerenciarPerfisGlobais()
        {
            Click(linkGerenciarPerfisGlobais);
        }

        public void preencherPlataforma(string plataformaName)
        {
            SendKeys(plataforma, plataformaName );
        }
        public void preencherSO(string SOName)
        {
            SendKeys(so, SOName);
        }

        public void preencherVersaoSO(string versaoSoName)
        {
            SendKeys(versaoSO, versaoSoName);
        }

        public void preencherDescricaoAdicional(string descricaoName)
        {
            SendKeys(descricaoAdicional, descricaoName);
        }

        public void clicarEmAdicionarPerfil()
        {
            Click(btnAdicionarPerfil);
        }

        public string adicionarUmPerfilGlobal(string plataforma, string so, string versaoSO, string descricao)
        { 
            preencherPlataforma(plataforma);
            preencherSO(so);
            preencherVersaoSO(versaoSO);
            preencherDescricaoAdicional(descricao);
            clicarEmAdicionarPerfil();

            return plataforma + so + versaoSO;

        }

        public bool verificarSeUmPerfilFoiCriado(string nomePerfil)
        { 
            return ReturnSelectByVisibleText(comboSelecionavel, nomePerfil);

        }

        public string verificarMensagemdeErro()
        {
            return GetText(erroMensagem);
        }

        public void clicarEmEditarPerfil()
        {
            Click(rdeditarPerfil);
        }

        public void selecionarPerfilASerEditado(string perfil)
        {
            ComboBoxSelectByVisibleText(comboSelecionavel, perfil);
        }

        public void clicarEmEnviarPerfil()
        {
            Click(btnEnviarPerfilASerEditado);
        }

        public void limparDado(By dado)
        {
            driver.FindElement(dado).Clear();
        }

        public void clicarEmAtualizarPerfil()
        {
            Click(btnEditarPerfil);
        }
        public void editarPerfil(string perfil, string plataformaNome)
        {
            clicarEmEditarPerfil();
            selecionarPerfilASerEditado(perfil);
            clicarEmEnviarPerfil();
            limparDado(plataforma);
            preencherPlataforma(plataformaNome);
            clicarEmAtualizarPerfil();
           
        }

        public void clicarEmDeletarPerfil()
        {
            Click(rdapagarPerfil);
        }

        public void selecionarPlataformaASerApagada(string plataformaSelecionada)
        {
            ComboBoxSelectByVisibleText(comboSelecionavel, plataformaSelecionada);
        }

        public void clicarEmEnviarPlataformaaSerApagada()
        {
            Click(btnEnviarPerfilASerEditado);
        }

        public void apagarPefil(string plataforma)
        {
            clicarEmDeletarPerfil();
            selecionarPlataformaASerApagada(plataforma);
            clicarEmEnviarPerfil();

        }


        #endregion

        #region TrocarProjeto

        public void clicarEmMudarProjeto()
        {
            Click(btnMudarProjeto);
        }

        public void escolherNomeProjeto(string escolherNomeProjeto)
        {
            ComboBoxSelectByVisibleText(selecionarProjeto, escolherNomeProjeto);
            clicarEmMudarProjeto();
        
        }

        #endregion

        #endregion

    }
}
