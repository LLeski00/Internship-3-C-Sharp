using ProjectManagerApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = ProjectManagerApp.Enums.TaskStatus;

namespace ProjectManagerApp.Classes
{
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        private DateTime Deadline { get; set; }
        public TaskStatus Status { get; set; }
        public int ExpectedDurationInMinutes { get; set; }
        private Project? AssociatedProject { get; set; }

        public Task(string name, string description)
        {
            Name = name;
            Description = description;
            Deadline = DateTime.MinValue;
            Status = TaskStatus.Active;
            ExpectedDurationInMinutes = 0;
            AssociatedProject = null;
        }
        public DateTime GetDeadline() { return Deadline; }

        public void SetAssociatedProject(Project associatedProject)
        {
            AssociatedProject = associatedProject;
        }

        public void SetDeadline(DateTime deadline)
        {
            Deadline = deadline;
        }

        public void SetExpectedDurationInMinutes(int expectedDurationInMinutes)
        {
            ExpectedDurationInMinutes = expectedDurationInMinutes;
        }

        public string GetStatus()
        {
            var status = "Unknown";

            switch (Status)
            {
                case TaskStatus.Active:
                    status = "Active";
                    break;
                case TaskStatus.Postponed:
                    status = "On hold";
                    break;
                case TaskStatus.Done:
                    status = "Done";
                    break;
                default:
                    break;
            };

            return status;
        }
    }
}
