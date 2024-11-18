using System;
using System.Collections.Generic;
using System.Linq;
using TodoList;

namespace ToDoList
{
    public class TodoService
    {
        private readonly List<Todo> _todos;

        public TodoService()
        {
            _todos = new List<Todo>();
        }

        public void AddTodo(Todo todo)
        {
            _todos.Add(todo);
        }

        public List<Todo> GetAllTodos()
        {
            return _todos;
        }

        public bool RemoveTodoById(Guid id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
                return false;
            _todos.Remove(todo);
            return true;
        }

        public bool UpdateTodoById(Guid id, string newTitle, string newDescription)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
                return false;
            todo.Title = newTitle;
            todo.Description = newDescription;
            return true;
        }
    }
}
