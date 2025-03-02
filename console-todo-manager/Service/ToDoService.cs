using System.Threading.Tasks;
using ConsoleToDoManager.Data;
using ConsoleToDoManager.Models;
using Microsoft.Extensions.Logging;

namespace ConsoleToDoManager.Service
{
    public class ToDoService : IToDoService
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ToDoService> _logger;
        public ToDoService(ApplicationContext context, ILogger<ToDoService> logger)
        {
            _context = context;
            _logger = logger;
            _context.Database.EnsureCreated();
        }

        public void AddTask(string title)
        {
            var task = new ToDoTask { Title = title, Description = "", IsCompleted = false };
            _context.Tasks.Add(task);
            _context.SaveChanges();
            _logger.LogInformation($"Задача: \"{task.Title}\" добавлена");
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
                _logger.LogInformation($"Задача c id\"{task.Id}\" удалена");
            }
            else
            {
                _logger.LogWarning($"Задача c id\"{task.Id}\" не найдена");
            }
        }

        public void DeleteTaskById(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                _logger.LogInformation($"Задача c id\"{task.Id}\" удалена");
            }
            else
            {
                _logger.LogWarning($"Задача c id\"{task.Id}\" не найдена");
            }
        }
        public List<ToDoTask> ListTasks()
        {
            var tasks = _context.Tasks.ToList();

            if (tasks.Count == 0)
            {
                _logger.LogInformation($"Задач нет.");
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
                _logger.LogWarning($"Не удалось отредактировать. Задача c id\"{task.Id}\" не найдена");
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
