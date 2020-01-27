using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipConsole.Model
{
    /** 
     * A simple implemention by utilizing the array data structure.
     * the tax ties are ascending ordered in the array.
     * and are iterated through until the matched tie is reached.
     * Sum the tax from each tie.
     */
    public class TaxCalculator_AU_FY19 : ITaxCalculator
    {
        static TaxRateTie TIE1 = new TaxRateTie(0, 20000, 0);
        static TaxRateTie TIE2 = new TaxRateTie(20001, 40000, 0.1);
        static TaxRateTie TIE3 = new TaxRateTie(40001, 80000, 0.2);
        static TaxRateTie TIE4 = new TaxRateTie(80001, 180000, 0.3);
        static TaxRateTie TIE5 = new TaxRateTie(180001, int.MaxValue, 0.4);
        static TaxRateTie[] TiesArray = new TaxRateTie[] { TIE1, TIE2, TIE3, TIE4, TIE5 };

        public double CalculateIncomeTax(IEmployee employee)
        {
            double tax = CalculateIncomeTax(employee.AnualSalary);
            return tax;
        }
        public double CalculateIncomeTax(double anualSalary)
        {
            double tax = 0;
            foreach (TaxRateTie trt in TiesArray)
            {
                if (anualSalary > trt.Max)
                {
                    tax = tax + (trt.Max - trt.Min + 1) * trt.Rate;
                }
                else
                {
                    tax = tax + (anualSalary - trt.Min + 1) * trt.Rate;
                    break;
                }
            }
            return tax;
        }

    }
}
