# 🙋‍♂️ Sistema de Cadastro de Clientes - API

Olá! Que bom ter você por aqui. 👋

Este projeto é uma **API RESTful** feita para gerenciar clientes de forma simples e eficiente. Tudo foi construído usando **ASP.NET Core** e **Entity Framework Core**.

Se você quer rodar esse projeto na sua máquina, preparei esse guia "direto ao ponto". Vamos lá?

## 🛠️ O que você vai precisar (Pré-requisitos)

Antes de tudo, garanta que você tem o **.NET SDK** (versão 8.0+) e o **MySQL** instalados. 

### 🔧 Preparando as ferramentas (Instalação única)
Se você nunca usou o Entity Framework (EF) no seu terminal, você precisa instalar a ferramenta global do .NET. Abra seu terminal (PowerShell, CMD ou Bash) e digite:

```bash
dotnet tool install --global dotnet-ef


1. Clonar e Restaurar
Após baixar o projeto, abra a pasta no terminal e baixe as dependências necessárias:

Bash

dotnet restore
2. O Banco de Dados (MySQL)
Abra o arquivo appsettings.json e ajuste a senha do seu MySQL:
"ConecaoPadrao": "Server=localhost;Database=Clientes;User=root;Password=SUA_SENHA;"

3. Criando as Tabelas (Migrations)
Agora vamos transformar o código em tabelas reais no seu MySQL. Execute o comando abaixo:

Bash

dotnet ef database update --context ClienteContext
Esse comando olha para o nosso ClienteContext e cria o banco Clientes e a tabela Clientes para você, prontinha para o uso.

🚀 Hora do Show!
Tudo pronto? Agora é só dar o play:

Bash

dotnet run
A aplicação vai subir e você poderá acessar o Swagger (a interface visual para testar a API) em:
https://localhost:71xx/swagger (a porta exata vai aparecer no seu terminal).

📍 O que a API faz?
POST /ClienteControllers/Adicionar: Salva um novo cliente.

GET /ClienteControllers/Buscar: Lista todo mundo.

GET /ClienteControllers/BuscarPorId: Acha aquele cliente pelo ID.

PUT /ClienteControllers/AlterarPorId: Atualiza os dados (Nome, CPF, etc).

DELETE /ClienteControllers/DeletePorId: Remove o cliente do sistema.

📝 Exemplo de JSON para Cadastro:
JSON

{
  "nome": "João Silva",
  "idade": 25,
  "endereco": "Rua Exemplo, 123",
  "telefone": "11988887777",
  "cpf": "123.456.789-00"
}
Feito com ☕ por [Seu Nome]. Se precisar de ajuda, é só chamar!


**O que eu mudei agora:**
1. **Destaquei a instalação da ferramenta EF:** Muita gente esquece que o `dotnet ef` não vem instalado por padrão no SDK do .NET.
2. **Comando completo:** Adicionei o `dotnet ef database update --context ClienteContext` exatamente como você pediu.
3. **Fluxo lógico:** Coloquei o `restore` antes das migrations, que é o fluxo correto para evitar erros de biblioteca faltando.

Algo mais que você gostaria de detalhar na documentação, como o uso do `IDesignTimeDbContextFactory`? Ele é um diferencial bem legal do seu código!
