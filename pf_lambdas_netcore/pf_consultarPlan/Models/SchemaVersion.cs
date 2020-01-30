using System;
using System.Collections.Generic;

namespace pf_consultarPlan.Models
{
    public partial class SchemaVersion
    {
        public int InstalledRank { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Script { get; set; }
        public int? Checksum { get; set; }
        public string InstalledBy { get; set; }
        public DateTimeOffset InstalledOn { get; set; }
        public int ExecutionTime { get; set; }
        public byte Success { get; set; }
    }
}
