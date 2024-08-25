using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace Models

{
    [Table("tb_tarefa")]
    public class Tarefa

    {
        // ID da Tarefa
        [Key]
        [Column("Id_tarefa")]
        public int Id { get; set; }

        // Título da Tarefa
        [Column("Titulo_tarefa")]
        public required string Titulo { get; set; }

        // Descrição da Tarefa
        [Column("Descricao_tarefa")]
        public string Descricao { get; set; }

        // Status da Tarefa (Pendete ou Concluida)
        [Column("StatusTarefa_tarefa")]
        public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;
        
        public enum StatusTarefa
        {
            Pendente,
            Concluida
        }

        // Data de Criação da Tarefa
        [Column("DataCriacao_tarefa")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        // Data da Conclusão da Tarefa
        [Column("DataConclusao_tarefa")]
        public DateTime? DataConclusao { get; set; }
    }


public static class TarefaEndpoints
{
	public static void MapTarefaEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Tarefa").WithTags(nameof(Tarefa));

        group.MapGet("/", async (NextContext db) =>
        {
            return await db.Tarefas.ToListAsync();
        })
        .WithName("GetAllTarefas")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Tarefa>, NotFound>> (int id, NextContext db) =>
        {
            return await db.Tarefas.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Tarefa model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetTarefaById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Tarefa tarefa, NextContext db) =>
        {
            var affected = await db.Tarefas
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, tarefa.Id)
                  .SetProperty(m => m.Titulo, tarefa.Titulo)
                  .SetProperty(m => m.Descricao, tarefa.Descricao)
                  .SetProperty(m => m.Status, tarefa.Status)
                  .SetProperty(m => m.DataCriacao, tarefa.DataCriacao)
                  .SetProperty(m => m.DataConclusao, tarefa.DataConclusao)
                  );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateTarefa")
        .WithOpenApi();

        group.MapPost("/", async (Tarefa tarefa, NextContext db) =>
        {
            db.Tarefas.Add(tarefa);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Tarefa/{tarefa.Id}",tarefa);
        })
        .WithName("CreateTarefa")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, NextContext db) =>
        {
            var affected = await db.Tarefas
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteTarefa")
        .WithOpenApi();
    }
}}
