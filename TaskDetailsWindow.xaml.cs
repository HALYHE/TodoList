using System.Windows;

namespace ToDoList
{
    public partial class TaskDetailsWindow : Window
    {
        public TaskDetailsWindow(Todo task)
        {
            InitializeComponent();
            TitleTextBox.Text = task.Title;
            DescriptionTextBox.Text = task.Description;
        }
    }
}
