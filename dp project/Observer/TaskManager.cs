using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dp_project.Memento;

namespace dp_project.Observer
{
    class TaskManager
    {
        private List<Task> tasks = new List<Task>();
        private List<IObserver> observers = new List<IObserver>();
        private Stack<IMemento> mementoStack = new Stack<IMemento>();
        public void AddTask(Task task)
        {
            tasks.Add(task);
            NotifyObservers(task);
            CreateMemento();
        }
        public void RemoveTask(Task task)
        {
            tasks.Remove(task);
            NotifyObservers(task);
            CreateMemento();
        }
        public void AttachObserver(IObserver observer)
        {
            observers.Add(observer);

        }

        public void NotifyObservers(Task task)
        {
            foreach (var observer in observers)
            {
                observer.Update(task);
            }
        }
        public void CreateMemento()
        {
            var currentState = new IMemento(new List<Task>(tasks));
            mementoStack.Push(currentState);
        }
        public void Undo()
        {
            if (mementoStack.Count > 1)
            {
                var currentState = mementoStack.Pop();
                var previousState = mementoStack.Peek();
                currentState.State.RestoreFromMemento(previousState);
                NotifyObservers(currentState.State);
            }
        }
        public Task GetTaskById(int taskId)
        {
            return tasks.Find(task => task.TaskID == taskId);
        }
        public List<Task> GetTasks()
        {
            return new List<Task>(tasks);
        }
    }
}
