using PracticalTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Burda kredit verilerken musterinin ayliq maas gostericisinin gotureceyi kreditin meblegi ile uygunlunu.
/// Gecikmeleri ve s. emeliyyatlari yerine yetirmek olar
/// </summary>
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
                    // Loans from $50,000 to $1,000,000 are OK
                    return true;
                default:
                    return false;
            }
        }
    }
}
