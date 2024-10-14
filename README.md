# Gerenciamento Financeiro API

**Gerenciamento Financeiro API** é o back-end de um sistema de **Gerenciamento Financeiro Pessoal**. A API foi desenvolvida em **ASP.NET Core** com **C#** e fornece serviços para gerenciar receitas e despesas pessoais, gerar relatórios e gráficos, além de garantir a segurança dos dados financeiros dos usuários.

## Tecnologias Utilizadas

- **ASP.NET Core 8**: Framework principal, garantindo robustez e alto desempenho.
- **C#**: Linguagem de programação utilizada no projeto, ideal para criar aplicações escaláveis e seguras.
- **Entity Framework Core**: ORM utilizado para interação com o banco de dados, facilitando a manipulação de dados de forma eficiente.
- **PostgreSQL**: Banco de dados utilizado para armazenar as informações financeiras, garantindo persistência e segurança dos dados dos usuários.

## Funcionalidades da API

A API oferece os seguintes recursos:

### Autenticação

- **Registro de usuário** (`POST /api/Auth/register`): Permite o cadastro de novos usuários.
- **Login de usuário** (`POST /api/Auth/login`): Realiza a autenticação dos usuários.

### Despesas

- **Listar todas as despesas** (`GET /api/Despesas`): Retorna todas as despesas cadastradas.
- **Cadastrar uma nova despesa** (`POST /api/Despesas`): Adiciona uma nova despesa.
- **Obter detalhes de uma despesa específica** (`GET /api/Despesas/{id}`): Retorna detalhes de uma despesa.
- **Atualizar uma despesa** (`PUT /api/Despesas/{id}`): Atualiza os dados de uma despesa existente.
- **Excluir uma despesa** (`DELETE /api/Despesas/{id}`): Remove uma despesa.

### Receitas

- **Listar todas as receitas** (`GET /api/Receitas`): Retorna todas as receitas cadastradas.
- **Cadastrar uma nova receita** (`POST /api/Receitas`): Adiciona uma nova receita.
- **Obter detalhes de uma receita específica** (`GET /api/Receitas/{id}`): Retorna detalhes de uma receita.
- **Atualizar uma receita** (`PUT /api/Receitas/{id}`): Atualiza os dados de uma receita existente.
- **Excluir uma receita** (`DELETE /api/Receitas/{id}`): Remove uma receita.

### Gráficos

- **Despesas mensais** (`GET /api/Grafico/despesas-mensais`): Gera um gráfico das despesas mensais.
- **Receitas mensais** (`GET /api/Grafico/receitas-mensais`): Gera um gráfico das receitas mensais.
- **Resumo mensal** (`GET /api/Grafico/resumo-mensal`): Exibe um gráfico comparativo de receitas e despesas mensais.

### Relatórios

- **Relatório de despesas por período** (`GET /api/RelatorioDespesas/periodo`): Gera um relatório de despesas para um período específico.
- **Relatório de receitas por período** (`GET /api/RelatorioReceitas/periodo`): Gera um relatório de receitas para um período específico.

## Como Executar o Projeto

### Requisitos

- **.NET 8 SDK**: Para compilar e executar a aplicação. Baixe no [site oficial](https://dotnet.microsoft.com/download).
- **PostgreSQL**: Para armazenar as informações financeiras.
- **Visual Studio** ou **VS Code**: Para editar e executar o código.

### Passos para Configuração

 **Clonar o Repositório**

   No terminal, execute:

   ```bash
   git clone https://github.com/thamidorville/sistemafinanceirobackend.git
   cd GerenciamentoFinanceiroAPI

** configurar string de conexão:
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=FinanceiroDB;Username=seu_usuario;Password=sua_senha"
}

** Configurar o Arquivo .env.local no ``` Frontend (https://github.com/thamidorville/sistemafinanceirofrontend)
Ao clonar o projeto frontend, o arquivo .env.local não será baixado porque está incluído no .gitignore. Portanto, crie um arquivo .env.local na raiz do seu projeto frontend e adicione a seguinte linha:
`` NEXT_PUBLIC_API_URL=http://localhost:5057

** Configurar a Porta do Swagger na API
No projeto backend, ajuste a porta do Swagger no arquivo launchSettings.json. O Swagger não roda junto com o dotnet run no Visual Studio, então ajuste o launchSettings.json para a seguinte configuração:

`` "launchUrl": "swagger",
"applicationUrl": "http://localhost:5058"

** aplicar as migrações para criar as tabelas no banco de dados:
`` dotnet ef migrations add InitialCreate
`` dotnet ef database update
`` dotnet ef database update

** rodar a API
dotnet run

A aplicação estará disponível em:

https://localhost:7173 (HTTPS)
http://localhost:5057 (HTTP)

** Documentação da API via Swagger:
acesse: https://localhost:7173/swagger/index.html
Isso permitirá que você visualize e teste os endpoints da API diretamente no Swagger e  também permitirá que o frontend funcione corretamente.

Descrição das Pastas

Controllers: Contém os controladores responsáveis por processar as requisições HTTP e conectar os serviços aos modelos.
Models: Contém as classes que representam as entidades do sistema.
DTOs: Objetos de Transferência de Dados, garantindo segurança e eficiência nas comunicações entre as camadas.
Migrations: Migrações do Entity Framework Core, responsáveis por versionar o banco de dados.
Services: Lógica de negócios dos relatórios de receitas, despesas e geração de gráficos.

Boas Práticas e Padrões Utilizados

SOLID: Princípios aplicados para garantir modularidade, reutilização e manutenção do código.
Injeção de Dependência: Para tornar os serviços testáveis e configuráveis com facilidade.
Segurança: Implementação de JWT para autenticação, garantindo que apenas usuários autorizados tenham acesso.
Validação de Dados: Utilização de anotações de validação para garantir que os dados inseridos estejam consistentes.



