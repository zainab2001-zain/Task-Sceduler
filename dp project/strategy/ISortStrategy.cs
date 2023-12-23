using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dp_project.strategy
{
    interface ISortStrategy
    {
        void Sort(List<ITask> tasks);
    }
}
