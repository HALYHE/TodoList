using System;
using System.Collections.Generic;
using System.Windows;

namespace ToDoList
{
    public partial class MainWindow : Window
    {
        private List<Todo> tasks;

        public MainWindow()
        {
            InitializeComponent();
            tasks = new List<Todo>();
            UpdateTaskList();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleInput.Text;
            string description = DescriptionInput.Text;

            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(description))
            {
                tasks.Add(new Todo { Title = title, Description = description });
                TitleInput.Clear();
                DescriptionInput.Clear();
                UpdateTaskList();
            }
            else
            {
                MessageBox.Show("Заголовок и описание задачи не могут быть пустыми!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateTaskList()
        {
            TaskList.ItemsSource = null;
            TaskList.ItemsSource = tasks;
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem != null)
            {
                tasks.Remove((Todo)TaskList.SelectedItem);
                UpdateTaskList();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите задачу для удаления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem != null && !string.IsNullOrWhiteSpace(UpdatedTitleInput.Text) && !string.IsNullOrWhiteSpace(UpdatedDescriptionInput.Text))
            {
                int selectedIndex = TaskList.SelectedIndex;
                tasks[selectedIndex].Title = UpdatedTitleInput.Text;
                tasks[selectedIndex].Description = UpdatedDescriptionInput.Text;
                UpdatedTitleInput.Clear();
                UpdatedDescriptionInput.Clear();
                UpdateTaskList();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите задачу для обновления и введите новые значения заголовка и описания!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TaskList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (TaskList.SelectedItem != null)
            {
                Todo selectedTask = (Todo)TaskList.SelectedItem;
                TaskDetailsWindow taskDetailsWindow = new TaskDetailsWindow(selectedTask);
                taskDetailsWindow.Show();
            }
        }
    }
}
