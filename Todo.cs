using System;

namespace ToDoList
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Todo()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return Title; // Для отображения в ListBox
        }
    }
}
