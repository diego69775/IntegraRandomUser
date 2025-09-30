# IntegraRandomUser

Projeto WebAPI em C# que consome a [RandomUser](https://randomuser.me/api/) para buscar dados de usuarios e armazena essas informações em um banco PostgreSQL. O projeto também inclui um **front-end simples em HTML/JavaScript** que permite visualizar e editar os usuarios diretamente do banco.

---

## 🔹 Tecnologias utilizadas

- **Backend:** C# .NET 7 WebAPI  
- **Banco de dados:** PostgreSQL  
- **ORM:** Entity Framework Core  
- **HTTP Client:** HttpClientFactory 
- **Frontend:** HTML + JavaScript  
- **Documentação da API:** Swagger  

---

## 🔹 Funcionalidades

1. **Consultar User na RandomUser**  
   - Endpoint: `GET /api/v1/User`  
   - Retorna informações do usuario como firstName, lastName, email, username, gender, city, state e country.  

2. **Salvar User no banco**  
   - Endpoint: `POST /api/v1/User`  
   - Consulta o usuario na RandomUser e salva no PostgreSQL.  

3. **Listar Users do banco**  
   - Endpoint: `GET /api/v1/User/db`  
   - Retorna todos os usuarios salvos.  

4. **Consulta User do banco pelo id**  
   - Endpoint: `GET /api/v1/User/db/{id}`  
   - Retorna o usuario daquele id.  

5. **Atualizar Users**  
   - Endpoint: `PUT /api/v1/User/db/{id}`  
   - Permite editar informações diretamente do front-end ou via Swagger.  

6. **Front-end**  
   - Localizado em `wwwroot/index.html`  
   - Exibe todos os usuarios do banco em uma tabela.  
   - Permite edição inline e atualização via botão "Salvar".  

---

## 🔹 Pré-requisitos

- .NET 7 SDK
- PostgreSQL
- Navegador moderno (Chrome, Edge, Firefox)
- Git

---

## 🔹 Configuração do projeto

1. Clone o repositório:

```bash
git clone https://github.com/diego69775/IntegraRandomUser.git
cd IntegraRandomUser
```

2. Configure a ConnectionString no appsettings.json:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=userdb;Username=postgres;Password=123456"
}
```

3. Crie o banco e aplique migrations:

``` bash
cd IntegraRandomUser
dotnet ef database update
```

4. Rode a API:

```bash
dotnet run
```

A API estará disponível em https://localhost:7169/.

🔹 Como usar o front-end

1. Abra o navegador em:

Acesse: https://localhost:7169/index.html

2. A tabela mostrará todos os usuarios do banco.

3. Para editar um usuario:
 - Alterar o valor nos campos da tabela.
 - Clicar no botão Salvar.
 - A tabela será atualizada automaticamente.

🔹 Testando a API via Swagger

Acesse: https://localhost:7169/swagger
Todos os endpoints estão documentados e podem ser testados diretamente pelo Swagger UI.

🔹 Observações

Certifique-se de que a porta da API (https://localhost:7169) corresponde à configuração no script.js.
Todos os dados de usuarios são persistidos em PostgreSQL, podendo ser consultados e editados posteriormente.
