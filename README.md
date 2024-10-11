Gerenciamento Financeiro API

API back-end de um sistema de Gerenciamento Financeiro Pessoal. A API foi desenvolvida em ASP.NET Core com C# e visa fornecer serviços para gerenciar receitas e despesas pessoais, bem como gerar relatórios e gráficos, de forma segura e eficiente.

Tecnologias Utilizadas

ASP.NET Core 8: Framework principal utilizado para desenvolvimento do back-end, fornecendo robustez e alto desempenho.

C#: Linguagem de programação utilizada no projeto, ideal para criar aplicações escaláveis e seguras.

Entity Framework Core: ORM utilizado para facilitar a interação com o banco de dados, permitindo manipulação de dados de forma eficiente e fluida.

PostgreSQL: Banco de dados utilizado para armazenar as informações financeiras, garantindo persistência e segurança dos dados dos usuários.

Funcionalidades da API

A API oferece os seguintes recursos:

Autenticação

Registro de usuário (POST /api/Auth/register): Permite o cadastro de novos usuários no sistema, fornecendo informações como nome, email e senha.

Login de usuário (POST /api/Auth/login): Permite que usuários cadastrados façam login para acessar as funcionalidades do sistema.

Despesas

Listar todas as despesas (GET /api/Despesas): Retorna uma lista de todas as despesas cadastradas pelo usuário.

Cadastrar uma nova despesa (POST /api/Despesas): Permite o cadastro de uma nova despesa no sistema.

Obter detalhes de uma despesa específica (GET /api/Despesas/{id}): Retorna informações detalhadas sobre uma despesa específica.

Atualizar uma despesa (PUT /api/Despesas/{id}): Atualiza os detalhes de uma despesa existente.

Excluir uma despesa (DELETE /api/Despesas/{id}): Remove uma despesa do sistema.

Receitas

Listar todas as receitas (GET /api/Receitas): Retorna uma lista de todas as receitas cadastradas pelo usuário.

Cadastrar uma nova receita (POST /api/Receitas): Permite o cadastro de uma nova receita no sistema.

Obter detalhes de uma receita específica (GET /api/Receitas/{id}): Retorna informações detalhadas sobre uma receita específica.

Atualizar uma receita (PUT /api/Receitas/{id}): Atualiza os detalhes de uma receita existente.

Excluir uma receita (DELETE /api/Receitas/{id}): Remove uma receita do sistema.

Gráficos

Despesas mensais (GET /api/Grafico/despesas-mensais): Gera um gráfico com as despesas mensais do usuário, facilitando a visualização dos gastos ao longo do tempo.

Receitas mensais (GET /api/Grafico/receitas-mensais): Gera um gráfico com as receitas mensais do usuário, proporcionando uma visão clara da evolução das receitas.

Resumo mensal (GET /api/Grafico/resumo-mensal): Gera um resumo gráfico das receitas e despesas do mês, permitindo uma análise rápida e precisa da saúde financeira.

Relatórios

Relatório de despesas por período (GET /api/RelatorioDespesas/periodo): Gera um relatório das despesas do usuário dentro de um período específico.

Relatório de receitas por período (GET /api/RelatorioReceitas/periodo): Gera um relatório das receitas do usuário dentro de um período específico.

Como Executar o Projeto

Requisitos

.NET 8 SDK: Para compilar e executar a aplicação.

PostgreSQL: Banco de dados para armazenamento das informações financeiras.

Visual Studio ou VS Code: IDE para editar e executar o código.

Configuração

Clonar o Repositório

git clone https://github.com/thamidorville/sistemafinanceirobackend.git
cd GerenciamentoFinanceiroAPI

Configurar a String de Conexão

Atualize o arquivo appsettings.json com as credenciais do seu banco de dados PostgreSQL:

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=FinanceiroDB;Username=seu_usuario;Password=sua_senha"
}

Aplicar as Migrações

Execute o comando a seguir para aplicar as migrações do banco de dados:

dotnet ef database update

Executar a API

Utilize o comando a seguir para rodar a aplicação localmente:

dotnet run

A aplicação estará disponível em https://localhost:7173 ou http://localhost:5057.

Documentação da API

A documentação da API está disponível através do Swagger. Para acessá-la, inicie o projeto e navegue para:

https://localhost:7173/swagger/index.html

O Swagger facilita a exploração dos endpoints da API, permitindo testar todas as funcionalidades diretamente pela interface gráfica.

Estrutura do Projeto

Controllers: Contém os controladores responsáveis por gerenciar as requisições HTTP e conectar os serviços aos modelos.

Models: Classes que representam as entidades do sistema e encapsulam as regras de negócio.

DTOs: Objetos de Transferência de Dados utilizados para comunicação entre as camadas de forma segura e eficiente.

Migrations: Contém as migrações para o banco de dados, facilitando o versionamento e a criação das tabelas.

Services: Camada responsável pela lógica de negócios dos relatórios de receitas, despesas e dos gráficos.

Boas Práticas e Padrões Utilizados

SOLID: Aplicação dos princípios SOLID para garantir um código mais modular, reutilizável e fácil de manter.

Injeção de Dependência: Para garantir que os serviços sejam facilmente testáveis e configuráveis.

Segurança: Implementação de autenticação JWT para proteger as rotas e assegurar que apenas usuários autorizados possam acessar as informações financeiras.

Validação de Dados: Uso de anotações de validação para garantir que apenas dados consistentes sejam processados pela aplicação.

