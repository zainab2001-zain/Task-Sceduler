using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp_project.Composite
{
    class TaskList:List<Task>
    {
        public string Name { get; set; }

        public void AddTask(Task task)
        {
            Add(task);
        }

        public void RemoveTask(Task task)
        {
            Remove(task);
        }
    }
}
