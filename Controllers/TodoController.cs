using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projeto_csharp_web_api_todolist.Context;
using projeto_csharp_web_api_todolist.Models;

namespace projeto_csharp_web_api_todolist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        
        public readonly TodoContext _context;

        public TodoController(TodoContext context) {
            this._context = context;
        }

        //Rota que retorna uma instância de Tarefa, de acordo com o a variável id passada no final da URL
        [HttpGet("ObterPorId/{id}")]
        public IActionResult ObterPorId(int id) {
            var tarefa = this._context.Tarefas.Find(id);

            if(tarefa == null) {return NotFound();}

            return Ok(tarefa);
        }

        //Rota que altera dados de uma instância de Tarefa, de acordo com as novas informações desejadas (id obrigatória)
          [HttpPut("AlterarTarefa/{id}")]
        public IActionResult AlterarTarefa(int id, string titulo, string descricao, string status){

            var tarefa = this._context.Tarefas.Find(id);

            if(tarefa == null) {return NotFound();}

            tarefa.Titulo = titulo;
            tarefa.Descricao = descricao;
            tarefa.Status = status;

            this._context.Tarefas.Update(tarefa);
            this._context.SaveChanges();
            return Ok($"Tarefa \n --> {tarefa.Titulo}\n foi altera!");

        }

        //Rota que Elimina uma instância de Tarefa, de acordo com o a variável id passada no final da URL
          [HttpDelete("DeletarTarefa/{id}")]
        public IActionResult DeletarTarefa(int id){
            var tarefa = this._context.Tarefas.Find(id);

            if(tarefa == null) {return NotFound();}

            this._context.Tarefas.Remove(tarefa);
            this._context.SaveChanges();
            return Ok($"Tarefa \n --> {tarefa.Titulo}\n foi removida!");

        }

        //Rota que retorna uma Lista contendo todas as instâncias de Tarefa presentes em Tarefas no DB ToDoList
        [HttpGet("ObterTodos")]
        public IActionResult ListarTarefas(){

            var tarefas = this._context.Tarefas.ToList();

            if(tarefas == null) { return NotFound();}

            return Ok(tarefas);
        }

        //Rota que Retorna uma instância de Tarefa, de acordo com o a variável titulo passada no final da URL
        [HttpGet("ObterPorTitulo/{titulo}")]
        public IActionResult ObterPorTitulo(string titulo) {
            var ListaTarefa = this._context.Tarefas.Where(x => x.Titulo == titulo);

            if(ListaTarefa == null) {return NotFound();}

            return Ok(ListaTarefa.ToList());
        }

        //Rota que Retorna uma instância de Tarefa, de acordo com o a variável data passada no final da URL
        [HttpGet("ObterPorData/{data}")]
        public IActionResult ObterPorData(DateTime data) {
            var ListaTarefa = this._context.Tarefas.Where(x => x.Data == data);

            if(ListaTarefa == null) {return NotFound();}

            return Ok(ListaTarefa.ToList());
        }

        //Rota que Retorna uma instância de Tarefa, de acordo com o a variável status passada no final da URL
        [HttpGet("ObterPorStatus/{status}")]
        public IActionResult ObterPorStatus(string status) {
            var ListaTarefa = this._context.Tarefas.Where(x => x.Status == status);

            if(ListaTarefa == null) {return NotFound();}

            return Ok(ListaTarefa.ToList());
        }

        //Rota para criar uma nova instância de Tarefa e persisti-lá no DB ToDoList na Entidade Tarefas
        [HttpPost]
        public IActionResult CriarTarefa(Tarefa tarefa) {
            tarefa.Data = DateTime.Now;
            this._context.Tarefas.Add(tarefa);
            this._context.SaveChanges();
            return Ok($"Tarefa \n --> {tarefa.Titulo}\n foi Criada!");
        }

      
        
    }
}