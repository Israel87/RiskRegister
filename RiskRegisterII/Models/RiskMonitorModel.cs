using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RiskRegister.CustomEnum.Enum;

namespace RiskRegister.Models
{
    public class RiskMonitor
    {
        public int Id { get; set; }
        public virtual RiskType RiskType { get; set; }
        public string ReferenceId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public InstanceStatus Status { get; set; }
        public List<ActionTaken> ActionsTaken { get; set; }
    }

    public class ActionTaken
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public InstanceStatus Status { get; set; }
   
    }
}
