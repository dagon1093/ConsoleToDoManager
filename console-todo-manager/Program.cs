﻿using ConsoleToDoManager.Service;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ConsoleToDoManager.Data;

class Program
{

    static void Main()
    {

        var serviceProvider = new ServiceCollection()
        .AddLogging(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Information);
        })
        .AddDbContext<ApplicationContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=TodoManager;Username=postgres;Password=Rp_9i7g7"))
        .AddScoped<IToDoService, ToDoService>()
        .BuildServiceProvider();

        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        var toDoService = serviceProvider.GetRequiredService<IToDoService>();

        while (true)
        {
            Console.WriteLine("------ Введи номер команды ------");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Показать задачи");
            Console.WriteLine("3. Пометить как выполненную");
            Console.WriteLine("4. Изменить задачу");
            Console.WriteLine("5. Удалить задачу");
            Console.WriteLine("0. Выход");

            string choice = Console.ReadLine();
            string title;
            
            switch (choice)
            {
                case "1":
                    Console.Write("Введите название задачи: ");
                    title = Console.ReadLine();
                    toDoService.AddTask(title);
                    break;
                case "2":
                    toDoService.ShowTasks( toDoService.ListTasks() );
                    break;
                case "3":
                    Console.Write("Введите заголовок задачи: ");
                    title = Console.ReadLine();
                    toDoService.CompleteTask(title);
                    break;
                case "4":
                    var tasks = toDoService.ListTasks();
                    toDoService.ShowTasks(tasks);
                    Console.Write("Введите номер задачи, которую нужно изменить: ");
                    if(int.TryParse(Console.ReadLine(), out int editNum))
                    {
                        Console.Write("Введите новое название: ");
                        string newTitle = Console.ReadLine();
                        toDoService.EditTask(tasks[editNum - 1].Id, newTitle);
                        Console.WriteLine("Название задачи изменено");
                    }
                    break;
                case "5":
                    var tasksToDelete = toDoService.ListTasks();
                    toDoService.ShowTasks(tasksToDelete);
                    Console.Write("Введите номер задачи, которую нужно удалить: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteNum))
                    {
                        toDoService.DeleteTaskById(tasksToDelete[deleteNum - 1].Id);
                        Console.WriteLine("Задача удалена");
                    }                  
                    break;
                case "0":
                    Console.WriteLine("👋 До свидания!");
                    return;
                default:
                    Console.WriteLine("⚠️ Неверный ввод, попробуйте снова.");
                    break;
            }
        }
    }



}

