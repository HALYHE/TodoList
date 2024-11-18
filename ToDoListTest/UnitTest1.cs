using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ToDoList;

namespace ToDoList.Tests
{
    [TestClass]
    public class TodoServiceTests
    {
        private TodoService _todoService;

        [TestInitialize]
        public void Setup()
        {
            _todoService = new TodoService();
        }

        [TestMethod]
        public void AddTodo_ShouldAddTodoCorrectly()
        {
            var todo = new Todo { Title = "Test", Description = "Test Description" };
            _todoService.AddTodo(todo);

            var todos = _todoService.GetAllTodos();
            Assert.AreEqual(1, todos.Count);
            Assert.AreEqual(todo.Title, todos[0].Title);
            Assert.AreEqual(todo.Description, todos[0].Description);
        }

        [TestMethod]
        public void GetAllTodos_ShouldReturnAllTodos()
        {
            var todo1 = new Todo { Title = "Test1", Description = "Test Description1" };
            var todo2 = new Todo { Title = "Test2", Description = "Test Description2" };

            _todoService.AddTodo(todo1);
            _todoService.AddTodo(todo2);

            var todos = _todoService.GetAllTodos();
            Assert.AreEqual(2, todos.Count);
        }

        [TestMethod]
        public void RemoveTodoById_ShouldRemoveTodoCorrectly()
        {
            var todo = new Todo { Title = "Test", Description = "Test Description" };
            _todoService.AddTodo(todo);

            var result = _todoService.RemoveTodoById(todo.Id);
            var todos = _todoService.GetAllTodos();

            Assert.IsTrue(result);
            Assert.AreEqual(0, todos.Count);
        }

        [TestMethod]
        public void RemoveTodoById_ShouldReturnFalse_WhenTodoDoesNotExist()
        {
            var result = _todoService.RemoveTodoById(Guid.NewGuid());

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateTodoById_ShouldUpdateTodoCorrectly()
        {
            var todo = new Todo { Title = "Test", Description = "Test Description" };
            _todoService.AddTodo(todo);

            var result = _todoService.UpdateTodoById(todo.Id, "Updated Title", "Updated Description");
            var updatedTodo = _todoService.GetAllTodos()[0];

            Assert.IsTrue(result);
            Assert.AreEqual("Updated Title", updatedTodo.Title);
            Assert.AreEqual("Updated Description", updatedTodo.Description);
        }

        [TestMethod]
        public void UpdateTodoById_ShouldReturnFalse_WhenTodoDoesNotExist()
        {
            var result = _todoService.UpdateTodoById(Guid.NewGuid(), "Updated Title", "Updated Description");

            Assert.IsFalse(result);
        }
    }
}
