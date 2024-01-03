using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dp_project.Command;
using dp_project.Observer;
using dp_project.State;
using dp_project.strategy;

namespace dp_project
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            TaskObserver observer = new TaskObserver("Default Observer");
            ConsoleUI consoleUI = new ConsoleUI();

            taskManager.AttachObserver(observer);

            while (true)
            {
                consoleUI.DisplayLoginScreen();

                Console.Write("Do you want to continue (y/n)? ");
                string choice = Console.ReadLine().ToLower();

                if (choice != "y")
                {
                    break; // Exit the loop if user doesn't want to continue
                }
            }
            




        }

    }
}

