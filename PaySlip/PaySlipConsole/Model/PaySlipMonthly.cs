using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipConsole.Model
{
    public class PaySlipMonthly : IPaySlip
    {
        private IEmployee _employee;

        public PaySlipMonthly(IEmployee employee)
        {
            _employee = employee;
            GrossIncome = Math.Round(_employee.AnualSalary / 12,2);
            if (_employee.TaxCalculator != null)
            {
                IncomeTax = Math.Round(_employee.TaxCalculator.CalculateIncomeTax(_employee) / 12,2);
            }else
            {
                throw new Exception($"Tax Calculator is missing for employee {employee.DisplayName}");
            }

        }

        public string Name { get => _employee.DisplayName; }
        public double GrossIncome { get;  set; }

        public double IncomeTax { get;  set; }

        public double NetIncome { get => GrossIncome - IncomeTax; }

        public string getDetails()
        {
            return ($"Monthly Payslip for: \"{Name}\"\n" +
                $"Gross Monthly Income: ${GrossIncome}\n" +
                $"Monthly Income Tax: ${IncomeTax}\n" +
                $"Net Monthly Income: ${NetIncome}\n");
        }

        public void PrintDetails()
        {
            Console.WriteLine(getDetails());
        }
    }
}
