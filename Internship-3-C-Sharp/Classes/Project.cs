using ProjectManagerApp.Enums;
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
    }
}
