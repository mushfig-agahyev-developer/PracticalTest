using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Domain.Models
{
   public class BaseRequirement
    {
        public float Amount { get; set; }
        public double Salary { get; set; }
        public int LoanPeriod { get; set; }
    }
}
