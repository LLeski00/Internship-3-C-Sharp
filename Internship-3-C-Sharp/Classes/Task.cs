using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApp.Classes
{
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        private DateTime Deadline { get; set; }
        public TaskStatus Status { get; set; }
        public int ExpectedDurationInMinutes { get; set; }
        public Project AssociatedProject { get; set; }
    }
}
