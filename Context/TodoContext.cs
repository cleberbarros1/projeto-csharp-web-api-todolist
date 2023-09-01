using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projeto_csharp_web_api_todolist.Models;

namespace projeto_csharp_web_api_todolist.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) {}

        public DbSet<Tarefa> Tarefas { get; set; }
        
    }
}