using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipConsole.Model
{
    public interface ITaxCalculator
    {
        /**
         *  calculate the income tax based on employee's attributes;
         *  the simpliest case can be based on anualy salary only.
         */
        double CalculateIncomeTax(IEmployee employee);
    }
}
