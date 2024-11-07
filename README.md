# Sistema de Gerenciamento de Agendamentos de Consultas

## Visão Geral do Projeto

Este projeto consiste em um sistema de gerenciamento de consultas desenvolvido em ASP.NET Core, que permite criar, visualizar, atualizar e deletar agendamentos de consultas médicas. O objetivo é fornecer uma plataforma simples e intuitiva para monitorar agendamentos de consultas, facilitando o acompanhamento de status, detalhes de pacientes, médicos, e tratamentos realizados.

As principais funcionalidades incluem:
- **Criação de Agendamentos de Consultas**: Inclui informações detalhadas como data e hora, endereço, paciente, médico responsável, tipo de tratamento e motivo da consulta.
- **Visualização e Edição de Agendamentos**: Permite visualizar e atualizar informações de consultas, mantendo um histórico claro e atualizado.
- **Listagem de Consultas Agendadas**: Apresenta uma lista com todos os agendamentos e seus respectivos status para fácil monitoramento e controle.
- **Validações Integradas**: Garante que todos os campos necessários sejam preenchidos de forma correta e que a aplicação siga boas práticas de validação.

## Funcionalidades

- **CRUD de Consultas**:
  - Criação, visualização, edição e exclusão de consultas.
  - Acesso rápido aos dados dos pacientes, médicos e tratamentos relacionados a cada consulta.
- **Monitoramento de Status**: Cada consulta possui status de *Agendada*, *Concluída* ou *Cancelada*, facilitando o acompanhamento de andamento e conclusão de cada agendamento.
- **Interface com Bootstrap**: Interface amigável e responsiva utilizando Bootstrap para melhorar a experiência do usuário.
- **Validações e Controle de Erros**: Aplicação de validações e mensagens de erro claras para orientar o usuário.

## Estrutura do Projeto

O projeto segue uma arquitetura limpa, com separação de responsabilidades por camada:
- **Camada de Apresentação (Views)**: Interface do usuário com validações e formulários dinâmicos.
- **Camada de Aplicação (Services)**: Controla a lógica de negócio principal, intermediando as operações entre o banco de dados e a interface.
- **Camada de Persistência (Repositories)**: Acesso ao banco de dados usando o Entity Framework Core para operações CRUD de maneira otimizada.
- **Camada de Modelos (Models)**: Definição das entidades principais e DTOs para transferência de dados.

## Pré-requisitos

Para configurar e rodar este projeto, você precisará de:
- .NET SDK (versão 6 ou superior)
- Visual Studio ou Visual Studio Code
- SQL Server ou outra base de dados configurada para o Entity Framework

## Instruções de Instalação

1. **Clone o repositório**:
   ```bash
   git clone https://github.com/VitorOnofreRamos/Challenge-Odontoprev-ADB.git
   cd Challenge-Odontoprev-ADB
   ```
   
2. **Configuração do Banco de Dados**:
   - Configure a string de conexão com seu banco de dados no arquivo `appsettings.json` na seção `ConnectionStrings`.
   - Se você precisar criar uma nova migration para refletir mudanças no modelo do banco de dados, execute o seguinte comando.
     - Abra o **PowerShell** no diretório do seu projeto.
     - Execute o comando abaixo para criar a migration:
       
     ```bash
     dotnet ef migrations add NomeDaMigration
     ```
     *Ou se você etiver executando os comados pela IDE do Visual Studio:*
     ```bash
     Add-Migration NomeDaMigration
     ```
     *Substitua `NomeDaMigration` por um nome descritivo, como por exemplo `AddAppointmentsTable`.*
     
   - Rode as migrações do Entity Framework para criar as tabelas necessárias:
     ```bash
     dotnet ef database update
     ```
     *Ou*
      ```bash
     Update-Database
     ```

3. **Configuração do Projeto**:
   - Abra o projeto em seu editor de preferência (recomendado: Visual Studio ou Visual Studio Code).
   - Restaure as dependências:
     ```bash
     dotnet restore
     ```

4. **Iniciar a Aplicação**:
   ```bash
   dotnet run
   ```

5. Acesse a aplicação em `http://localhost:8080` (ou conforme a configuração do seu ambiente).

## Rotas Principais

- **Rota Principal**:
  - `/` - Página inicial com a lista de consultas agendadas.
- **CRUD de Consultas**:
  - `/appointment/create` - Criação de um novo agendamento.
  - `/appointment/edit/{id}` - Edição de um agendamento existente.
  - `/appointment/details/{id}` - Visualização dos detalhes de um agendamento.
  - `/appointment/delete/{id}` - Exclusão de um agendamento.

## Layout e Customização

A aplicação usa o layout principal com cabeçalho, rodapé e barra de navegação. A interface é customizada com Bootstrap para responsividade e inclui:
- **Barra de navegação** para acessar as principais funcionalidades.
- **Formulários responsivos** para criar e editar consultas.
- **Tabela de Listagem** com status e detalhes das consultas.

## Integrates

**Turma 2TDSPS**
- Vitor Onofre Ramos | RM553241
- Pedro Henrique | RM553801
- Beatriz Silva | RM552600

---
