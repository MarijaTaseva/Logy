using System;
using System.Collections.Generic;

namespace Logy.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectLog = new HashSet<ProjectLog>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public ICollection<ProjectLog> ProjectLog { get; set; }
    }
}
