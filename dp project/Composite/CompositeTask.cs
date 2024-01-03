using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp_project.Composite
{
    class CompositeTask:ITask
    {
        private List<ITask> tasks = new List<ITask>();

        public void AddTask(ITask task)
        {
            tasks.Add(task);
        }

        public void Display()
        {
            // Display logic for composite task
            // ...
        } 
    }
}
