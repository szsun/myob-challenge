using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipConsole.Model
{
    public class PermanentEmployee : IEmployee
    {
        public PermanentEmployee(string displayName, double anualSalary)
        {
            DisplayName = displayName;
            AnualSalary = anualSalary;
        }

        public string DisplayName { get; set; }

        public double AnualSalary { get; set; }

        public PaySlipPeriodType PaySlipPeriodType { get; set; }
        public PaySlipLocation PaySlipLocation { get; set; }
        public ITaxCalculator TaxCalculator { get; set; }
        
    }
}
