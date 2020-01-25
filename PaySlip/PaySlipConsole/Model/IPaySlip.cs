using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipConsole.Model
{
    public interface IPaySlip
    {
        public string Name { get; }
        public double GrossIncome { get; set; }

        public double IncomeTax { get; set; }

        public double NetIncome { get;}
        public void PrintDetails();

    }
}
