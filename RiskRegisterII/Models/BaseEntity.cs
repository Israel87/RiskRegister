using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegisterII.Models
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime EntryDate { get; set; } = DateTime.Now;
        public string EnteredBy { get; set; } = "System";
    }
}
