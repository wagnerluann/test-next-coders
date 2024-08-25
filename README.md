# Gerenciador de Tarefas - API ASP.NET Core
## Este projeto é uma API RESTful para o gerenciamento de tarefas, desenvolvida em ASP.NET Core. A API permite criar, ler, atualizar e excluir (CRUD) tarefas, além de filtrar tarefas pelo status (Pendente ou Concluída).

# Funcionalidades
#### CRUD de Tarefas: Permite criar, listar, atualizar e excluir tarefas.
#### Visualização do Status: O status das tarefas é exibido como "Pendente = 0" ou "Concluída = 1".

# Estrutura do Projeto
## Segui o modelo requisitado
#### (int, chave primária)
#### (string, obrigatório)
#### Descrição (string)
#### (enum: Pendente, Concluída)
#### Data de Criação (DateTime)
#### Data de Conclusão (DateTime?)

# Pré-requisitos
#### .NET 8.
#### Banco de dados MySQL
#### Ferramentas de gerenciamento de dependências, como NuGet