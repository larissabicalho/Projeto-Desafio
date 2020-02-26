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

        public void EntrarNoLinkdeGerenciarMarcadores()
        {
            Click(linkGerenciarMarcadores);
        }

        #endregion

        #region Marcadores

        public void PreencherNomeMarcador(string nome)
        {
            SendKeys(nomeMarcador, nome);
        }

        public void PreencherDescricaoMarcador(string descricao)
        {
            SendKeys(descricaoMarcador, descricao);
        }

        public void ClicarEmCriarMarcador()
        {
            Click(btnCriarMarcador);
        }

        public string CriarMarcador(string nome, string descricao)
        {
            PreencherNomeMarcador(nome);
            PreencherDescricaoMarcador(descricao);
            ClicarEmCriarMarcador();
            return nome;
        }

        private By CreateMarcador(string nome)
        {
            return By.LinkText(nome);
        }

        public bool RetornaSeOMarcadorFoiCriado(string nome)
        {
            return ReturnIfElementIsDisplayed(CreateMarcador(nome));
        }

        public By MarcadorASerSelecionado(string nomeMarcador)
        {
            return By.LinkText(nomeMarcador);
        }

        public void SelecionarMarcadorCriado(string nomeMarcador)
        {
            Click(MarcadorASerSelecionado(nomeMarcador));
        }

        public void ClicarNoBotaoAtualizarMarcador()
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

        public void ClicarEmAtualizarMarcador()
        {
            Click(btnAtualizarMarcador);
        }

        public void AtualizarMarcador(string nomeMarcador, string atribuir, string descricao)
        {
            SelecionarMarcadorCriado(nomeMarcador);
            ClicarNoBotaoAtualizarMarcador();
            EditarUsuarioAtribuido(atribuir);
            LimparDado(descricaoAdicional);
            EditarDescricao(descricao);
            ClicarEmAtualizarMarcador();
        }

        public string VerificarSeAtualizouMarcador(string nomeMarcador)
        {
            return GetText(telaDetalhesMarcador);

        }

        public void ClicarEmApagarMarcador()
        {
            Click(btnApagarMarcador);
            Click(btnApagarMarcador);
        }

        public void ApagarMarcador(string nomeMarcador)
        {
            SelecionarMarcadorCriado(nomeMarcador);
            ClicarEmApagarMarcador();

        }

        public By PesquisarMarcador(string marcador)
        {
            return By.XPath("//table[@class='width100' and @cellspacing='1']/tbody/tr[starts-with(@class,'row-')]/td[1]/a");
        }

        public bool PesquisarMarcadorNaLista(string marcador)
        {
            var table = driver.FindElements(PesquisarMarcador(marcador));
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

        public void ClicarEmGerenciarPerfisGlobais()
        {
            Click(linkGerenciarPerfisGlobais);
        }

        public void PreencherPlataforma(string plataformaName)
        {
            SendKeys(plataforma, plataformaName);
        }
        public void PreencherSO(string SOName)
        {
            SendKeys(so, SOName);
        }

        public void PreencherVersaoSO(string versaoSoName)
        {
            SendKeys(versaoSO, versaoSoName);
        }

        public void PreencherDescricaoAdicional(string descricaoName)
        {
            SendKeys(descricaoAdicional, descricaoName);
        }

        public void ClicarEmAdicionarPerfil()
        {
            Click(btnAdicionarPerfil);
        }

        public string AdicionarUmPerfilGlobal(string plataforma, string so, string versaoSO, string descricao)
        {
            PreencherPlataforma(plataforma);
            PreencherSO(so);
            PreencherVersaoSO(versaoSO);
            PreencherDescricaoAdicional(descricao);
            ClicarEmAdicionarPerfil();

            return plataforma + so + versaoSO;

        }

        public bool VerificarSeUmPerfilFoiCriado(string nomePerfil)
        {
            return ReturnSelectByVisibleText(comboSelecionavel, nomePerfil);

        }

        public string VerificarMensagemdeErro()
        {
            return GetText(erroMensagem);
        }

        public void ClicarEmEditarPerfil()
        {
            Click(rdeditarPerfil);
        }

        public void SelecionarPerfilASerEditado(string perfil)
        {
            ComboBoxSelectByVisibleText(comboSelecionavel, perfil);
        }

        public void ClicarEmEnviarPerfil()
        {
            Click(btnEnviarPerfilASerEditado);
        }

        public void LimparDado(By dado)
        {
            driver.FindElement(dado).Clear();
        }

        public void ClicarEmAtualizarPerfil()
        {
            Click(btnEditarPerfil);
        }
        public void EditarPerfil(string perfil, string plataformaNome)
        {
            ClicarEmEditarPerfil();
            SelecionarPerfilASerEditado(perfil);
            ClicarEmEnviarPerfil();
            LimparDado(plataforma);
            PreencherPlataforma(plataformaNome);
            ClicarEmAtualizarPerfil();

        }

        public void ClicarEmDeletarPerfil()
        {
            Click(rdapagarPerfil);
        }

        public void SelecionarPlataformaASerApagada(string plataformaSelecionada)
        {
            ComboBoxSelectByVisibleText(comboSelecionavel, plataformaSelecionada);
        }

        public void ClicarEmEnviarPlataformaaSerApagada()
        {
            Click(btnEnviarPerfilASerEditado);
        }

        public void ApagarPefil(string plataforma)
        {
            ClicarEmDeletarPerfil();
            SelecionarPlataformaASerApagada(plataforma);
            ClicarEmEnviarPerfil();

        }


        #endregion

        #region TrocarProjeto

        public void ClicarEmMudarProjeto()
        {
            Click(btnMudarProjeto);
        }

        public void EscolherNomeProjeto(string escolherNomeProjeto)
        {
            ComboBoxSelectByVisibleText(selecionarProjeto, escolherNomeProjeto);
            ClicarEmMudarProjeto();

        }

        #endregion

        #endregion

    }
}
