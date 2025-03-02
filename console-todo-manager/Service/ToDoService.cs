using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleToDoManager.Data;
using ConsoleToDoManager.Models;

namespace ConsoleToDoManager.Service
{
    public class ToDoService
    {
        private readonly ApplicationContext _context;
        public ToDoService()
        {
            _context = new ApplicationContext();
            _context.Database.EnsureCreated();
        }

        public void AddTask(string title)
        {
            var task = new ToDoTask { Title = title, Description = "", IsCompleted = false };
            _context.Tasks.Add(task);
            _context.SaveChanges();
            Console.WriteLine("Задача добавлена");
        }

        public ToDoTask GetTaskByTitle(string title)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Title == title);
            return task;
        }

        public void DeleteTask(string title)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Title == title);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                Console.WriteLine("Задача удалена");
            }
            else
            {
                Console.WriteLine("Задача не найдена");
            }
        }
        public void ListTasks()
        {
            var tasks = _context.Tasks.ToList();
            if (tasks.Count == 0)
            {
                Console.WriteLine("Список задач пуст");
            }

            foreach (var task in tasks)
            {
                Console.WriteLine(task.Title);
            }

        }

        public void CompleteTask(string title)
        {
            throw new NotImplementedException();
        }


    }
}
