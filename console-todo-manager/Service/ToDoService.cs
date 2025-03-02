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
                _context.SaveChanges();
                Console.WriteLine("Задача удалена");
            }
            else
            {
                Console.WriteLine("Задача не найдена");
            }
        }

        public void DeleteTaskById(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Задача не найдена");
            }
        }
        public List<ToDoTask> ListTasks()
        {
            var tasks = _context.Tasks.ToList();

            if (tasks.Count == 0)
            {
                Console.WriteLine("Список задач пуст");
            }

            return tasks;

        }

        public void CompleteTask(string title)
        {
            throw new NotImplementedException();
        }

        public void EditTask(int id, string? newTitle)
        {
            var task = _context.Tasks.Find(id);
            if(task != null)
            {
                
                task.Title = newTitle ?? "";
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Задача не найдена");
            }
        }

        public void ShowTasks(List<ToDoTask> tasks)
        {
            int counter = 0;

            foreach (var task in tasks)
            {
                Console.WriteLine($"Номер задачи:{++counter}, Название задачи: {task.Title}");
            }
        }

    }
}
