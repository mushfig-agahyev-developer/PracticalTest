using PracticalTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Domain.Rules
{
    public class LoanAmontRequirement : IBaseLoanRequirement
    {
        public const String RULE_NAME = "Loan_Amount";

        public string RuleName { get => RULE_NAME; }

        public bool CheckLoanApprovalRule(BaseRequirement model)
        {
            var loanAmount = model.Amount;

            switch (loanAmount)
            {
                case float n when (n <= 50000 && n >= 500):
                    return true;
                default:
                    return false;
            }
        }
    }
}
