using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoService
    {
        private readonly TodoRespository _respository = new();
        public List<Todo> GetTodo() => _respository.GetAll();
        public Todo CreateTodo(string title) => _respository.AddTodo(title);

        public bool UpdateTodo(int id, string title) => _respository.UpdateTodo(id, title);
        public bool DeleteTodo(int id) => _respository.DeleteTodo(id);
        public bool ToggleTodo(int id) => _respository.ToggleComplete(id);
    }
}
