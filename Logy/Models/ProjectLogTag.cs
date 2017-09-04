using System;
using System.Collections.Generic;

namespace Logy.Models
{
    public partial class ProjectLogTag
    {
        public int ProjectLogTagId { get; set; }
        public int ProjectLogId { get; set; }
        public int TagId { get; set; }

        public ProjectLog ProjectLog { get; set; }
        public Tag Tag { get; set; }
    }
}
