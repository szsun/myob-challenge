using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipConsole.Model
{
    public class PaySlipFornightly : IPaySlip
    {
        private IEmployee _employee;

        public PaySlipFornightly(IEmployee employee)
        {
            _employee = employee;
            GrossIncome = Math.Round(_employee.AnualSalary / 26,2);
            if (_employee.TaxCalculator != null)
            {
                IncomeTax = Math.Round(_employee.TaxCalculator.CalculateIncomeTax(_employee) / 26,2);
            }
            else
            {
                throw new Exception("Tax Calculator is missing for employee {employee.DisplayName}");
            }
        }


        public string Name { get => _employee.DisplayName; }
        public double GrossIncome { get; set; }

        public double IncomeTax { get; set; }

        public double NetIncome { get => GrossIncome - IncomeTax; }

        public void PrintDetails()
        {
            Console.WriteLine($"Fornightly Payslip for: \"{Name}\"\n" +
                $"Gross Fornightly Income: ${GrossIncome}\n" +
                $"Fornightly Income Tax: ${IncomeTax}\n" +
                $"Net Fornightly Income: ${NetIncome}\n");
        }
    }
}
