using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskRegister.CustomEnum
{
    public class Enum
    {
        public enum InstanceStatus
        {
            Pending,
            Active,
            Inactive

        }

        public enum ProcessStatus
        {
            Pending,
            Approved,
            Rejected
        }

        public enum ErrorRegisterStatus
        {
            Resolved,
            Unresolved
        }


    }
}
