🐾 PetHealth API

O PetHealth é uma API robusta desenvolvida em .NET para o gerenciamento de clínicas veterinárias e pets. O sistema foca no acompanhamento do ciclo de vida vacinal dos animais, contando com um serviço inteligente de monitoramento em background para alertas de vacinação.
🚀 Tecnologias Utilizadas

    C# / .NET 8

    ASP.NET Core Web API

    Entity Framework Core (ORM)
    
    PostgreSQL (Banco de Dados Relacional)
    
    Worker Services (Processamento em segundo plano)

    Swagger (Documentação de API)

🛠️ Funcionalidades Principais

    Gestão de Pets: CRUD completo de animais de estimação.

    Controle de Vacinas: Registro de aplicações e cálculo automático de próxima dose com base na duração.

    Monitoramento Automático: Um BackgroundService (Worker) que verifica diariamente quais pets precisam ser vacinados nos próximos 30 dias.

    Sistema de Notificações: Serviço desacoplado para alertas aos tutores via logs de sistema (preparado para integração com SMTP).

🏗️ Arquitetura

O projeto foi estruturado seguindo boas práticas de organização:

    Controllers: Exposição dos endpoints da API.

    Models: Representação das entidades do banco de dados.

    Services: Camada de lógica de negócio e serviços externos.

    Workers: Tarefas agendadas em segundo plano.

    Data: Configurações de contexto do Entity Framework.

🏁 Como Executar o Projeto

    Clonar o repositório:
    Bash

    git clone https://github.com/seu-usuario/PetHealth.git

    Configurar o Banco de Dados:
    Crie um arquivo .env na raiz do projeto baseado no .env.example:
    Plaintext

    DB_CONNECTION_STRING=Host=localhost;Database=PetHealth;Username=postgres;Password=sua_senha

    Executar as Migrations:
    Bash

    dotnet ef database update

    Rodar a aplicação:
    Bash

    dotnet run

    A API estará disponível em http://localhost:5111 (ou na porta configurada no seu launchSettings.json).

📄 Documentação (Swagger)

Com a aplicação rodando, acesse a interface do Swagger para testar os endpoints:
http://localhost:5111/swagger
