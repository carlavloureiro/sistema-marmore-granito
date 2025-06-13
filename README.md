# Sistema de Gerenciamento para Mármore e Granito

## 📝 Descrição do Projeto

Este projeto consiste no desenvolvimento de um sistema de gerenciamento para o ramo de mármore e granito. A aplicação visa automatizar e otimizar processos essenciais, como o cadastro de usuários, blocos de material, chapas, e a funcionalidade de transformação de blocos em chapas, além de listar os itens em estoque. O sistema foi concebido como uma aplicação do tipo Console, utilizando a linguagem C# e o framework .NET 8, com persistência de dados em um banco de dados relacional.

## ✨ Funcionalidades Implementadas

* **Login de Usuário:** Autenticação de usuários com validação no banco de dados.
* **Menu de Opções:** Navegação intuitiva para acessar as diferentes funções do sistema.
* **Cadastros:**
    * **Usuários:** Gerenciamento de credenciais de acesso ao sistema.
    * **Blocos:** Registro de blocos de mármore/granito com detalhes como código, pedreira de origem, metragem (M³), tipo de material, valor de compra e número da nota fiscal de entrada.
    * **Chapas:** Cadastro de chapas avulsas, identificando o bloco de origem, tipo de material, medidas e valor.
* **Processo de Serragem:** Funcionalidade automática para transformar um bloco em múltiplas chapas, registrando-as no estoque.
* **Listagens:** Visualização de todos os blocos e chapas cadastradas no sistema.

## 🚀 Como Configurar e Executar o Projeto

Siga os passos abaixo para configurar seu ambiente de desenvolvimento e executar o sistema.

### Pré-requisitos

Certifique-se de que os seguintes softwares estão instalados em sua máquina:

* **.NET 8 SDK:** Necessário para compilar e executar a aplicação C#.
    * Download: [https://dotnet.microsoft.com/download/dotnet/8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
* **IDE (Ambiente de Desenvolvimento Integrado):**
    * **Visual Studio Community 2022:** Recomendado para desenvolvimento .NET.
        * Download: [https://visualstudio.microsoft.com/vs/community/](https://visualstudio.microsoft.com/vs/community/)
    * **Visual Studio Code:** Uma alternativa leve, com extensões para C#.
        * Download: [https://code.visualstudio.com/](https://code.visualstudio.com/)
* **Sistema de Gerenciamento de Banco de Dados Relacional:**
    * **[Nome do SGBD Escolhido - Ex: SQL Server / PostgreSQL / MySQL]:**
        * **SQL Server Express:** (Versão gratuita para desenvolvimento)
            * Download: [https://www.microsoft.com/en-us/sql-server/sql-server-downloads](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
            * **SQL Server Management Studio (SSMS):** Ferramenta para gerenciar o SQL Server.
                * Download: [https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
        * **PostgreSQL:**
            * Download: [https://www.postgresql.org/download/](https://www.postgresql.org/download/)
            * **pgAdmin:** Ferramenta de gerenciamento para PostgreSQL.
                * Download: [https://www.pgadmin.org/download/](https://www.pgadmin.org/download/)
        * **MySQL:**
            * Download: [https://dev.mysql.com/downloads/](https://dev.mysql.com/downloads/)
            * **MySQL Workbench:** Ferramenta de gerenciamento para MySQL.
                * Download: [https://www.mysql.com/products/workbench/](https://www.mysql.com/products/workbench/)
* **Git:** Ferramenta de controle de versão (geralmente já vem com a IDE ou pode ser instalado separadamente).
    * Download: [https://git-scm.com/downloads](https://git-scm.com/downloads)


### 🏃 Como Rodar o Projeto

1.  **Clone o Repositório:**
    ```bash
    git clone [https://github.com/SeuUsuario/SistemaMarmoreGranito.git](https://github.com/SeuUsuario/SistemaMarmoreGranito.git)
    cd SistemaMarmoreGranito
    ```
2.  **Restaure as Dependências:**
    ```bash
    dotnet restore
    ```
3.  **Construa a Aplicação:**
    ```bash
    dotnet build
    ```
4.  **Execute a Aplicação:**
    ```bash
    dotnet run
    ```
    *(Para projetos Windows Form ou ASP.NET MVC, vocês podem abrir a solução no Visual Studio e executá-la diretamente por lá.)*

## 💡 Boas Práticas de Codificação e Padrões de Projeto

Neste projeto, adotamos diversas boas práticas de codificação e padrões de projeto para garantir a manutenibilidade, legibilidade e escalabilidade do código.

## 👥 Membros da Equipe

* **Carla Vazzoler Loureiro** 
* **[Nome Completo do Aluno 2]** 
* **[Nome Completo do Aluno 3]**
* **[Nome Completo do Aluno 4]** 
