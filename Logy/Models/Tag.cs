using System;
using System.Collections.Generic;

namespace Logy.Models
{
    public partial class Tag
    {
        public Tag()
        {
            ProjectLogTag = new HashSet<ProjectLogTag>();
        }

        public int TagId { get; set; }
        public string Description { get; set; }

        public ICollection<ProjectLogTag> ProjectLogTag { get; set; }
    }
}
