using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dp_project.Observer;
using dp_project.UserInterface;
namespace dp_project
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            TaskObserver observer = new TaskObserver("Default Observer");
            MainScreen mainScreen = new MainScreen();
            taskManager.AttachObserver(observer);
            while (true)
            {
                mainScreen.Title();
                Console.WriteLine("===== Task Management System =====");
                Console.WriteLine("1. Create Task");
                Console.WriteLine("2. Update Task");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Display Tasks");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateTask(taskManager);
                        break;

                    case "2":
                        UpdateTask(taskManager);
                        break;

                    case "3":
                        DeleteTask(taskManager);
                        break;

                    case "4":
                        DisplayTasks(taskManager);
                        break;

                    case "5":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }
        static void CreateTask(TaskManager taskManager)
        {
            Console.Write("Enter Task Name: ");
            string taskName = Console.ReadLine();

            Console.Write("Enter Deadline (yyyy-mm-dd): ");
            DateTime deadline = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Status: ");
            string status = Console.ReadLine();

            Console.Write("Enter Assignee: ");
            string assignee = Console.ReadLine();

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Task newTask = new Task
            {
                TaskName = taskName,
                Deadline = deadline,
                Status = status,
                Assignee = assignee,
                Description = description
            };

            taskManager.AddTask(newTask);
        }
        static void UpdateTask(TaskManager taskManager)
        {
            Console.Write("Enter Task ID to Update: ");
            int taskId = int.Parse(Console.ReadLine());

            Task existingTask = taskManager.GetTaskById(taskId);

            if (existingTask != null)
            {
                Console.Write("Enter new Status: ");
                string newStatus = Console.ReadLine();

                existingTask.Status = newStatus;

                taskManager.NotifyObservers(existingTask);
                Console.WriteLine($"Task {taskId} updated successfully.");
            }
            else
            {
                Console.WriteLine($"Task with ID {taskId} not found.");
            }
        }
        static void DeleteTask(TaskManager taskManager)
        {
            Console.Write("Enter Task ID to Delete: ");
            int taskId = int.Parse(Console.ReadLine());

            Task existingTask = taskManager.GetTaskById(taskId);

            if (existingTask != null)
            {
                taskManager.RemoveTask(existingTask);
                Console.WriteLine($"Task {taskId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Task with ID {taskId} not found.");
            }
        }
        static void DisplayTasks(TaskManager taskManager)
        {
            Console.WriteLine("===== Task List =====");
            List<Task> tasks = taskManager.GetTasks();

            foreach (Task task in tasks)
            {
                Console.WriteLine($"ID: {task.TaskID}, Name: {task.TaskName}, Deadline: {task.Deadline}, Status: {task.Status}, Assignee: {task.Assignee}, Description: {task.Description}");
            }
            Console.WriteLine("=======================");
        }
    }
}

