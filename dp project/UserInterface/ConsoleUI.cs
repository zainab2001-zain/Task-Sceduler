using dp_project.Observer;
using System;
using System.Collections.Generic;
using System.Text;

namespace dp_project
{
    class ConsoleUI
    {


        MainComponents mainComponents = new MainComponents();
        AuthenticationService authenticationService = AuthenticationService.getInstance();
        TaskManager taskManager = new TaskManager();
        public ConsoleUI()
        {
            
            //mainComponents.TopBorder();
            //mainComponents.LeftBorder();
            //mainComponents.RightBorder();
            //mainComponents.BottomBorder();
            //mainComponents.MenuBox();
        }

        public void DisplayLoginScreen()
            
        {
            mainComponents.Title();
            /*Console.SetCursorPosition(47, 31);*/
            /*Console.WriteLine("===============================================================================")*/
            Console.SetCursorPosition(47, 33);
            Console.WriteLine("...Welcome! Please Enter UserName and Password Below to LogIn...");
            Console.SetCursorPosition(65, 35);
            Console.WriteLine("USER NAME: ");
            Console.SetCursorPosition(76, 35);
            string USERNAME = Console.ReadLine();
            Console.SetCursorPosition(65, 36);
            Console.WriteLine("PASSWORD: ");
            Console.SetCursorPosition(76, 36);
            string PASSWORD = Console.ReadLine();
            bool authenticated = authenticationService.Authenticate(USERNAME, PASSWORD); // Replace "username" with the actual username input

            if (authenticated)
            {
                if (USERNAME == "admin")
                {
                    DisplayAdminMenu();
                }
                else
                {
                    DisplayUserMenu();
                }
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
        }
        public void DisplayUserMenu(Users user) { }
        public void DisplayAdminMenu()
        {
            Console.Clear();
            mainComponents.Title();
            Console.SetCursorPosition(47, 28);
            Console.WriteLine("...Welcome! Admin Please choose an Option from the menu...");
            Console.SetCursorPosition(70, 31);
            Console.WriteLine("1. Create Task");
            Console.SetCursorPosition(70, 33);
            Console.WriteLine("2. Update Task");
            Console.SetCursorPosition(70, 35);
            Console.WriteLine("3. Delete Task");
            Console.SetCursorPosition(70, 37);
            Console.WriteLine("4. Display Tasks");
            Console.SetCursorPosition(70, 39);
            Console.WriteLine("5. Log out");
            Console.SetCursorPosition(55, 41);
            Console.WriteLine("Please write your Option here: ");
            Console.SetCursorPosition(86, 41);
            string option = (Console.ReadLine());
            switch (option)
            {
                case "1":
                    Console.Clear();
                    CreateTask(taskManager);
                    break;

                case "2":
                    Console.Clear();
                    UpdateTask(taskManager);
                    break;

                case "3":
                    DeleteTask(taskManager);
                    break;

                case "4":
                    DisplayTasks(taskManager);
                    break;

                case "5":
                    Console.Clear();
                    DisplayLoginScreen();
                    break;
                

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }

        }
        public void CreateTask(TaskManager taskManager)
        {
            Console.Write("How many tasks do you want to create? ");
            int numberOfTasks = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfTasks; i++)
            {
                Console.WriteLine($"Creating Task {i + 1}:");

                Console.Write("Enter Task Name: ");
                string taskName = Console.ReadLine();

                Console.Write("Enter Deadline (yyyy-mm-dd): ");
                string deadline = Console.ReadLine();

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
            Console.Clear();
            DisplayAdminMenu();

        }
        public void UpdateTask(TaskManager taskManager)
        {

            Console.Write("Enter Task ID to Update: ");
            int taskId = int.Parse(Console.ReadLine());
            if (taskId == null)
            {
                Console.WriteLine("Plz write the correct Id");
            }
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

            Console.Clear();
            DisplayAdminMenu();
        }
        public void DeleteTask(TaskManager taskManager)
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
            Console.Clear();
            DisplayAdminMenu();
        }
        public void DisplayTasks(TaskManager taskManager)
        {
            Console.Clear();
            Console.WriteLine("==========================Task List ============================");
            List<Task> tasks = taskManager.GetTasks();

            foreach (Task task in tasks)
            {
                Console.WriteLine($"ID: {task.TaskID}, Name: {task.TaskName}, Deadline: {task.Deadline}, Status: {task.Status}, Assignee: {task.Assignee}, Description: {task.Description}");
            }
            Console.WriteLine("===============================================");
            Console.WriteLine("Press Enter to go back.");
            Console.ReadLine(); // Wait for user to press Enter
            DisplayAdminMenu();
        }
        public void DisplayUserMenu()
        {
            Console.Clear();
            mainComponents.Title();
            Console.SetCursorPosition(50, 30);
            Console.WriteLine("...Welcome! User Please choose an Option from the menu...");
            Console.SetCursorPosition(50, 30);
            Console.WriteLine("Please select an option from below: ");
            Console.SetCursorPosition(70, 31);
            Console.WriteLine("1. Display Tasks");
            Console.SetCursorPosition(70, 33);
            Console.WriteLine("2. Update Task Status");
            Console.SetCursorPosition(70, 35);
            Console.WriteLine("3. Log Out");
            Console.SetCursorPosition(55, 41);
            Console.WriteLine("Please write your Option here: ");
            Console.SetCursorPosition(86, 41);
            string option = (Console.ReadLine());
            switch (option)
            {
                case "1":
                    Console.Clear();
                    DisplayTasks(taskManager);
                    break;

                case "2":
                    Console.Clear();
                    UpdateTask(taskManager);
                    break;

                case "3":
                    DisplayLoginScreen();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}
