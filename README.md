<div align="center">

# 🐾 PetHealth API

**Sistema inteligente para gerenciamento de clínicas veterinárias e ciclo vacinal de pets**

![.NET](https://img.shields.io/badge/.NET_8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=for-the-badge&logo=postgresql&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

</div>

---

## 📋 Sobre o Projeto

O **PetHealth** é uma API RESTful desenvolvida em .NET 8 para gerenciamento completo de clínicas veterinárias. O sistema centraliza o controle de pets e vacinas, com destaque para um serviço de monitoramento em background que automaticamente identifica e alerta sobre vacinações pendentes nos próximos 30 dias.

---

## 🚀 Tecnologias

| Tecnologia | Descrição |
|---|---|
| C# / .NET 8 | Linguagem e framework principal |
| ASP.NET Core Web API | Exposição dos endpoints REST |
| Entity Framework Core | ORM para mapeamento objeto-relacional |
| PostgreSQL | Banco de dados relacional |
| Worker Services | Processamento em segundo plano |
| Swagger / OAS 3.0 | Documentação interativa da API |

---

## ✨ Funcionalidades

- **Gestão de Pets** — CRUD completo de animais de estimação com vínculo ao tutor
- **Controle de Vacinas** — Registro de aplicações com cálculo automático da data da próxima dose
- **Monitoramento Automático** — `BackgroundService` que verifica diariamente pets com vacinação pendente nos próximos 30 dias
- **Sistema de Alertas** — Serviço desacoplado de notificações via logs, preparado para integração com SMTP

---

## 📡 Endpoints

### 🐶 Pet — `/api/pets`

| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/pets` | Cadastrar novo pet |
| `GET` | `/api/pets` | Listar todos os pets |
| `GET` | `/api/pets/{id}` | Buscar pet por ID |
| `PUT` | `/api/pets/{id}` | Atualizar dados do pet |
| `DELETE` | `/api/pets/{id}` | Remover pet |
| `GET` | `/api/pets/vacinas/{id}` | Listar vacinas de um pet |

### 💉 Vacina — `/api/vacina`

| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/vacina` | Registrar nova vacina |
| `GET` | `/api/vacina` | Listar todas as vacinas |
| `GET` | `/api/vacina/{id}` | Buscar vacina por ID |
| `PUT` | `/api/vacina/{id}` | Atualizar vacina |
| `DELETE` | `/api/vacina/{id}` | Remover vacina |
| `GET` | `/api/vacina/alertas` | Listar alertas de vacinação pendente |

> A documentação interativa completa está disponível em `http://localhost:5111/swagger` após iniciar a aplicação.

---

## 🏗️ Arquitetura

```
PetHealth/
├── Controllers/       # Exposição dos endpoints da API
├── Models/            # Entidades do banco de dados
├── Services/          # Lógica de negócio e serviços externos
├── Workers/           # Tarefas agendadas em background
├── Data/              # Configurações do DbContext (EF Core)
└── .env.example       # Modelo de variáveis de ambiente
```

---

## 🏁 Como Executar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

### 1. Clonar o repositório

```bash
git clone https://github.com/seu-usuario/PetHealth.git
cd PetHealth
```

### 2. Configurar variáveis de ambiente

Crie um arquivo `.env` na raiz do projeto baseado no `.env.example`:

```env
DB_CONNECTION_STRING=Host=localhost;Database=PetHealth;Username=postgres;Password=sua_senha
```

### 3. Aplicar as migrations

```bash
dotnet ef database update
```

### 4. Rodar a aplicação

```bash
dotnet run
```

A API estará disponível em **http://localhost:5111**  
A documentação Swagger em **http://localhost:5111/swagger**

---

## 📁 Variáveis de Ambiente

| Variável | Descrição | Exemplo |
|---|---|---|
| `DB_CONNECTION_STRING` | String de conexão com o PostgreSQL | `Host=localhost;Database=PetHealth;...` |

---

## 🤝 Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para abrir uma _issue_ ou enviar um _pull request_.

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. Commit suas mudanças (`git commit -m 'feat: adiciona MinhaFeature'`)
4. Push para a branch (`git push origin feature/MinhaFeature`)
5. Abra um Pull Request

---

<div align="center">

Feito com ❤️ e ☕

</div>
