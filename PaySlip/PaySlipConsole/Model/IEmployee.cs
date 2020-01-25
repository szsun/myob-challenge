using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipConsole.Model
{
    /**
     *  This interface is to provide the standard attributes for all types of employee.
     *  employee implementation can be specific to a certain type , eg, permanent, contract, partime, casual etc.
     */
    public interface IEmployee
    {
        public string DisplayName { get; set; }

        public double AnualSalary { get; set; }

        public PaySlipPeriodType PaySlipPeriodType { get; set; }
        public PaySlipLocation PaySlipLocation { get; set; }
        public ITaxCalculator TaxCalculator { get; set; }

        // extended attributes eg. location/country,
    }
}
