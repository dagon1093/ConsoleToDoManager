using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleToDoManager.Models;

namespace ConsoleToDoManager.Service
{
    internal interface IToDoService
    {
        public void AddTask(string title);
        public ToDoTask GetTaskByTitle(string title);
        public void DeleteTask(string title);
        public void DeleteTaskById(int id);
        public List<ToDoTask> ListTasks();
        public void CompleteTask(string title);
        public void EditTask(int id, string? newTitle);
        public void ShowTasks(List<ToDoTask> tasks);

    }
}
