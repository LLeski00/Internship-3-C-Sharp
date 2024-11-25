﻿using ProjectManagerApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApp.Classes
{
    public class Project
    {
        public string Name { get; set; }
        public string Description { get; set; }
        private DateTime StartDate { get; set; }
        private DateTime EndDate { get; set; }
        private ProjectStatus Status { get; set; }

        public Project()
        {
            Name = "Unknown";
            Description = "Unknown";
            StartDate = DateTime.Now;
            EndDate = DateTime.MinValue;
            Status = ProjectStatus.Active;
        }

        public Project(string name, string description)
        {
            Name = name;
            Description = description;
            StartDate = DateTime.Now;
            EndDate = DateTime.MinValue;
            Status = ProjectStatus.Active;
        }

        public void SetEndDate (DateTime endDate)
        {
            EndDate = endDate;
        }

        public void SetStatus(ProjectStatus status)
        {
            Status = status;
        }

        public DateTime GetStartDate()
        {
            return StartDate;
        }

        public DateTime GetEndDate()
        {
            return EndDate;
        }

        public ProjectStatus GetStatus()
        {
            return Status;
        }
    }
}
