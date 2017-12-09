using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATOEBackend.Models
{
    public class ResourceUsage
    {
        public int ResourceUsageId { get; set; }

        public DateTimeOffset? Start { get; set; }

        public DateTimeOffset? End { get; set; }

        public int ResourceId { get; set; }

        public virtual Resource Resource { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}