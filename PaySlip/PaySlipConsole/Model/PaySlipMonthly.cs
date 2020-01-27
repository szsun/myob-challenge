using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipConsole.Model
{
    public class PaySlipMonthly : PaySlipBase
    {
        public override int PeriodNumber { get => 12; }
        public string PeriodName { get => "Monthly"; }
        public PaySlipMonthly(IEmployee employee) : base(employee)
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
