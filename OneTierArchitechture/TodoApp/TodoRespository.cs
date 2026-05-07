using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoRespository
    {
        private readonly List<Todo> _todos = new();
        private readonly string _filepath = "todo.txt";
        private int _nextId = 1;

        public TodoRespository()
        {
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            if (!File.Exists(_filepath)) return;

            foreach (var line in File.ReadAllLines(_filepath))
            {
                var item = Todo.FromFileString(line);
                _todos.Add(item);
                if (item.Id >= _nextId)
                    _nextId = item.Id++;
            }
        }
        public void SaveChange()
        {
            File.WriteAllLines(
                _filepath,
                _todos.Select(x => x.ToFileString())
             );
        }

        public List<Todo> GetAll() => _todos;
        public Todo AddTodo(string title)
        {
            var item = new Todo
            {
                Id = _nextId++,
                Title = title,
                IsSuccess = false
            };
            _todos.Add(item);
            SaveChange();
            return item;
        }
        public bool UpdateTodo(int id, string titile)
        {
            var item = _todos.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Title = titile;
                SaveChange();
                return true;
            }
            return false;
        }

        public bool DeleteTodo(int id)
        {
            var item = _todos.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _todos.Remove(item);
                SaveChange();
                return true;
            }
            return false;
        }

        public bool ToggleComplete(int id)
        {
            var item = _todos.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.IsSuccess = !item.IsSuccess;
                SaveChange();
                return true;
            }
            return false;
        }   
    }
}
