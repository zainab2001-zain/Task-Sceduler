using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dp_project.Memento;

namespace dp_project
{
    class Task
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
        public string Assignee { get; set; }
        public string Description { get; set; }
        public IMemento CreateMemento()
        {
            return new IMemento(this);
        }

        public void RestoreFromMemento(IMemento memento)
        {
            // Implement the restoration logic
        }
    }
}
