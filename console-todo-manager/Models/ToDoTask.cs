using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleToDoManager.Models
{
    public class ToDoTask
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public ToDoTask() { }
        public ToDoTask(int id, string title, string description, bool isCompleted)
        {
            Id = id;
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
        }
        public override string ToString()
        {
            return $"Номер задачи: {Id}, Заголовок: {Title}, is complited {(IsCompleted ? "Выполнено": "Не выполнено" )}";
        }
    }
    
}
