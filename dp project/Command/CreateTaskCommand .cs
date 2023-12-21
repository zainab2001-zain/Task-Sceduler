using dp_project.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp_project.Command
{
    class CreateTaskCommand
    {
        private TaskManager taskManager;
        private Task task;

        public CreateTaskCommand(TaskManager taskManager, Task task)
        {
            this.taskManager = taskManager;
            this.task = task;
        }

        public void Execute()
        {
            taskManager.AddTask(task);
        }
    }
}
