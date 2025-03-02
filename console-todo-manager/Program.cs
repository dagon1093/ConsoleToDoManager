using ConsoleToDoManager.Service;

class Program
{
    static ToDoService toDoService = new ToDoService();

    static void Main()
    {
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
                    toDoService.ListTasks();
                    break;
                case "3":
                    Console.Write("Введите заголовок задачи: ");
                    title = Console.ReadLine();
                    toDoService.CompleteTask(title);
                    break;
                case "4":
                    //ToDo
                    Console.WriteLine("Вы пока не можете изменить задачу");
                    break;
                case "5":
                    Console.Write("Введите заголовок задачи: ");
                    title = Console.ReadLine();
                    toDoService.DeleteTask(title);
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

