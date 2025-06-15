# Sistema de Gerenciamento para Mármore e Granito

## 📑 Sobre o projeto

Este projeto consiste na implementação de um Sistema de Gerenciamento de Mármore e Granito, desenvolvido como uma aplicação de console em C# e utilizando o framework .NET 8.0. O principal objetivo é demonstrar a persistência de dados em um banco de dados relacional SQLite e a organização do código através de um modelo de camadas simplificado.

O sistema simula operações essenciais de uma empresa do setor, permitindo o controle de usuários, o cadastro de blocos de rocha com suas características e notas fiscais de entrada, o registro de chapas avulsas (que podem ou não ter um bloco de origem), e uma funcionalidade chave: o processo de serragem, que transforma automaticamente um bloco em múltiplas chapas, salvando-as no estoque. Além disso, o sistema oferece opções para listar os itens cadastrados, proporcionando uma visão do inventário

## ⚙️ Configuração do ambiente

### ✔️ Pré-requisitos

* **Linguagem de Programação:** C#
* **Framework:** .NET 8.0
* **Banco de Dados:** SQLite (relacional)
* 
## 🚀 Como executar o projeto

```bash
# Clone este repositório
git clone https://github.com/carlavloureiro/sistema-marmore-granito.git

 **Acesse a pasta do projeto:**
 Navegue até o diretório principal do projeto clonado, onde se encontra o arquivo `MarmoreGranitoSistema.csproj`.
```bash
cd sistema-marmore-granito

*Obs: Certifique-se de estar na pasta que contém o arquivo `.csproj`.*
**Restaure as dependências e compile o projeto:**
 Execute o comando `dotnet build` para restaurar os pacotes NuGet necessários e compilar o projeto.
```bash
 dotnet build

**Execute a aplicação:**
 Após a compilação bem-sucedida, execute a aplicação console com o comando `dotnet run`.
 ```bash
dotnet run
    ```
O sistema iniciará no terminal, apresentando o menu de login e as opções de interação.
 ```

## 👥 Colaborador(as/es)

- **Carla Vazzoler Loureiro**
- **Gabriel Ramos Maciel** 
- **Luis Gustavo de Jesus Ribeiro Pimentel** 
- **Luiz Henrique Lesquives Sartório**

