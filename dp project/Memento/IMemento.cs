using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp_project.Memento
{
    class IMemento
    {
        private List<Task> tasks;

        public Task State { get; }

        public IMemento(Task state)
        {
            State = state;
        }

        public IMemento(List<Task> tasks)
        {
            this.tasks = tasks;
        }
    }
}
