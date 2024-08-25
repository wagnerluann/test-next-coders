using System;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Context
{
    public class NextContext : DbContext
    {
        public NextContext(DbContextOptions<NextContext> options) : base(options)
        {
        }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder construtor)
        {

        }

    }
}