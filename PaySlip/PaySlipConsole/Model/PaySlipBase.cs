using System;
using System.Collections.Generic;
using System.Text;
namespace PaySlipConsole.Model
{
    /**
     *  base class for payslip that provides the common attributes and logics.
     */
    public class PaySlipBase : IPaySlip
    {
        IEmployee _employee;

        public PaySlipBase(IEmployee employee)
        {
            _employee = employee;
        }

        public void Init()
        {
            Name = _employee.DisplayName;
            GrossIncome = Math.Round(_employee.AnualSalary / PeriodNumber, 2);
            if (_employee.TaxCalculator != null)
            {
                IncomeTax = Math.Round(_employee.TaxCalculator.CalculateIncomeTax(_employee) / PeriodNumber, 2);
            }
            else
            {
                throw new Exception($"Tax Calculator is missing for employee {Name}");
            }
        }
        public virtual int PeriodNumber { get => 1; }
        public string Name { get; set; }
        public double GrossIncome { get; set; }

        public double IncomeTax { get; set; }

        public double NetIncome { get => GrossIncome - IncomeTax; }

        public virtual string GetDetails() {
            return "Base PaySlip.";
        }

        public virtual void PrintDetails()
        {
            Console.WriteLine(GetDetails());
        }
    }
}
