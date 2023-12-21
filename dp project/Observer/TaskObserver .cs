using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp_project.Observer
{
    class TaskObserver:IObserver
    {
        public string Name { get; }

        public TaskObserver(string name)
        {
            Name = name;
        }

        public void Update(Task task)
        {
            Console.WriteLine($"{Name} received task update: {task.TaskName}, Status: {task.Status}");
        }
    }
}
