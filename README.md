# Desafio de Automação - Mantis
Automação Desenvolvida em C#. O sistema automatizado foi o Mantis Bug Tracker.

# Desafio Base2
- Preparação do Ambiente

- 50 Casos de teste 

- Data Driven

- SeleniumGrid

- Azure DevOps

# Ferramentas

- Visual Studio Professional 2019 
- ChromeDriver
- FirefoxDriver 
- OperaDriver
- Selenium Server


# Classes Criadas

| Classe | Função |
| ------ | ------ |
| Tests | Classe que herda valores da TestBase e onde são feitos os testes|
| PageObjects | Classe que herda da PageBase responsável pelo mapeamento dos elementos da tela e seus métodos|
| DataDriven | Classe responsável por implementar o DataDriven |
| Flows | Agrupa fluxos comuns aos testes |
| DriverFactory | Responsável por qual navegador sera realizado a automação e Selenium Grid |
| PageBase | Responsável pela por conter funções relacionadas às ações da página (Click, Enviar Dados...) |


# Configuração Selenium Grid
Configuração Selenium Grid
O Selenium-Grid permite que você execute seus testes em diferentes máquinas em diferentes navegadores em paralelo. Ou seja, executando vários testes ao mesmo tempo em diferentes máquinas executando diferentes navegadores e sistemas operacionais.

Baixar o arquivo do selenium server

https://www.seleniumhq.org/download/
Colocar o Jar em C: e abrir o CMD na pasta (Shift+Botão Direito)

Executar o comando via CMD

 java -jar seleniumserver.jar -role hub
Caso a porta esteja ocupada use:

 java -jar seleniumserver.jar -port 4445 -role hub
Acessar o servidor via navegador e verificar se o HUB está conectado

Link http://localhost:4444/grid/console
Cadastro de nó
java -jar seleniumserver.jar -role webdriver -hub https://IPHUB:PORTA/grid/register
Configurando o Selenium GRID - HUB com arquivo JSON (O arquivo deve estar na pasta que irá executar o comando)

java -jar "seleniumserver.jar" -port 4444 -role hub -hubConfig HubConfig.json
Conteúdo Arquivo HUBConfig.JSON

{
	  "port": 4444,
	  
	  "newSessionWaitTimeout": -1,
	  
	  "servlets" : [],
	  
	  "withoutServlets": [],
	  "custom": {},
	  "capabilityMatcher": "org.openqa.grid.internal.utils.DefaultCapabilityMatcher",
	  "registryClass": "org.openqa.grid.internal.DefaultGridRegistry",
	  "throwOnCapabilityNotPresent": true,
	  "cleanUpCycle": 5000,
	  "role": "hub",
	  "debug": false,
	  "browserTimeout": 0,
	  "timeout": 1800
}
Configurando o Selenium GRID - Nó com arquivo JSON (O arquivo deve estar na pasta que irá executar o comando)

java -Dwebdriver.chrome.driver="chromedriver.exe" -Dwebdriver.ie.driver="IEDriverServer.exe" -Dwebdriver.opera.driver="operadriver.exe" -Dwebdriver.gecko.driver="geckodriver.exe" -jar seleniumserver.jar -role node -nodeConfig NodeDefaultConfig.json 
Conteúdo Arquivo NodeDeafultConfig.JSON (JUNIT 3 acima)

{
  "capabilities":
  [
    {
      "browserName": "firefox",
      "marionette": true,
      "maxInstances": 5,
      "seleniumProtocol": "WebDriver"
    },
     {
      "browserName": "internet explorer",
      "marionette": true,
      "maxInstances": 5,
      "seleniumProtocol": "WebDriver"
    },
    {
      "browserName": "chrome",
      "maxInstances": 5,
      "seleniumProtocol": "WebDriver"
    }
  ],
  "proxy": "org.openqa.grid.selenium.proxy.DefaultRemoteProxy",
  "maxSession": 5,
  "port": -1,
  "register": true,
  "registerCycle": 5000,
  "hub": "http://localhost:4444",
  "nodeStatusCheckTimeout": 5000,
  "nodePolling": 5000,
  "role": "node",
  "unregisterIfStillDownAfter": 60000,
  "downPollingLimit": 2,
  "debug": false,
  "servlets" : [],
  "withoutServlets": [],
  "custom": {},
  "browserTimeout": 0,
  "timeout": 1800
}
É altamente sugerido a criação de .bat para inicialização do Nó e do HUB.

CONTEUDO_NO.BAT

cd C:\chromedriver 
java -Dwebdriver.chrome.driver="chromedriver.exe" -Dwebdriver.ie.driver="IEDriverServer.exe" -Dwebdriver.opera.driver="operadriver.exe" -Dwebdriver.gecko.driver="geckodriver.exe" -jar seleniumserver.jar -role node -nodeConfig NodeDefaultConfig.json 
CONTEUDO_HUB.BAT

cd C:\chromedriver 
java -jar seleniumserver.jar -role hub -hubConfig HubConfig.json

- AppSettings.Json e necessário colocar o endereço do hub e mudar a opção de local para remota 
  "EXECUTION": "local", // remota
  "DEFAULT_TIMEOUT_IN_SECONDS": "30",
  "HEADLESS": "false",
  "SELENIUM_HUB": "http://192.168.1.76:4444/wd/hub", //endereco do hub


# Configuração Azure DevOps
- E necessário associar a um projeto do Git
- Criar Uma Task com um agente Job do DotNetCore
- Usar os Passos Restore,Build, Test e caso queria publicar o Relatório publishRelatórioExtendsReport
- No Restore : Colocar a solucao do projeto
- No Build: Colocar o .csproj
- No Test: pasta onde contém as dlls do projeto
- No Publish Report: Pasta onde contem os relatorios publicados


