using PracticalTest.DataStore.DTO;
using PracticalTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Domain.Rules
{
    /// <summary>
    /// Eger musterinin 1 ayliq maasi odeyeceyi kreditin 1 ayliq mebleginden coxdursa kredit verilmesi mumkun deyil!
    /// </summary>
    public class LoanSalaryCompare : IBaseLoanRequirement
    {
        public const string RULE_NAME = "Client_Salary";

        public string RuleName { get => RULE_NAME; }

        public bool CheckLoanApprovalRule(BaseRequirement model)
        {
            var _salary = model.Salary;

            var _single =  (int)Math.Ceiling(model.Amount / model.LoanPeriod);
            int _compare = (int)Math.Round((double)(100 * _salary) / 60);

            return _single > _compare;
        }
    }
}
