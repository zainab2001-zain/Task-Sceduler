using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp_project.Fctory
{
    class TaskFactory
    {
        public ITask CreateTask(string taskType)
        {
            // Factory logic based on task type
            // ...
            return new NewTask(); // Default to NewTask
        }
    }
}
