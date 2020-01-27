using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipConsole.Model
{
    public class PaySlipFornightly : PaySlipBase
    {
        public override int PeriodNumber { get => 26; }
        public string PeriodName { get => "Fornightly"; }
        public PaySlipFornightly(IEmployee employee): base(employee)
        {
        }

        public override string GetDetails()
        {
            return ($"{PeriodName} Payslip for: \"{Name}\"\n" +
                $"Gross {PeriodName} Income: ${GrossIncome}\n" +
                $"{PeriodName} Income Tax: ${IncomeTax}\n" +
                $"Net {PeriodName} Income: ${NetIncome}\n");
        }

    }
}
