using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOopsBasicApp
{
    internal class ContractEmployee : Employee
    {
        public float PerDayCommercial { get; set; }

        override public string ToString()
        {
            return base.ToString() + "\nPer Day Commercial: " + PerDayCommercial;
        }
    }
}
