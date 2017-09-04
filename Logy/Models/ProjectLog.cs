using System;
using System.Collections.Generic;

namespace Logy.Models
{
    public partial class ProjectLog
    {
        public ProjectLog()
        {
            ProjectLogTag = new HashSet<ProjectLogTag>();
        }

        public int ProjectLogId { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }

        public Project Project { get; set; }
        public AspNetUsers User { get; set; }
        public ICollection<ProjectLogTag> ProjectLogTag { get; set; }
    }
}
