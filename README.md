# Desafio Técnico - Aplicação de Gerenciamento de Tarefas

### Contexto do Desafio:
Você foi contratado para desenvolver uma aplicação de gerenciamento de tarefas para uma empresa. O sistema deve permitir que os usuários criem, editem e excluam tarefas. Além disso, o sistema deve exibir uma lista de tarefas filtráveis por status (Concluída, Pendente).

### Requisitos:

#### 1. Backend (.NET)
Desenvolver uma API RESTful usando ASP.NET Core que:

- Permita criar, ler, atualizar e excluir (CRUD) tarefas.
- Tenha rotas para filtrar as tarefas por status (Concluída, Pendente).
- Valide as entradas (e.g., campos obrigatórios).
- Utilize Entity Framework Core ou Dapper para se conectar a um banco de dados SQL.

**Modelo de Tarefa:**

- **ID** (int, chave primária)
- **Título** (string, obrigatório)
- **Descrição** (string)
- **Status** (enum: Pendente, Concluída)
- **Data de Criação** (DateTime)
- **Data de Conclusão** (DateTime?)

#### 2. Banco de Dados (SQL)
- Criar um banco de dados SQL para armazenar as tarefas.
- As tabelas podem ser criadas usando migrations do Entity Framework.
- Deve conter alguns dados pré-populados (seed) para testes.

#### 3. Frontend (React) **(Opcional)**
Criar uma aplicação simples em React que:

- Liste as tarefas na tela inicial.
- Tenha um formulário para criar uma nova tarefa.
- Permita editar e excluir tarefas.
- Permita filtrar as tarefas por status.
- Use chamadas à API para realizar as operações de CRUD.
  
Utilize React Hooks e, se necessário, algum state management como Context API.

#### 4. Extras (Diferenciais):
- Front-end
- Implementação de autenticação.
- Autenticação.
- Testes unitários para o backend.
- Deploy da aplicação em um ambiente cloud (Azure, AWS, Heroku, etc.).

### Entrega:

- Faça um **fork** deste repositório e implemente sua solução.
- Após finalizar, envie o link do repositório com sua solução.
- Incluir um arquivo **README** com instruções de configuração e execução da aplicação.

### Critérios de Avaliação:
- Organização do código e boas práticas.
- Clareza e objetividade nas implementações.
- Uso adequado do banco de dados.
