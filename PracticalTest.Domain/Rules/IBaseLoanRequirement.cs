using PracticalTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Domain.Rules
{
    public interface IBaseLoanRequirement
    {
        string RuleName { get; }
        bool CheckLoanApprovalRule(BaseRequirement model);
    }
}
